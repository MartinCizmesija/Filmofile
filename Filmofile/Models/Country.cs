using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Country {

        public Country() {
            Country_Movie = new HashSet<Country_movie>();
        }

        public int CountryId { get; set; }
        [Display(Name = "Country Id")]
        public string CountryName { get; set; }
        [Required(ErrorMessage = "The name of the country is required")]
        [Display(Name = "Country Name")]

        public virtual ICollection<Country_movie> Country_Movie { get; set; }
    }
}
