using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Country_movie {

        [Display(Name = "Country Id")]
        public int CountryId { get; set; }

        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }

        public virtual Country CountryIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
