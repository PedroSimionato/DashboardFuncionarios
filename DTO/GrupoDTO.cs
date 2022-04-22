using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class GrupoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TecnologiaId { get; set; }

        [Required]
        public int ScrumMasterId { get; set; }

        public GrupoDTO()
        {
        }

        public GrupoDTO(int id, int tecnologiaId, int scrumMasterId)
        {
            Id = id;
            TecnologiaId = tecnologiaId;
            ScrumMasterId = scrumMasterId;
        }
    }
}