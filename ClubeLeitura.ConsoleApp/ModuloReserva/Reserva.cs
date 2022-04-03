using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class Reserva : EntidadeBase
    {

        public Amigo amigo;
        public Revista revista;
        public DateTime dataInicialReserva;
        public bool estaAberta;

        public void Abrir()
        {
            if (!estaAberta)
            {
                estaAberta = true;
                dataInicialReserva = DateTime.Today;
            }
        }

        public void Fechar()
        {
            if (estaAberta)
                estaAberta = false;
        }

        public bool EstaExpirada()
        {
            bool ultrapassouDataReserva = dataInicialReserva.AddDays(2) > DateTime.Today;

            if (ultrapassouDataReserva)
                estaAberta = false;

            return ultrapassouDataReserva;
        }

        public override string ToString()
        {
            string statusReserva = estaAberta ? "Aberta" : "Fechada";
            string reserva =  ("\nNúmero: " + numero + "\nRevista reservada: " + revista.Colecao + "\nNome do amigo: " + amigo.Nome +
            "\nData da reserva: " + dataInicialReserva.ToShortDateString() + "\nStatus da reserva: " + statusReserva);
            return reserva;
        }
    }
}
