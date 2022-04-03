namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase
    {
        protected readonly EntidadeBase[] registros;
        protected int numeroIdentificador;

        public RepositorioBase(int qtdRegistros)
        {
            registros = new EntidadeBase[qtdRegistros];
        }

        public virtual void Inserir(EntidadeBase entidade)
        {
            entidade.numero = ++numeroIdentificador;

            int posicaoVazia = ObterPosicaoVazia();
            registros[posicaoVazia] = entidade;
        }

        public void Editar(int numeroSelecioando, EntidadeBase entidade)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].numero == numeroSelecioando)
                {
                    entidade.numero = numeroSelecioando;
                    registros[i] = entidade;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].numero == numeroSelecionado)
                {
                    registros[i] = null;
                    break;
                }
            }
        }

        public virtual EntidadeBase[] SelecionarTodos()
        {
            int quantidadeRegistros = ObterQtdRegistros();

            EntidadeBase[] registrosInseridos = new EntidadeBase[quantidadeRegistros];

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                    registrosInseridos[i] = registros[i];
            }

            return registrosInseridos;
        }

        public virtual EntidadeBase SelecionarEntidade(int numeroEntidade)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && numeroEntidade == registros[i].numero)
                    return registros[i];
            }

            return null;
        }

        public bool VerificarNumeroEntidadeExiste(int numeroEntidade)
        {
            bool numeroEntidadeEncontrado = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].numero == numeroEntidade)
                {
                    numeroEntidadeEncontrado = true;
                    break;
                }
            }
            return numeroEntidadeEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQtdRegistros()
        {
            int numeroRegistros = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                    numeroRegistros++;
            }

            return numeroRegistros;
        }
    }
}
