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
    public class ClienteController : Controller
    {
        private readonly Contexto _contexto;
        private readonly HttpClient _httpClient; // Instância de HttpClient

        public ClienteController(Contexto contexto)
        {
            _contexto = contexto;

            // Inicialize o HttpClient
            _httpClient = new HttpClient();
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Cliente.ToListAsync());
        }

        // Restante das ações do controlador permanece o mesmo

        // Método para carregar os dados do endpoint correspondente ao Cliente e inseri-los no banco de dados
        public async Task<IActionResult> CarregarDadosCliente()
        {
            string url = "https://camposdealer.dev/Sites/TesteAPI/cliente";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(json);

                _contexto.Cliente.AddRange(clientes);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _contexto.Cliente.Any(e => e.idCliente == id);
        }
    }
}
