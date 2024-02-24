using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdvGrow.api.Models;

namespace PdvGrow.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
