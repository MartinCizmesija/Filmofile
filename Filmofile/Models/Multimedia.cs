using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Multimedia
    {
        [Display(Name = "Language Id")]
        public int MultimediaId { get; set; }

        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "The link must exist")]
        [Display(Name = "Multimedia link")]
        public string MultimediaLink { get; set; }

        public virtual Movie MovieIdNavigation { get; set; }
    }
}
