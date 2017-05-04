using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class AdDetails : EntityBase
    {
        [Required]
        [StringLength(200, ErrorMessage = "Detalj može sadržavati najviše 200 znakova")]
        [Display(Name = "Detalj")]
        public string Detail { get; set; }
        [Required]
        [ForeignKey("Ad")]
        public int Ad_ID { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
