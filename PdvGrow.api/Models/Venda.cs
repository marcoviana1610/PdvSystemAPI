using System.ComponentModel.DataAnnotations;

namespace PdvGrow.api.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now.ToLocalTime();
        public decimal ValorTotal { get; set; }
        public List<int> ProdutoIds { get; set; } = new List<int>();
    }

}
