using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Assingment_D2.Models
{
    public class Crs_Result
    {
            public int Id { get; private set; }
        public double Degree { get; set; }

            // Foreign Key properties
            public int Crs_id { get; set; }
            public int Trainee_id { get; set; }

            // Navigation properties
            public Course Course { get; set; }
            public Trainee Trainee { get; set; }

    }
}
