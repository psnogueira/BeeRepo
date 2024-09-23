using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bee.Models.Enum;

namespace Bee.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(127, ErrorMessage = "O Nome do evento não pode ter mais que 127 caracteres.")]
        public string Name { get; set; }

        [ForeignKey("EventType")]
        [Display(Name = "Tipo de Evento")]
        [Required(ErrorMessage = "Tipo de evento é obrigatório.")]
        public int EventTypeId { get; set; }

        [ForeignKey("Company")]
        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Empresa é obrigatória.")]
        public int CompanyId { get; set; }

        [ForeignKey("Franchise")]
        [Display(Name = "Franquia")]
        [Required(ErrorMessage = "Franquia é obrigatória.")]
        public int FranchiseId { get; set; }

        [Display(Name = "Data de Início")]
        [Required(ErrorMessage = "Data de início do evento é obrigatória.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data de Encerramento")]
        [Required(ErrorMessage = "Data de encerramento do evento é obrigatória.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Objetivo")]
        public string? Objective { get; set; }

        // Status do evento
        // 0 - Não iniciado
        // 1 - Em andamento
        // 2 - Encerrado
        // 3 - Cancelado
        [Display(Name = "Status")]
        public EventStatus? Status { get; set; }

        // Formato do evento
        // 0 - Presencial
        // 1 - Online
        // 2 - Híbrido
        [Display(Name = "Formato do Evento")]
        public EventFormat? Format { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Cidade do evento é obrigatória.")]
        public string City { get; set; }

        [Display(Name = "Local")]
        [Required(ErrorMessage = "Local do evento é obrigatório.")]
        public string Localization { get; set; }

        [Display(Name = "Orçamento Estimado")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "O orçamento do evento não pode ser negativo.")]
        public decimal? Budget { get; set; }
    }
}
