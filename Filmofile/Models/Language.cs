using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Language
    {
        public Language()
        {
            Language_Movie = new HashSet<Language_movie>();
        }

        [Display(Name = "Language Id")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "The name of the language is required")]
        [Display(Name = "Language Name")]
        public string LanguageName { get; set; }

        public virtual ICollection<Language_movie> Language_Movie { get; set; }
    }
}
