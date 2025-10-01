namespace MonitoringMottu.Domain.Entities
{
    public class Moto
    {
        public Guid Id { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string Cor { get; private set; }
        public string Placa { get; private set; }
        public StatusMoto StatusMoto { get; private set; }

        public Guid GaragemId { get; set; }
        public Garagem? Garagem { get; set; }

        public Moto(string modelo, string marca, string cor, string placa, Guid garagemId)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            StatusMoto = StatusMoto.Disponivel;
            GaragemId = garagemId;
        }

        public void Refresh(string modelo, string marca, string cor, string placa)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
        }
        
        public record MotoResponse(Guid Id, string Modelo, string Marca, string Cor, string Placa, string StatusMoto, Guid Garagemid);
    }
}