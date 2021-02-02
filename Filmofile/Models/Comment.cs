using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Comment {
        
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        public virtual Movie MovieIdNavigation { get; set; }
        public virtual User UserIdNavigation { get; set; }
    }
}
