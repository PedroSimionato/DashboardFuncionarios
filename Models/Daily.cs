using System;

namespace Desafio.Models
{
    public class Daily
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Fazendo { get; set; }
        public string Feito { get; set; }
        public string Impedimento { get; set; }
        public bool Presenca { get; set; }
        public Modulo Modulo { get; set; }
        public Starter Starter { get; set; }
        public bool Status { get; set; }
    }
}