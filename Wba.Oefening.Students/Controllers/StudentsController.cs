using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wba.Oefening.Students.Domain;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly List<Student> students;

        [Route("students/index")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome";
            return View();
        }

        [Route("students/details/{id}")]
        public IActionResult Details(int id)
        {

            StudentsDetailsVm studentsDetailsVm = new StudentsDetailsVm();
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                studentsDetailsVm.StudentId = id;
                studentsDetailsVm.StudentName = $"{student.FirstName} {student.LastName}";
                studentsDetailsVm.StudentCourse = student.Course;
                return View(studentsDetailsVm);
            }
            else
            {
                return Content("<h1>404 ERROR Student not found</h1>", "text/html");
            }
        }

        [Route("students/showall")]
        public IActionResult ShowAll()
        {
            var students = new List<Student>()
            {
                new Student { Id = 1, FirstName = "Tiana", LastName = "Williams", Course = "WBA" },
                new Student { Id = 2, FirstName = "Lexi-May", LastName = "Pruitt", Course = "PRE" },
                new Student { Id = 3, FirstName = "Jimmy", LastName = "Wyat", Course = "CIA" }
            };

            StudentsShowAllVm studentsShowAllVm = new StudentsShowAllVm { Students = students };

            return View(studentsShowAllVm);
        }

        public StudentsController()
        {
            students = new List<Student>()
            {
                new Student { Id = 1, FirstName = "Brock", LastName = "Lesnar", Course = "WBA" },
                new Student { Id = 2, FirstName = "Yusha", LastName = "Stamp", Course = "PRE" },
                new Student { Id = 3, FirstName = "Mario", LastName = "Super", Course = "CIA" }
            };
        }
    }
}
