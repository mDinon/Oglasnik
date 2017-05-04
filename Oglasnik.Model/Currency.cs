using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class Currency : EntityBase
    {
        [Required]
        [StringLength(5, ErrorMessage = "Valuta može sadržavati maksimalno 5 znakova.")]
        [Display(Name = "Valuta")]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
