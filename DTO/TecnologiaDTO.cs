using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class TecnologiaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo nao pode ser nulo")]
        [MaxLength(10, ErrorMessage ="O {0} não pode exceder {1} caracteres")]
        [MinLength(3, ErrorMessage ="O {0} deve ter pelo menos {1} caracteres")]
        public string Tipo { get; set; }
        
        [Required(ErrorMessage = "A descrição nao pode ser nulo")]
        public string Descricao { get; set; }
        
    }
}