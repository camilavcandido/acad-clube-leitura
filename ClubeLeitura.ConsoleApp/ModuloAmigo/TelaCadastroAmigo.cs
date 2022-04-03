using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigo : TelaCadastroBase
    {
        public TelaCadastroAmigo(RepositorioBase repositorio, Notificador notificador) 
        : base(repositorio, notificador)
        {
        }

        public override string MostrarOpcoes(string titulo)
        {
            Console.Clear();

            MostrarTitulo(titulo);

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar Amigos com Multa");
            Console.WriteLine("Digite 6 para Pagar Multas");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public override Amigo ObterEntidade()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o número do telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite onde o amigo mora: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            return amigo;
        }

        public void PagarMulta()
        {
            MostrarTitulo("Pagamento de Multas");

            bool temAmigosComMulta = VisualizarAmigosComMulta("Pesquisando");

            if (!temAmigosComMulta)
            {
                notificador.ApresentarMensagem("Não há nenhum amigo com multas em aberto", TipoMensagem.Atencao);
                return;
            }

            int numeroAmigoComMulta = ObterNumeroEntidade();
           

            Amigo amigoComMulta = (Amigo)repositorio.SelecionarEntidade(numeroAmigoComMulta);

            amigoComMulta.PagarMulta();
        }

        public bool VisualizarAmigosComMulta(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos com Multa");

            RepositorioAmigo repositorioAmigo = (RepositorioAmigo)repositorio;

            Amigo[] amigos = repositorioAmigo.SelecionarAmigosComMulta();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine("Número: " + a.numero);
                Console.WriteLine("Nome: " + a.Nome);
                Console.WriteLine("Nome do responsável: " + a.NomeResponsavel);
                Console.WriteLine("Onde mora: " + a.Endereco);
                Console.WriteLine("Multa: R$" + a.multa.Valor);

                Console.WriteLine();
            }

            return true;
        }


    }
}