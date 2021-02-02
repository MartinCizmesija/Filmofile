using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmofile.ViewModels
{
    public class GenresViewModel
    {
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
