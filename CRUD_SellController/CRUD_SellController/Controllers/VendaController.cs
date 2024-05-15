using CRUD_SellController.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SeuNamespace // Substitua "SeuNamespace" pelo namespace do seu projeto
{
    public class VendaController : Controller
    {
        private readonly Contexto _contexto;

        public VendaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Venda.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _contexto.Venda.FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idVenda,idCliente,idProduto,qtdVenda,vlrUnitarioVenda,dthVenda,vlrTotalVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(venda);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _contexto.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Venda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idVenda,idCliente,idProduto,qtdVenda,vlrUnitarioVenda,dthVenda,vlrTotalVenda")] Venda venda)
        {
            if (id != venda.idVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(venda);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.idVenda))
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
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _contexto.Venda.FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _contexto.Venda.FindAsync(id);
            _contexto.Venda.Remove(venda);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _contexto.Venda.Any(e => e.idVenda == id);
        }
    }
}
