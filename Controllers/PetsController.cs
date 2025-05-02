using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc2_progra.Data;
using pc2_progra.Models;

namespace pc2_progra.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Edad,Tipo,Estado,Descripcion")] Pets pets)
        {
            if (ModelState.IsValid)
            {
                pets.CreatedAt = DateTime.Now;
                _context.Add(pets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", pets);
        }
    }
}