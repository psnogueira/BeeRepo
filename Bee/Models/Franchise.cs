using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(127, ErrorMessage = "O Nome da franquia não pode ter mais que 127 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(255, ErrorMessage = "A descrição da franquia não pode ter mais que 255 caracteres.")]
        public string? Desc { get; set; }
    }
}
