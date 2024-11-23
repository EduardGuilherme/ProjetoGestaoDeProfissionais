namespace gestaoDeProfissionais.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
