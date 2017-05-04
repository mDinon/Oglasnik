using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.DTO
{
    public class AdsDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Naziv oglasa može sadržavati najviše 200 znakova.")]
        [Display(Name = "Naziv oglasa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Kategorija")]
        public int Category_ID { get; set; }
        [Required]
        [Display(Name = "Cijena")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Stanje")]
        public bool IsNew { get; set; }
        [Required]
        [Display(Name = "Valuta")]
        public int Currency_ID { get; set; }
        public List<AdDetailsDTO> AdDetails { get; set; }
    }
}
