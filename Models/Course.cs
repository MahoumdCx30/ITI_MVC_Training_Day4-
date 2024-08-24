using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ITI_MVC_Assingment_D2.Models
{
    public class Course
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public int minDegree { get; set; }
        public double Degree { get; set; }
        [ForeignKey("Dept_id")]
        public int Dept_id { get; set; }

        public virtual Department Department { get; set; }
        public virtual List<Crs_Result>? Crs_Results { get; set; }
        public virtual List<Instructor>? Instrctors { get; set; }


    }
}
