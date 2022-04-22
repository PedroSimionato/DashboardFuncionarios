using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class ProgramaStarterDTO
    {
        [Required(ErrorMessage = "É necessario informar qual o numero da nova turma.")]
        public int Id { get; set; }

        [Required]
        public int Turma { get; set; }

        [Required(ErrorMessage = "A turma deve ter uma data de inicio")]
        [DataType(DataType.DateTime, ErrorMessage = "Valor inválido")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "A turma deve ter uma data de inicio")]
        [DataType(DataType.DateTime)]
        public DateTime Fim { get; set; }
    }
}