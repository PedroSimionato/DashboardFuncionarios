using System;

namespace Desafio.Models
{
    public class ProgramaStarter
    {
        public int Id { get; set; }
        public int Turma { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool Status { get; set; }
    }
}