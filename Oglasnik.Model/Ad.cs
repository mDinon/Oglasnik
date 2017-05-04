using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class Ad : EntityBase
    {
        [Required]
        [StringLength(200,ErrorMessage = "Naziv oglasa može sadržavati najviše 200 znakova.")]
        [Display(Name="Naziv oglasa")]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Category")]
        [Display(Name ="Kategorija")]
        public int Category_ID { get; set; }
        [Required]
        [Display(Name = "Cijena")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Stanje")]
        public bool IsNew { get; set; }
        [Required]
        [ForeignKey("Currency")]
        [Display(Name = "Valuta")]
        public int Currency_ID { get; set; }
        [ForeignKey("User")]
        public string User_ID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AdDetails> AdDetails { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
