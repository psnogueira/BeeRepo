using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class HACAT
    {
        [Key]
        [Display(Name = "Id")]
        public int HACATId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código HACAT é obrigatório.")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Código HACAT deve ter no máximo 8 caracteres e no mínimo 6.")]
        public string Code { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(255, ErrorMessage = "A descrição do HACAT deve ter no máximo 255 caracteres.")]
        public string? Desc { get; set; }
    }
}
