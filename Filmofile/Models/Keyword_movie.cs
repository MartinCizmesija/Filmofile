using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Keyword_movie {
        public int KeywordId { get; set; }
        [Display(Name = "Keyword Id")]
        public int MovieId { get; set; }
        [Display(Name = "Movie Id")]

        public virtual Keyword KeywordIdNavigation { get; set; }
        public virtual Movie MovieIdNavigation { get; set; }
    }
}
