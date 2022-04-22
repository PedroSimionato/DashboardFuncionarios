using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class GrupoStarterDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TecnologiaId { get; set; }

        [Required]
        public int ScrumMasterId { get; set; }
        public int StartersId { get; set; }
        
    }
}