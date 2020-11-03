using System;
using teste;

namespace testeSances2
{
    public class Carne
    {
        public Carne(int codigo, string nome, double preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public static void ApresentarMenuCarnes()
        {
            Console.Clear();
            int x = 1;
            foreach (var item in Program.carnes)
            {
                Console.WriteLine(item.Codigo.ToString() + " - " + item.Nome + " - R$ " + item.Preco.ToString());
                x++;
            }

            Pedido.FazerEscolhaPedido(Program.TipoPedido.Carne);
        }

        public static void PreencherListaCarnes()
        {
            Program.carnes.Add(new Carne(6, "Entrecot", 50));
            Program.carnes.Add(new Carne(7, "Picanha", 80));
            Program.carnes.Add(new Carne(8, "Costela", 70));
            Program.carnes.Add(new Carne(9, "Prime Rib", 60));
            Program.carnes.Add(new Carne(10, "Fraldinha", 50));
        }
    }
}