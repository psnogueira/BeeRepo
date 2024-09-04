using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(127, ErrorMessage = "O Nome da empresa não pode ter mais que 127 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        public string CNPJ { get; set; }

        [Display(Name = "Informações de Contato")]
        [Required(ErrorMessage = "As informações de contato são obrigatórias.")]
        [StringLength(127, ErrorMessage = "As informações de contato da empresa não podem ter mais que 127 caracteres.")]
        public string ContactInfo { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(127, ErrorMessage = "O endereço da empresa não pode ter mais que 127 caracteres.")]
        public string Address { get; set; }
    }
}
