using System;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Nomination
    {
        public int NominationId { get; set; }
        [Display(Name = "Language Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]
        public string NominationName { get; set; }
        [Required(ErrorMessage = "The nomination name must exist")]
        [Display(Name = "Nomination Name")]
        public string NominationCategory { get; set; }
        [Display(Name = "Nomination Category")]
        public DateTime NominationYear { get; set; }
        [Required(ErrorMessage = "Year of nomination is required")]
        [Display(Name = "Nomination Year")]
        public Boolean DidItWin { get; set; }

        public virtual Movie MovieIdNavigation { get; set; }
    }
}
