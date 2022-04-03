using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class RepositorioReserva : RepositorioBase
    {

        public RepositorioReserva(int qtdReservas) : base(qtdReservas)
        {
        }

        public override void Inserir(EntidadeBase entidade)
        {
            Reserva reserva = (Reserva)entidade;
            reserva.numero = ++numeroIdentificador;

            reserva.Abrir();
            reserva.revista.RegistrarReserva(reserva);
            reserva.amigo.RegistrarReserva(reserva);

            registros[ObterPosicaoVazia()] = reserva;
        }

        public override Reserva[] SelecionarTodos()
        {
            Reserva[] reservasInseridas = new Reserva[ObterQtdRegistros()];

            int j = 0;

            for (int i = 0; i < reservasInseridas.Length; i++)
            {
                if (registros[i] != null)
                {
                    reservasInseridas[j] = (Reserva)registros[i];
                    j++;
                }
            }

            return reservasInseridas;
        }

        public override Reserva SelecionarEntidade(int numeroReserva)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && numeroReserva == registros[i].numero)
                    return (Reserva)registros[i];
            }

            return null;
        }

        public Reserva[] SelecionarReservasEmAberto()
        {
            Reserva[] reservasInseridas = new Reserva[ObterQtdReservasEmAberto()];

            int j = 0;

            for (int i = 0; i < reservasInseridas.Length; i++)
            {
                if (registros[i] != null) {
                    Reserva reserva = (Reserva)registros[i];
                    if (reserva.estaAberta)
                    {
                        reservasInseridas[j] = (Reserva)registros[i];
                        j++;
                    }
                }
            }

            return reservasInseridas;
        }

        private int ObterQtdReservasEmAberto()
        {
            int numeroReservas = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    Reserva reserva = (Reserva)registros[i];
                    if (reserva.estaAberta)
                    {
                        numeroReservas++;
                    }
                } 
            }

            return numeroReservas;
        }


    }
}
