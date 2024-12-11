using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mvc.Data;
using System.Linq;
using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // champ prive pour stocker le dbcontext
        private readonly ApplicationDbContext _context;

        // liste d'enseignants
        // private static List<Teacher> teachers = new List<Teacher>
        // {
        //     new Teacher { Id = "1", Lastname = "Doe", Firstname = "John" },
        //     new Teacher { Id = "2", Lastname = "Smith", Firstname = "Jane" }
        // };
        // Creation d'une liste statique de Student
        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        // public ActionResult Index()
        // {
        //     return View(teachers);
        // }

        // public IActionResult Show(int id)
        // {
        //     var teacher = _context.Teachers.Find(id);
        //     return View(teacher);
        // }

        public ActionResult New()
        {
            return View();
        }

        // public ActionResult Edit(int id)
        // {
        //     Teacher teacher = teachers.Find(teacher => teacher.Id == id);
        //     return View(teacher);
        // }

        // public ActionResult Delete(int id)
        // {
        //     Teacher teacher = teachers.Find(teacher => teacher.Id == id);
        //     teachers.Remove(teacher);

        //     return RedirectToAction("Index");
        // }

        // [HttpPost]
        // public ActionResult Update(Teacher teacher)
        // {
        //     Teacher teacherToUpdate = teachers.Find(item => item.Id == teacher.Id);
        //     teacherToUpdate.Firstname = teacher.Firstname;
        //     teacherToUpdate.Lastname = teacher.Lastname;
        //     teacherToUpdate.Age = teacher.Age;
        //     teacherToUpdate.Field = teacher.Field;
        //     teacherToUpdate.Salary = teacher.Salary;
            
        //     return RedirectToAction("Index");
        // }

        // [HttpPost]
        // public IActionResult Add(Teacher teacher)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return RedirectToAction("New");
        //     }
        //     _context.Teachers.Add(teacher);

        //     _context.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}