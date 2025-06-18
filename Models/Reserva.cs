namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; }
        public Suite Suite { get; private set; }
        public int DiasReservados { get; private set; }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            if (string.IsNullOrEmpty(suite.TipoSuite)) 
            {
                throw new ArgumentException("A suíte não pode ser vazia.");
            }

            Suite = suite;
        }

        public void DefinirDiasReservados(int diasReservados)
        {
            if (diasReservados <= 0)
            {
                throw new ArgumentException("A quantidade de dias reservados deve ser no mínimo 1.");
            }

            DiasReservados = diasReservados;
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = Suite.ValorDiaria * DiasReservados;
            
            // Aplicando desconto de 10% se a reserva for para 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valorTotal *= 0.9m;
            }

            return valorTotal;
        }
    }
}