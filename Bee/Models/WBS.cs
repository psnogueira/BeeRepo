using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class WBS
    {
        [Key]
        [Display(Name = "Id")]
        public int WBSId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da WBS é obrigatório.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Código da WBS deve ter no máximo 10 caracteres e no mínimo 4.")]
        public string Code { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição da WBS é obrigatória.")]
        [StringLength(255, ErrorMessage = "Descrição da WBS deve ter no máximo 255 caracteres.")]
        public string Desc { get; set; }
    }
}
