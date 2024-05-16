using CRUD_SellController.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUD_SellController.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Contexto _contexto;
        private readonly HttpClient _httpClient;

        public ProdutoController(Contexto contexto)
        {
            _contexto = contexto;
            _httpClient = new HttpClient(); // Inicialize o HttpClient
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Produto.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _contexto.Produto.FirstOrDefaultAsync(m => m.idProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduto,dscProduto,vlrUnitario")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _contexto.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProduto,dscProduto,vlrUnitario")] Produto produto)
        {
            if (id != produto.idProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(produto);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.idProduto))
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
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _contexto.Produto.FirstOrDefaultAsync(m => m.idProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _contexto.Produto.FindAsync(id);
            _contexto.Produto.Remove(produto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CarregarDadosProduto()
        {
            string url = "https://camposdealer.dev/Sites/TesteAPI/produto";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(json);

                _contexto.Produto.AddRange(produtos);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _contexto.Produto.Any(e => e.idProduto == id);
        }
    }
}
