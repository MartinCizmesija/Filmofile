using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models
{
    public partial class Person
    {
        public Person()
        {
            Role = new HashSet<Role>();
            Technician = new HashSet<Technician>();
        }

        [Display(Name = "Person Id")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]
        public string PersonName { get; set; }

        [Display(Name = "Surname")]
        public string? PersonSurname { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? Birth { get; set; }

        [Display(Name = "Biography")]
        public string? Biography { get; set; }


        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<Technician> Technician { get; set; }
    }
}
