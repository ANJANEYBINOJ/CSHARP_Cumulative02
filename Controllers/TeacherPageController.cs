using Cumulative01.DALL;
using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative01.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherData _data;

        public TeacherPageController(IConfiguration config)
        {
            _data = new TeacherData(config);
        }

        // READ: List all teachers
        public IActionResult List()
        {
            return View(_data.GetAllTeachers());
        }

        // READ: Show one teacher
        public IActionResult Show(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : View(teacher);
        }

        // CREATE: Show form to add a new teacher
        public IActionResult New()
        {
            return View();
        }

        // CREATE: Handle form submission to add new teacher
        [HttpPost]
        public IActionResult Create(string FirstName, string LastName, DateTime HireDate)
        {
            var newTeacher = new Teacher
            {
                FirstName = FirstName,
                LastName = LastName,
                HireDate = HireDate
            };

            _data.AddTeacher(newTeacher);
            return RedirectToAction("List");
        }

        // DELETE: Show confirmation page
        public IActionResult DeleteConfirm(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : View(teacher);
        }

        // DELETE: Handle confirmed delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _data.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        // UPDATE: Show Edit form
        public IActionResult Edit(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : View(teacher);
        }

        // UPDATE: Handle form submission to update teacher
        [HttpPost]
        public IActionResult Update(int id, string FirstName, string LastName, DateTime HireDate)
        {
            var updatedTeacher = new Teacher
            {
                Id = id,
                FirstName = FirstName,
                LastName = LastName,
                HireDate = HireDate
            };

            _data.UpdateTeacher(updatedTeacher);
            return RedirectToAction("List");
        }
    }
}
