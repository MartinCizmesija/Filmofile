using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Technician_movie
    {
        public int TechnicianId { get; set; }
        [Display(Name = "Technician Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]

        public virtual Technician TechnicianIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
