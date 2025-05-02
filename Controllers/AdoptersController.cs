using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc2_progra.Data;
using pc2_progra.Models;

namespace pc2_progra.Controllers
{
    public class AdoptersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listar()
        {
            var adopters = await _context.Adopters
                .Include(a => a.Adoptions)
                .ToListAsync();
            return View(adopters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Email,Telefono,Direccion")] Adopters adopter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View("Index", adopter);
        }
    }
}