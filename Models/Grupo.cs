using System.Collections.Generic;

namespace Desafio.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public Tecnologia Tecnologia { get; set; }
        public ScrumMaster ScrumMaster { get; set; }
        public ICollection<Starter> Starters { get; set; }
        public ICollection<ModuloGrupo> ModuloGrupos { get; set; }
        public bool Status { get; set; }
    }
}