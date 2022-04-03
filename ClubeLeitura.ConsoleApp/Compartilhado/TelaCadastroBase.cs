using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class TelaCadastroBase
    { 
        protected readonly Notificador notificador;
        protected readonly RepositorioBase repositorio;

        public  TelaCadastroBase(RepositorioBase repositorio, Notificador notificador)
        {
            this.repositorio = repositorio;
            this.notificador = notificador;
        }

        public virtual string MostrarOpcoes(string titulo)
        {
            Console.Clear();
            MostrarTitulo(titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void Inserir(string titulo)
        {
            MostrarTitulo(titulo);

            EntidadeBase novoRegistro = ObterEntidade();

            repositorio.Inserir(novoRegistro);

            notificador.ApresentarMensagem("Registro inserido com sucesso!", TipoMensagem.Sucesso);
        }

        public virtual void Editar()
        {
            MostrarTitulo("Editando");

            bool temRegistros = Visualizar("Pesquisando");

            if (temRegistros == false)
            {
                notificador.ApresentarMensagem("Nenhum registro para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numero = ObterNumeroEntidade();

            EntidadeBase registroAtualizado = ObterEntidade();

            repositorio.Editar(numero, registroAtualizado);

            notificador.ApresentarMensagem("Registro editado com sucesso", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Registro");

            bool temRegistro = Visualizar("Pesquisando");

            if (temRegistro == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum cadastrado para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroRegistro = ObterNumeroEntidade();

            repositorio.Excluir(numeroRegistro);

            notificador.ApresentarMensagem("Excluído com sucesso", TipoMensagem.Sucesso);
        }

        public virtual bool Visualizar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização");

            EntidadeBase[] entidade = repositorio.SelecionarTodos();

            if (entidade.Length == 0)
                return false;
            
            for(int i = 0; i < entidade.Length; i++)
            {
                EntidadeBase e = entidade[i];
                Console.WriteLine(e.ToString());
                Console.WriteLine();
            }

            return true;
        }

        public virtual EntidadeBase ObterEntidade()
        {
            
            EntidadeBase entidade = new EntidadeBase();

            return entidade;
        }

        public int ObterNumeroEntidade()
        {
            int numeroEntidade;
            bool numeroEntidadeEncontrado;

            do
            {
                Console.Write("Digite o número do registro: ");
                numeroEntidade = Convert.ToInt32(Console.ReadLine());

                numeroEntidadeEncontrado = repositorio.VerificarNumeroEntidadeExiste(numeroEntidade);

                if (numeroEntidadeEncontrado == false)
                    notificador.ApresentarMensagem("Número de registro não encontrado, " +
                        "digite novamente", TipoMensagem.Atencao);

            } while (numeroEntidadeEncontrado == false);
            return numeroEntidade;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}
