using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(127, ErrorMessage = "O Nome do Fornecedor não pode ter mais que 127 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CNPJ do Fornecedor não pode ter mais que 14 caracteres.")]
        public string CNPJ { get; set; }

        [Display(Name = "Informações de Contato")]
        [Required(ErrorMessage = "As informações de contato são obrigatórias.")]
        [StringLength(127, ErrorMessage = "As informações de contato do Fornecedor não podem ter mais que 127 caracteres.")]
        public string ContactInfo { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(127, ErrorMessage = "O endereço do Fornecedor não pode ter mais que 127 caracteres.")]
        public string Address { get; set; }
    }
}
