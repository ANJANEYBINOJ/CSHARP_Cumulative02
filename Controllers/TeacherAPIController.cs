using Cumulative01.DALL;
using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;

namespace Cumulative01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherAPIController : ControllerBase
    {
        private readonly TeacherData _data;

        public TeacherAPIController(IConfiguration config)
        {
            _data = new TeacherData(config);
        }

        // READ - Get all teachers
        [HttpGet]
        public IActionResult GetAllTeachers() => Ok(_data.GetAllTeachers());

        // READ - Get one teacher by ID
        [HttpGet("{id}")]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : Ok(teacher);
        }

        // CREATE - Add a new teacher via API
        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null)
                return BadRequest("Invalid teacher data.");

            _data.AddTeacher(teacher);
            return Ok("Teacher added successfully.");
        }

        // DELETE - Delete a teacher by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _data.GetTeacherById(id);
            if (teacher == null)
                return NotFound("Teacher not found.");

            _data.DeleteTeacher(id);
            return Ok("Teacher deleted successfully.");
        }

        // PUT: Update a teacher via API
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            var existing = _data.GetTeacherById(id);
            if (existing == null)
                return NotFound("Teacher not found.");

            teacher.Id = id;
            _data.UpdateTeacher(teacher);

            return Ok("Teacher updated successfully.");
        }

    }
}
