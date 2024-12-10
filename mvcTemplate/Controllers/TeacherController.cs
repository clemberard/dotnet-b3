using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // Creation d'une liste statique de Student
        private static List<Teacher> teachers = new()
        {
            new() { Id = 1, Firstname = "John", Lastname = "Doe", Age = 25, Field = Field.MATHS, Salary = 2000 },
            new() { Id = 2, Firstname = "Jane", Lastname = "Doe", Age = 24, Field = Field.ENGLISH, Salary = 2500 },
            new() { Id = 3, Firstname = "James", Lastname = "Doe", Age = 23, Field = Field.CS, Salary = 3000 },
            new() { Id = 4, Firstname = "Judy", Lastname = "Doe", Age = 22, Field = Field.BIOLOGY, Salary = 3500 },
            new() { Id = 5, Firstname = "Jack", Lastname = "Doe", Age = 21, Field = Field.CHEMISTRY, Salary = 4000 },
            new() { Id = 6, Firstname = "Jill", Lastname = "Doe", Age = 20, Field = Field.PHYSICS, Salary = 4500 },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(teachers);
        }

        public ActionResult Show(int id)
        {
            Teacher teacher = teachers.Find(teacher => teacher.Id == id);
            return View(teacher);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Teacher teacher = teachers.Find(teacher => teacher.Id == id);
            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            Teacher teacher = teachers.Find(teacher => teacher.Id == id);
            teachers.Remove(teacher);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            Teacher teacherToUpdate = teachers.Find(item => item.Id == teacher.Id);
            teacherToUpdate.Firstname = teacher.Firstname;
            teacherToUpdate.Lastname = teacher.Lastname;
            teacherToUpdate.Age = teacher.Age;
            teacherToUpdate.Field = teacher.Field;
            teacherToUpdate.Salary = teacher.Salary;
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            teacher.Id = teachers.Max(teacher => teacher.Id) + 1;
            teachers.Add(teacher);

            return RedirectToAction("Index");
        }
    }
}