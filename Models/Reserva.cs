using System;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            var capacidadeSuportaHospedes = Suite.Capacidade >= hospedes.Count;

            if (capacidadeSuportaHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Número de hóspedes maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count -1;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = this.Suite.ValorDiaria * this.DiasReservados;

            if (this.DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10M);
            }

            return valor;
        }
    }
}