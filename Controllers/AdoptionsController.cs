using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc2_progra.Data;
using pc2_progra.Models;

namespace pc2_progra.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var adoptions = await _context.Adoptions
                .Include(a => a.Pet)
                .Include(a => a.Adopter)
                .ToListAsync();
            return View(adoptions);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Pets = await _context.Pets
                .Where(p => p.Estado == "Disponible")
                .ToListAsync();
            ViewBag.Adopters = await _context.Adopters.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetId,AdopterId")] Adoptions adoption)
        {
            if (ModelState.IsValid)
            {
                var pet = await _context.Pets.FindAsync(adoption.PetId);
                if (pet != null)
                {
                    pet.Estado = "Adoptado";
                    adoption.AdoptionDate = DateTime.Now;
                    _context.Add(adoption);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(adoption);
        }
    }
}