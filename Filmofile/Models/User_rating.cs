using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class User_rating
    {
        public int UserId { get; set; }
        [Display(Name = "User Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]
        public int UserRating { get; set; }
        [Display(Name = "User's rating for movie")]

        public virtual User UserIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
