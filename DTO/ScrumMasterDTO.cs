using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class ScrumMasterDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "4 {0} é necessário")]
        [MinLength(4, ErrorMessage = "Este campo deve ter 4 {0}")]
        [MaxLength(4, ErrorMessage = "Este campo deve ter 4 {0}")]
        public string Letras { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        public int TecnologiaId { get; set; }
    }
}