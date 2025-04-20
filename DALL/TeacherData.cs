using System.Data;
using Cumulative01.Models;
using MySql.Data.MySqlClient;

namespace Cumulative01.DALL
{
    public class TeacherData
    {
        private readonly string _connectionString;

        public TeacherData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new();
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM teachers", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                teachers.Add(new Teacher
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    HireDate = reader.GetDateTime("HireDate")
                });
            }

            return teachers;
        }

        public Teacher? GetTeacherById(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM teachers WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Teacher
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    HireDate = reader.GetDateTime("HireDate")
                };
            }

            return null;
        }
        public void AddTeacher(Teacher teacher)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("INSERT INTO teachers (FirstName, LastName, HireDate) VALUES (@fn, @ln, @hd)", conn);
            cmd.Parameters.AddWithValue("@fn", teacher.FirstName);
            cmd.Parameters.AddWithValue("@ln", teacher.LastName);
            cmd.Parameters.AddWithValue("@hd", teacher.HireDate);

            cmd.ExecuteNonQuery();
        }

        public void DeleteTeacher(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("DELETE FROM teachers WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
        public void UpdateTeacher(Teacher teacher)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("UPDATE teachers SET FirstName = @fn, LastName = @ln, HireDate = @hd WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@fn", teacher.FirstName);
            cmd.Parameters.AddWithValue("@ln", teacher.LastName);
            cmd.Parameters.AddWithValue("@hd", teacher.HireDate);
            cmd.Parameters.AddWithValue("@id", teacher.Id);

            cmd.ExecuteNonQuery();
        }



    }
}
