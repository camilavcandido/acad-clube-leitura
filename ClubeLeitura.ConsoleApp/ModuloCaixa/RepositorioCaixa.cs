using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase
    {

        public RepositorioCaixa(int qtdCaixas) : base(qtdCaixas)
        {
        }

        public override Caixa[] SelecionarTodos()
        {
            int quantidadeCaixas = ObterQtdRegistros();

            Caixa[] caixasInseridas = new Caixa[quantidadeCaixas];

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                    caixasInseridas[i] = (Caixa)registros[i];
            }

            return caixasInseridas;
        }

        public override Caixa SelecionarEntidade(int numeroEntidade)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && numeroEntidade == registros[i].numero)
                    return (Caixa)registros[i];
            }

            return null;
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {

            bool etiquetaJaUtilizada = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null) {
                    Caixa caixa = (Caixa)registros[i];   
                    if(caixa.Etiqueta == etiquetaInformada)
                    {
                        etiquetaJaUtilizada = true;
                    }
                }

            }

            return etiquetaJaUtilizada;
        }

    }
}
