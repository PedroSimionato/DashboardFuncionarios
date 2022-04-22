using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class ProjetoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public float Avaliacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ModuloId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int StarterId { get; set; }
    }
}