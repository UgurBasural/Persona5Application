using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Persona5APP.Models
{
    public class Arcana
    {
        public int arcanaID { get; set; }
        [DisplayName("Arcana Name")]
        [Required]
        public string Arcananame { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}
