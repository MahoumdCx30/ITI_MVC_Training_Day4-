namespace ITI_MVC_Assingment_D2.Models
{
    public class TraineeDetailsModelView
    {
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Address { get; set; }
        public string? Gread { get; set; }
        public string? Department { get; set; }

        //public string FontColoured { get; set; } = "green";

        public List<KeyValuePair < String , KeyValuePair<double,string>>>? CoursesDegree { get; set; }
        
    }
}
