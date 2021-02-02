using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Language_movie
    {
        public int LanguageId { get; set; }
        [Display(Name = "Language Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]

        public virtual Language LanguageIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
