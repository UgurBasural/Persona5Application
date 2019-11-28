using Persona5APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona5APP.ViewModels
{
    public class ArcanaPersonaViewModel
    {
        public IEnumerable<Persona> Personas { get; set; }
        public Arcana Arcana { get; set; }
    }
}
