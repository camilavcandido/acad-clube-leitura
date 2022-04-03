using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : RepositorioBase
    {

        public RepositorioRevista(int qtdRevistas) : base(qtdRevistas)
        {
        }
        public string Inserir(Revista revista)
        {
            string validacao = revista.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao;

            revista.numero = ++numeroIdentificador;

            int posicaoVazia = ObterPosicaoVazia();

            registros[posicaoVazia] = revista;

            return validacao;
        }

        
        
        public override Revista[] SelecionarTodos()
        {
            int quantidadeRevistas = ObterQtdRegistros();

            Revista[] revistasInseridas = new Revista[quantidadeRevistas];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    revistasInseridas[j] = (Revista)registros[i];
                    j++;
                }
            }

            return revistasInseridas;
        }

       
        
        public override Revista SelecionarEntidade(int numeroRevista)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    Revista revista = (Revista)registros[i];
                    if(numeroRevista == revista.numero)
                    {
                        return (Revista)registros[i];

                    }
                }
            }

            return null;
        }

    }
}