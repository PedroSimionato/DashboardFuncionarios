using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class ModuloDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}