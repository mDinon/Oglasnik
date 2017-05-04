using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "Kategorija može sadržavati najviše 50 znakova.")]
        [Display(Name = "Kategorija")]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
