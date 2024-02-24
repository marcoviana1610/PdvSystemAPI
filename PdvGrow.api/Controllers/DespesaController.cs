using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdvGrow.api.Models;

namespace PdvGrow.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DespesaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Despesa>> GetDespesas()
        {
            return _context.Despesas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Despesa> GetDespesa(int id)
        {
            var despesa = _context.Despesas.Find(id);

            if (despesa == null)
            {
                return NotFound();
            }

            return despesa;
        }

        [HttpPost]
        public ActionResult<Despesa> PostDespesa(Despesa despesa)
        {
            _context.Despesas.Add(despesa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDespesa), new { id = despesa.Id }, despesa);
        }

        [HttpPut("{id}")]
        public IActionResult PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesa).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDespesa(int id)
        {
            var despesa = _context.Despesas.Find(id);

            if (despesa == null)
            {
                return NotFound();
            }

            _context.Despesas.Remove(despesa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
