using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoria;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class TelaCadastroRevista : TelaCadastroBase
    {
        private readonly TelaCadastroCategoria telaCadastroCategoria;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly TelaCadastroCaixa telaCadastroCaixa;
        private readonly RepositorioCaixa repositorioCaixa;

        public TelaCadastroRevista(
            TelaCadastroCategoria telaCadastroCategoria,
            RepositorioCategoria repositorioCategoria,
            TelaCadastroCaixa telaCadastroCaixa,
            RepositorioCaixa repositorioCaixa, RepositorioBase repositorio, Notificador notificador) : base(repositorio, notificador)
        {
            this.telaCadastroCategoria = telaCadastroCategoria;
            this.repositorioCategoria = repositorioCategoria;
            this.telaCadastroCaixa = telaCadastroCaixa;
            this.repositorioCaixa = repositorioCaixa;

        }

        public override void Inserir(string titulo)
        {
            MostrarTitulo(titulo);

            Caixa caixaSelecionada = ObtemCaixa();

            Categoria categoriaSelecionada = ObtemCategoria();

            if (caixaSelecionada == null || categoriaSelecionada == null)
            {
                notificador
                    .ApresentarMensagem("Cadastre uma caixa e uma categoria antes de cadastrar revistas!", TipoMensagem.Atencao);
                return;
            }

            Revista novaRevista = ObterEntidade();

            novaRevista.caixa = caixaSelecionada;
            novaRevista.categoria = categoriaSelecionada;

            RepositorioRevista repositorioRevista = (RepositorioRevista)repositorio;
            string statusValidacao = repositorioRevista.Inserir(novaRevista);

            if (statusValidacao != "REGISTRO_VALIDO")
                notificador.ApresentarMensagem(statusValidacao, TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Revista inserida com sucesso", TipoMensagem.Sucesso);
        }

        public override void Editar()
        {
            MostrarTitulo("Editando Revista");

            bool temRevistasCadastradas = Visualizar("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroEntidade();

            Console.WriteLine();
            
            Caixa caixaSelecionada = ObtemCaixa();

            Categoria categoriaSelecionada = ObtemCategoria();

            Revista revistaAtualizada = ObterEntidade();

            revistaAtualizada.caixa = caixaSelecionada;
            revistaAtualizada.categoria = categoriaSelecionada;

            repositorio.Editar(numeroRevista, revistaAtualizada);

            notificador.ApresentarMensagem("Revista editada com sucesso", TipoMensagem.Sucesso);
        }

        public override Revista ObterEntidade()
        {
            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("Digite a edição da revista: ");
            int edicao = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Revista novaRevista = new Revista(colecao, edicao, ano);

            return novaRevista;
        }

        private Categoria ObtemCategoria()
        {
            bool temCategoriasDisponiveis = telaCadastroCategoria.Visualizar("");

            if (!temCategoriasDisponiveis)
            {
                notificador.ApresentarMensagem("Você precisa cadastrar uma categoria antes de uma revista!", TipoMensagem.Atencao);
                return null;
            }

            Console.Write("Digite o número da categoria da revista: ");
            int numCategoriaSelecionada = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Categoria categoriaSelecionada = repositorioCategoria.SelecionarEntidade(numCategoriaSelecionada);

            return categoriaSelecionada;
        }

        private Caixa ObtemCaixa()
        {
            bool temCaixasDisponiveis = telaCadastroCaixa.Visualizar("");

            if (!temCaixasDisponiveis)
            {
                notificador.ApresentarMensagem("Não há nenhuma caixa disponível para cadastrar revistas", TipoMensagem.Atencao);
                return null;
            }

            Console.Write("Digite o número da caixa que irá inserir: ");
            int numCaixaSelecionada = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Caixa caixaSelecionada = repositorioCaixa.SelecionarEntidade(numCaixaSelecionada);

            return caixaSelecionada;
        }




    }
}
