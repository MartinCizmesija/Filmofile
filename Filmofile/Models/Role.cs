using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Role
    {
        public Role()
        {
            Role_Movie = new HashSet<Role_movie>();
        }

        public int RoleId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterSurname { get; set; }
        public int PersonId { get; set; }
        public string RoleDescription { get; set; }


        public virtual Person PersonIdNavigation { get; set; }
        public virtual ICollection<Role_movie> Role_Movie { get; set; }
    }
}
