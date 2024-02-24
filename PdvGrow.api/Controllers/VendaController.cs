using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdvGrow.api.Models;

namespace PdvGrow.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venda>> GetVendas()
        {
            return _context.Vendas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> GetVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        [HttpPost]
        public ActionResult<Venda> PostVenda(Venda venda)
        {
            // Calcule o valor total da venda com base nos produtos vendidos
            venda.ValorTotal = venda.ProdutoIds.Sum(produtoId =>
            {
                var produto = _context.Produtos.Find(produtoId);
                return produto != null ? produto.Preco : 0;
            });

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult PutVenda(int id, Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
            {
                return NotFound();
            }

            _context.Vendas.Remove(venda);
            _context.SaveChanges();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}