using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Persona5APP.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        [Display(Name = "Persona")]
        public string PersonaName { get; set; }
        public int arcanaID { get; set; }
        public Arcana arcana { get; set; }
    }
}
