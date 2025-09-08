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

        public Guid Garagemid { get; set; }
        public Garagem? Garagem { get; set; }

        public Moto(string modelo, string marca, string cor, string placa, StatusMoto statusMoto, Guid garagemid)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            StatusMoto = statusMoto;
            Garagemid = garagemid;
        }
    }
}