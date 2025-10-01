namespace MonitoringMottu.Domain.Entities
{
    public class Garagem
    {
        public Guid Id { get; private set; }
        public string Endereco { get; private set; }
        public int Capacidade { get; private set; }
        public string Responsavel { get; private set; }


        public ICollection<Moto> Motos { get; private set; } = new List<Moto>();

        public Garagem(string endereco, int capacidade, string responsavel)
        {
            Endereco = endereco;
            Capacidade = capacidade;
            Responsavel = responsavel;
        }
        
        public void Refresh(string endereco, int capacidade, string responsavel)
        {
            Endereco = endereco;
            Capacidade = capacidade;
            Responsavel = responsavel;
        }
        
        public record GaragemResponse(Guid Id, string Endereco, int Capacidade, string Responsavel);
    }
}