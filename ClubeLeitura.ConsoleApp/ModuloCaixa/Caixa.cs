using ClubeLeitura.ConsoleApp.Compartilhado;
namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
        private readonly string cor;
        private readonly string etiqueta;

        public string Cor => cor; //get 

        public string Etiqueta => etiqueta;

        public Caixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }

        public override string ToString()
        {
            string caixas = ("Numero: "+numero + "\nCor: " + cor + "\nEtiqueta: "+etiqueta);
            return caixas;
        }
    }
}
