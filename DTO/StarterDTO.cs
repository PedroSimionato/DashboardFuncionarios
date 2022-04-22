using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class StarterDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "4{0} é necessário")]
        [MinLength(4, ErrorMessage = "Deve ter {1} letras")]
        [MaxLength(4, ErrorMessage = "Deve ter {1} letras")]
        public string Letras { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        public int TecnologiaId { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        public int ProgramaId { get; set; }        
    }
}