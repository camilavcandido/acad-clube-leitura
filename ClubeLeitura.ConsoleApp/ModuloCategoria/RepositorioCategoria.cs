using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloCategoria
{
    public class RepositorioCategoria : RepositorioBase
    {

        public RepositorioCategoria(int qtdCategorias) : base(qtdCategorias)
        {
        }

        public override Categoria[] SelecionarTodos()
        {
            int quantidadeCategorias = ObterQtdRegistros();

            Categoria[] categoriasInseridas = new Categoria[quantidadeCategorias];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    categoriasInseridas[j] = (Categoria)registros[i];
                    j++;
                }
            }

            return categoriasInseridas;
        }

        public override Categoria SelecionarEntidade(int numeroEntidade)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null &&
                    numeroEntidade == registros[i].numero)
                    return (Categoria)registros[i];
            }

            return null;
        }


    }
}
