using System;
using teste;

namespace testeSances2
{
    public class Bebida
    {
        public Bebida(int codigo, string nome, double preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco; //askhaskda
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public static void ApresentarMenuBebidas()
        {
            Console.Clear();
            foreach (var bebida in Program.bebidas)
                Console.WriteLine(bebida.Codigo.ToString() + " - " + bebida.Nome + " - R$ " + bebida.Preco.ToString());

            Pedido.FazerEscolhaPedido(Program.TipoPedido.Bebida);
        }
        public static void PreencherListaBebidas()
        {
            Program.bebidas.Add(new Bebida(1, "Suco", 4));
            Program.bebidas.Add(new Bebida(2, "Refri", 5));
            Program.bebidas.Add(new Bebida(3, "Água", 3));
            Program.bebidas.Add(new Bebida(4, "Água de Coco", 5));
            Program.bebidas.Add(new Bebida(5, "Cerveja", 6));
        }
    }
}