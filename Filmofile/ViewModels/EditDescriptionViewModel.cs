using System.Collections.Generic;
using Filmofile.Models;

namespace Filmofile.ViewModels
{
    public class EditDescriptionViewModel
    {
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public int KeywordId { get; set; }
        public int LanguageId { get; set; }
        public int CountryId { get; set; }
    }
}
