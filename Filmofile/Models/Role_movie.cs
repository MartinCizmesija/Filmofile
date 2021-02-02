using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Role_movie
{
        public int RoleId { get; set; }
        [Display(Name = "Role Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]

        public virtual Role RoleIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
