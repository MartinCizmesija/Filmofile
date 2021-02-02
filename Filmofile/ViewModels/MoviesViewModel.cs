using System.Collections.Generic;

namespace Filmofile.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
