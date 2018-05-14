using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAula2CRUD.Models;

namespace WebAppAula2CRUD.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly EstudanteContext _context;

        public EstudanteController(EstudanteContext context)
        {
            _context = context;
        }

        // GET: Estudante
        public IActionResult Index()
        {
            return View(_context.Estudante.ToList());
        }

        // GET: Estudante/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante =  _context.Estudante
                .SingleOrDefault(m => m.EstudanteId == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EstudanteId,Nome,CPF,Email")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudante);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // GET: Estudante/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = _context.Estudante.SingleOrDefaultAsync(m => m.EstudanteId == id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Estudante estudante)
        {
            if (id != estudante.EstudanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudanteExists(estudante.EstudanteId))
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
            return View(estudante);
        }

        // GET: Estudante/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante =  _context.Estudante
                .SingleOrDefaultAsync(m => m.EstudanteId == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudante = _context.Estudante.SingleOrDefault(m => m.EstudanteId == id);
            _context.Estudante.Remove(estudante);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudante.Any(e => e.EstudanteId == id);
        }
    }
}
