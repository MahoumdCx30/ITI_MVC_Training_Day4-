using ITI_MVC_Assingment_D2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Assingment_D2.Controllers
{
    public class InstructorsController : Controller
    {
        ApplicationDbContext _context =new ApplicationDbContext();
        public IActionResult Index()
        {

            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = _context.Instructors.Find(id);
            var course = _context.Courses.FirstOrDefault(c => c.Id == instructor.Crs_id);
            ViewBag.CourseName = course.Name;
            var dept = _context.Departments.Find(instructor.Dept_id);
            ViewBag.DeptName = dept.Name;
            return View(instructor);
        }

        // Get New Instuctor Informations
        public IActionResult NewInstructor()
        {
            var departments = _context.Departments.ToList();
            var courses = _context.Courses.ToList();
            ViewBag.Departments = departments;
            ViewBag.Courses = courses;
            return View();
        }

        //save new instructor
        [HttpPost]
        public IActionResult SaveNewInstructor(Instructor instructor)
        {
            if (instructor != null)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("NewInstructor");

        }

        public IActionResult EditInstructor(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(c => c.Id == id);
            var departments = _context.Departments.ToList();
            var courses = _context.Courses.ToList();
            ViewBag.Departments = departments;
            ViewBag.Courses = courses;

            return View(instructor);
        }

        [HttpPost]
        public IActionResult SaveEditedInstructor(int id, Instructor instructor)
        {
            var OldInstructor = _context.Instructors.FirstOrDefault(c => c.Id == id);
            if (OldInstructor != null)
            {
                OldInstructor.Name = instructor.Name;
                OldInstructor.Address = instructor.Address;
                OldInstructor.Salary = instructor.Salary;
                OldInstructor.Crs_id = instructor.Crs_id;
                OldInstructor.Dept_id = instructor.Dept_id;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // if the instructor not found
            var departments = _context.Departments.ToList();
            var courses = _context.Courses.ToList();
            ViewBag.Departments = departments;
            ViewBag.Courses = courses;
            return View("EditInstructor", instructor);
        }


    }
}
