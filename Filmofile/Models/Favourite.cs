using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Favourite {
        public int UserId { get; set; }
        [Display(Name = "User Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]

        public virtual User UserIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
