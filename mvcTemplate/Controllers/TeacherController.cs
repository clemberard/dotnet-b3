using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // Creation d'une liste statique de Student
        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(teachers);
        }

        public IActionResult Show(int id)
        {
            var teacher = _context.Teachers.Find(id);
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
            // Declencher le mecanisme de validation
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter le teacher
            _context.Teachers.Add(teacher);

            // Sauvegarder les changements
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}