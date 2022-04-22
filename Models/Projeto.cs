namespace Desafio.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public float Avaliacao { get; set; }
        public string Comentario { get; set; }
        public Modulo Modulo { get; set; }
        public Starter Starter { get; set; }
        public bool Status { get; set; }
    }
}