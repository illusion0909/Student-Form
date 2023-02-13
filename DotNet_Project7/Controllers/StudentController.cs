using DotNet_Project7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet_Project7.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController()
        {
            _context= new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Student
        public ViewResult Index()
        {
            var studentList=_context.Students.ToList();
            return View(studentList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student) 
        { 
            if (student == null) return HttpNotFound();
            if(!ModelState.IsValid) return View();

            //Duplicate Email varification
            var duplicateEmail=_context.Students.FirstOrDefault(s=>s.Email== student.Email);
            if (duplicateEmail != null) 
            {
                ModelState.AddModelError("Email", "email in use");
                return View();
            }


            _context.Students.Add(student);
            _context.SaveChanges();
           return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return HttpNotFound();
            return View(studentInDb);
        }

        public ActionResult Edit(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return HttpNotFound();
            return View(studentInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (student == null) return HttpNotFound();
            if (!ModelState.IsValid) return View();

            var studenInDb = _context.Students.Find(student.Id);
            if (studenInDb == null) return HttpNotFound();

            //Email Validation
            var duplicate = _context.Students.FirstOrDefault(s => s.Email == student.Email);
            var emailExist = _context.Students.FirstOrDefault(s => s.Id == student.Id);

            if(duplicate!=null)
            {
                if(!(duplicate.Email==emailExist.Email && duplicate.Id== emailExist.Id))
                {
                    ModelState.AddModelError("Email", "email in use");
                    return View();

                }
            }
            studenInDb.Name = student.Name;
            studenInDb.Address = student.Address;
            studenInDb.Age = student.Age;
            studenInDb.Email = student.Email;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Delete(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return HttpNotFound();
            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}