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

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public ActionResult Index()
        {
            return View(getTeachers());
        }

        public IActionResult Show(string id)
        {
            var teacher = _context.Teachers.Find(id);
            return View(teacher);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            return View(teacher);
        }

        public ActionResult Delete(string id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            _context.Teachers.Remove(teacher);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            Teacher teacherToUpdate = _context.Teachers.Find(teacher.Id);
            teacherToUpdate.Firstname = teacher.Firstname;
            teacherToUpdate.Lastname = teacher.Lastname;
            teacherToUpdate.Age = teacher.Age;
            teacherToUpdate.Field = teacher.Field;
            teacherToUpdate.Salary = teacher.Salary;

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New");
            }
            _context.Teachers.Add(teacher);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<Teacher> getTeachers()
        {
            return _context.Teachers.ToList();
        }
    }
}