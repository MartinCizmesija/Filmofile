namespace Filmofile.Models
{
    public partial class Similar
    {
        public int RootMovie { get; set; }
        public int RefrencedMovie { get; set; }

        public virtual Movie RootIdNavigation { get; set; }
        public virtual Movie RefrencedIdNavigation { get; set; }
    }
}
