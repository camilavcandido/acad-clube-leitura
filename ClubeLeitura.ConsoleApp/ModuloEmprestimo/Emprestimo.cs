using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
    {
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;

        public bool estaAberto;

        public void Abrir()
        {
            if (!estaAberto)
            {
                estaAberto = true;
                dataEmprestimo = DateTime.Today;
                dataDevolucao = dataEmprestimo.AddDays(revista.categoria.DiasEmprestimo);
            }
        }

        public void Fechar()
        {
            if (estaAberto)
            {
                estaAberto = false;

                DateTime dataRealDevolucao = DateTime.Today;

                bool devolucaoAtrasada = dataRealDevolucao > dataDevolucao;

                if (devolucaoAtrasada)
                {
                    int diasAtrasados = (dataRealDevolucao - dataDevolucao).Days;

                    decimal valorMulta = 10 * diasAtrasados;

                    amigo.RegistrarMulta(valorMulta);
                }
            }
        }

        public override string ToString()
        {
            string statusEmprestimo = estaAberto ? "Aberto" : "Fechado";
            string emprestimo = (
          "\nNúmero: " + numero + "\nRevista emprestada: " + revista.Colecao + "\nNome do amigo: " + amigo.Nome +
          "\nData do empréstimo: " + dataEmprestimo + "\nStatus do empréstimo: " + statusEmprestimo);

            return emprestimo;

        }

    }
}
