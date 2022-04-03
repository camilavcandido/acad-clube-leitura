using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCadastroCaixa : TelaCadastroBase
    {

        public TelaCadastroCaixa(RepositorioBase repositorio, Notificador notificador) : base(repositorio, notificador)
        {

        }

        public override Caixa ObterEntidade()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            bool etiquetaJaUtilizada;

            do
            {
                RepositorioCaixa repositorioCaixa = (RepositorioCaixa)repositorio;

                etiquetaJaUtilizada = repositorioCaixa.EtiquetaJaUtilizada(etiqueta);

                if (etiquetaJaUtilizada)
                {
                    notificador.ApresentarMensagem("Etiqueta já utilizada, por gentileza informe outra", TipoMensagem.Erro);

                    Console.Write("Digite a etiqueta: ");
                    etiqueta = Console.ReadLine();
                }

            } while (etiquetaJaUtilizada);

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
        }



    }
}