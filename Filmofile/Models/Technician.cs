using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Technician
    {
        public Technician()
        {
            Technician_Movie = new HashSet<Technician_movie>();
        }

        public int TechnicianId { get; set; }
        [Display(Name = "Technician Id")]
        public string JobBehindSet { get; set; }
        [Required(ErrorMessage = "The job description is required")]
        [Display(Name = "Job description")]
        public int PersonId { get; set; }
        [Display(Name = "Person Id")]

        public virtual Person PersonIdNavigation { get; set; }
        public virtual ICollection<Technician_movie> Technician_Movie { get; set; }
    }
}
