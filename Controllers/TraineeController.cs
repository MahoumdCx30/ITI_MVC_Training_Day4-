using Microsoft.AspNetCore.Mvc;
using ITI_MVC_Assingment_D2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace ITI_MVC_Assingment_D2.Controllers
{
    public class TraineeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var trainees = _context.Trainees.ToList();
            return View(trainees);
        }

        public IActionResult Details(int id)
        {
            var trainee = traineeData(id);
            return View(trainee);
        }

        private TraineeDetailsModelView traineeData(int id)
        {
            TraineeDetailsModelView? trainee = new TraineeDetailsModelView();
            var Wanted_Trainee = _context.Trainees.Find(id);
            var DeptName = _context.Departments.Find(Wanted_Trainee.Dept_id);
            var TraineeCrs_Results = from TCR in _context.Crs_result
                                     where TCR.Trainee_id == Wanted_Trainee.Id
                                     select TCR;

            var Mycourses = _context.Courses.ToList();
            if (trainee.CoursesDegree == null)
                        trainee.CoursesDegree = new List<KeyValuePair < String , KeyValuePair<double,string>>>();

                foreach (var MyTrainee in TraineeCrs_Results)
            {
                var Course = Mycourses.FirstOrDefault(x => x.Id == MyTrainee.Crs_id);
                //trainee.CoursesDegree.Add(new KeyValuePair<string, double>((Course.Name).ToString(), MyTrainee.Degree));
                //if (MyTrainee.Degree < Course.minDegree) trainee.FontColoured = "red";
                //else trainee.FontColoured = "green";

                var colour = "green";
                if (MyTrainee.Degree < Course.minDegree) colour = "red";
                trainee.CoursesDegree.Add(new KeyValuePair<string, KeyValuePair<double, string>>((Course.Name).ToString(), new KeyValuePair<double, string>(MyTrainee.Degree, colour)));
            }

            trainee.Name = Wanted_Trainee.Name;
            trainee.Img = Wanted_Trainee.Img;
            trainee.Address = Wanted_Trainee.Address;
            trainee.Gread = Wanted_Trainee.Gread;
            trainee.Department = DeptName.Name;

            return trainee;
        }
    }
}
