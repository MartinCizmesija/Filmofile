using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Genre_movie
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }

        public virtual Genre GenreIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }

    }
}
