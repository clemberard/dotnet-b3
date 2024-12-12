using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mvc.Data;
using System.Linq;
using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(getStudents());
        }

        private List<Student> getStudents()
        {
            return _context.Students.ToList();
        }
    }
}