using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmofile.Models
{
    public partial class Genre
    {

        public Genre() {
            Genre_Movie = new HashSet<Genre_movie>();
        }

        public int GenreId { get; set; }

        [Required(ErrorMessage = "The name of the genre is required")]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        public virtual ICollection<Genre_movie> Genre_Movie { get; set; }
    }
}
