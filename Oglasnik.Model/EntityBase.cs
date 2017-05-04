using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Datum kreiranja")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Datum izmjene")]
        public Nullable<DateTime> DateModified { get; set; }
    }
}
