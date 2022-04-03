using System;
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {

        public RepositorioAmigo(int qtdAmigos) : base(qtdAmigos)
        {
        
        }
    
        public override Amigo[] SelecionarTodos()
        {
            int quantidadeAmigos = ObterQtdRegistros();
            Amigo[] amigosInseridos = new Amigo[quantidadeAmigos];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    amigosInseridos[j] = (Amigo)registros[i];
                    j++;
                }
            }

            return amigosInseridos;
        }

        public override Amigo SelecionarEntidade(int numeroAmigo)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && numeroAmigo == registros[i].numero)
                    return (Amigo)registros[i];
            }

            return null;
        }

        public Amigo[] SelecionarAmigosComMulta()
        {
            Amigo[] amigosComMulta = new Amigo[ObterQtdAmigosComMulta()];

            int j = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    Amigo amigo = (Amigo)registros[i];
                    if (amigo.TemMultaEmAberto())
                    {
                        amigosComMulta[j] = (Amigo)registros[i];
                        j++;
                    }
                } 
            }

            return amigosComMulta;
        }


        private int ObterQtdAmigosComMulta()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    Amigo amigo = (Amigo)registros[i];
                    if (amigo.TemMultaEmAberto())
                    {
                        numeroAmigos++;
                    }
                }
            }

            return numeroAmigos;
        }

    }
}
