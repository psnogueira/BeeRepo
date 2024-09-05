using System.ComponentModel.DataAnnotations;

namespace Bee.Models
{
    public class EventType
    {
        [Key]
        [Display(Name = "Id")]
        public int EventTypeId { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O Título é obrigatório.")]
        [StringLength(63, ErrorMessage = "O título do tipo do evento não pode ter mais que 63 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(255, ErrorMessage = "O título do tipo do evento não pode ter mais que 255 caracteres.")]
        public string? Desc { get; set; }
    }
}
