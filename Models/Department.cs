namespace ITI_MVC_Assingment_D2.Models
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual List<Course>? Dourses { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<Trainee>? Trainees { get; set; }



    }
}
