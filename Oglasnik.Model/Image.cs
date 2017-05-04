using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class Image : EntityBase
    {
        [Required]
        [ForeignKey("Ad")]
        public int Ad_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] ImageBytes { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
