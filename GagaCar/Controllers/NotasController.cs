using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GagaCar.Data;
using GagaCar.Models;
using GagaCar.Models.ViewModels;

namespace GagaCar.Controllers
{
    public class NotasController : Controller
    {
        private readonly GagaCarContext _context;

        public NotasController(GagaCarContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var gagaCarContext = _context.Nota.Include("Carro").Include("Cliente").Include("Vendedor");
            return View(await gagaCarContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new NotaFormViewModel();
            viewModel.Carros = _context.Carro.ToList();
            viewModel.Clientes = _context.Cliente.ToList();
            viewModel.Vendedores = _context.Vendedor.ToList();
            return View(viewModel);
        }


        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nota nota)
        {
            if (nota == null)
            { return NotFound(); }

            _context.Add(nota);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Notas/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            var viewModel = new NotaFormViewModel
            {
                Nota = nota,
                Carros = _context.Carro.ToList(),
                Clientes = _context.Cliente.ToList(),
                Vendedores = _context.Vendedor.ToList()
            };

            return View(viewModel);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var viewModel = new NotaFormViewModel
            {
                Nota = nota,
                Carros = _context.Carro.ToList(),
                Clientes = _context.Cliente.ToList(),
                Vendedores = _context.Vendedor.ToList()
            };
            return View(viewModel);
        }
       

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
            return _context.Nota.Any(e => e.Id == id);
        }
    }
}
