using System.Collections.Generic;
using Filmofile.Models;

namespace Filmofile.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<Language> Language { get; set; }
        public List<Country> Country { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<TechnitianViewModel> Technicians { get; set; }
        public List<MultimediaViewModel> Multimedia { get; set; }

        public int userRating;

    }
}
