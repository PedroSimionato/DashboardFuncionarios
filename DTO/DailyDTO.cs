using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class DailyDTO
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public DateTime Data { get; set; }


        [Required]
        public string Fazendo { get; set; }


        [Required]
        public string Feito { get; set; }
        public string Impedimento { get; set; }
        public int Presenca { get; set; }
        public int ModuloId { get; set; }
        public int StarterId { get; set; }
    }
}