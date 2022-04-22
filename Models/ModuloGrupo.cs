namespace Desafio.Models
{
    public class ModuloGrupo
    {
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
