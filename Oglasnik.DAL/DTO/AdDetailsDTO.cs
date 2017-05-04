using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.DTO
{
    public class AdDetailsDTO
    {
        public int DetailsID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Detalj može sadržavati najviše 200 znakova")]
        [Display(Name = "Detalj")]
        public string Detail { get; set; }
        [Required]
        public int Ad_ID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
