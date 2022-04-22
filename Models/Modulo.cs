using System.Collections.Generic;

namespace Desafio.Models
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ModuloGrupo> ModuloGrupos { get; set; }
        public bool Status { get; set; }
    }
}