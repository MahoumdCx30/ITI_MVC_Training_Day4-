using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Assingment_D2.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }

        // Foreign Key properties
        [ForeignKey("Dept_id")]
        public int Dept_id { get; set; }

        [ForeignKey("Crs_id")]
        public int Crs_id { get; set; }

        // Navigation properties
        public virtual Department Department{ get; set; }
        public virtual Course Course { get; set; }


    }
}
