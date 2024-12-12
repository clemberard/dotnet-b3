using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mvc.Data;
using System.Linq;
using mvc.Models;

namespace mvc.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(getEvents());
        }

        public IActionResult Details(int id)
        {
            var ev = _context.Events.Find(id);
            return View(ev);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Event ev = _context.Events.Find(id);
            return View(ev);
        }

        public ActionResult Delete(int id)
        {
            Event ev = _context.Events.Find(id);
            _context.Events.Remove(ev);

            _context.SaveChanges();

            TempData["Notification"] = "L'événement a été supprimé avec succès";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View(ev);
            }

            Event evToUpdate = _context.Events.Find(ev.Id);
            evToUpdate.Title = ev.Title;
            evToUpdate.Description = ev.Description;
            evToUpdate.EventDate = ev.EventDate;
            evToUpdate.MaxParticipants = ev.MaxParticipants;
            evToUpdate.Location = ev.Location;

            _context.SaveChanges();

            TempData["Notification"] = "L'événement a été modifié avec succès";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Events.Add(ev);
            _context.SaveChanges();

            TempData["Notification"] = "L'événement a été ajouté avec succès";

            return RedirectToAction("Index");
        }

        private List<Event> getEvents()
        {
            return _context.Events.ToList();
        }
    }
}