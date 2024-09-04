using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [ForeignKey("Supplier")]
        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O Fornecedor é obrigatório.")]
        public int SupplierId { get; set; }

        [ForeignKey("ExpenseType")]
        [Display(Name = "Tipo de Despesa")]
        [Required(ErrorMessage = "O Tipo de Despesa é obrigatório.")]
        public int ExpenseTypeId { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O Valor é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "O orçamento do evento não pode ser negativo.")]
        public decimal Value { get; set; }
    }
}
