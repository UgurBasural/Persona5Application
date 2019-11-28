using Persona5APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona5APP.ViewModels
{
    public class PersonaArcanaViewModel
    {
        public Persona Persona { get; set; }
        public IEnumerable<Arcana> Arcanas { get; set; }
    }
}
