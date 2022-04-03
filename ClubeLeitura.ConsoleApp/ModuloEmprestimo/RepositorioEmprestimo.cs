using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase
    {
        public RepositorioEmprestimo(int qtdEmprestimos) : base(qtdEmprestimos)
        {
        }

        public override void Inserir(EntidadeBase entidade)
        {
            Emprestimo emprestimo = (Emprestimo)entidade;

            emprestimo.numero = ++numeroIdentificador;

            emprestimo.Abrir();

            emprestimo.revista.RegistrarEmprestimo(emprestimo);
            emprestimo.amigo.RegistrarEmprestimo(emprestimo);

            registros[ObterPosicaoVazia()] = emprestimo;
        }
        public override Emprestimo[] SelecionarTodos()
        {
            int quantidadeEmprestimos = ObterQtdRegistros();

            Emprestimo[] emprestimosInseridos = new Emprestimo[quantidadeEmprestimos];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    emprestimosInseridos[j] = (Emprestimo)registros[i];
                    j++;
                }
            }

            return emprestimosInseridos;
        }
        public override Emprestimo SelecionarEntidade(int numeroEmprestimo)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && numeroEmprestimo == registros[i].numero)
                    return (Emprestimo)registros[i];
            }

            return null;
        }     
        public Emprestimo[] SelecionarEmprestimosAbertos()
        {
            Emprestimo[] emprestimosAbertos = new Emprestimo[ObterQtdEmprestimosAbertos()];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    Emprestimo emprestimo = (Emprestimo)registros[i];
                    if (emprestimo.estaAberto)
                    {
                        emprestimosAbertos[j] = (Emprestimo)registros[i];
                        j++;
                    }
                }
            }

            return emprestimosAbertos;
        }
        public bool RegistrarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.Fechar();

            return true;
        }
        private int ObterQtdEmprestimosAbertos()
        {
            int numeroEmprestimos = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null) {
                    Emprestimo emprestimo = (Emprestimo)registros[i];
                    if (emprestimo.estaAberto)
                    {
                        numeroEmprestimos++;

                    }
                }
            }

            return numeroEmprestimos;
        }

    }
}
