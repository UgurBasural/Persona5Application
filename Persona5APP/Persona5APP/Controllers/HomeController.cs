using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Persona5APP.Models;
using Persona5APP.ViewModels;

namespace Persona5APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext db;

        public HomeController(DBContext context)
        {
            db = context;
        }

        public IActionResult Index(int page = 1, int pagesize = 4)
        {
            var Pagepersonas = db.Personas.Include(c => c.arcana);
            PagedList<Persona> personas = new PagedList<Persona>(Pagepersonas, page, pagesize);     
            return View(personas);
        }

        public IActionResult Search(int page = 1, int pagesize = 4)
        {
            var search = Request.Query["search"].ToString();
                var searchedpersonas = db.Personas.Include(c => c.arcana).Where(c => c.PersonaName.Contains(search));
                PagedList<Persona> personas = new PagedList<Persona>(searchedpersonas, page, pagesize);
                ViewBag.search = search;
                return View("Index", personas);
        }

        public IActionResult Create()
        {
            PersonaArcanaViewModel persona = new PersonaArcanaViewModel() {
                Arcanas = db.Arcanas.ToList()
            };
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            await db.Personas.AddAsync(persona);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
      
            PersonaArcanaViewModel updatepersona = new PersonaArcanaViewModel(){
                Arcanas = db.Arcanas.ToList(),
                Persona = persona
            };
            return View(updatepersona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Persona persona)
        {
                db.Update(persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int? id)
        {         
            var removingPersona = await db.Personas.FindAsync(id);
            db.Personas.Remove(removingPersona);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
