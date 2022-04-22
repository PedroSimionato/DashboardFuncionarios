namespace Desafio.Models
{
    public class Starter
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Letras { get; set; }
        public Tecnologia Tecnologia { get; set; }
        public ProgramaStarter Programa { get; set; }
        public Grupo Grupo { get; set; }
        public bool Status { get; set; }
    }
}