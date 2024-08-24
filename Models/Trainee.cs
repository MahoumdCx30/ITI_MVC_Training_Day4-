using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Assingment_D2.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public string Address { get; set; }
        public string Gread { get; set; }
        [ForeignKey("Dept_id")]
        public int Dept_id { get; set; }
        public virtual List<Crs_Result>? Crs_Results { get; set; }
        public virtual Department Department { get; set; }


    }
}
