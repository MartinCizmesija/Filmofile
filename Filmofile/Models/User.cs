using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class User {
        public User()
        {
            Watchlist = new HashSet<Watchlist>();
            UserRating = new HashSet<User_rating>();
            Favourite = new HashSet<Favourite>();
            Comment = new HashSet<Comment>();
        }
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "mail is required")]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "The role is required")]
        [Display(Name = "User role")]
        public UserRole UserRole { get; set; }


        public virtual ICollection<Watchlist> Watchlist { get; set; }
        public virtual ICollection<User_rating> UserRating { get; set; }
        public virtual ICollection<Favourite> Favourite { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }


    }
}
