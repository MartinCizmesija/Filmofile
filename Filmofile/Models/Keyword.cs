using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            Keyword_Movie = new HashSet<Keyword_movie>();
        }

        public int KeywordId { get; set; }
        public string KeywordName { get; set; }

        public virtual ICollection<Keyword_movie> Keyword_Movie { get; set; }
    }
}
