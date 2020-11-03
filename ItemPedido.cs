using System;
using teste;

namespace testeSances2
{
    public class ItemPedido
    {
        public ItemPedido(int codigoItem, int codigoPedido, string nome, double precoUnitario, int quantidade)
        {
            CodigoItem = codigoItem;
            CodigoPedido = codigoPedido;
            Nome = nome;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }

        public int CodigoItem { get; set; }
        public int CodigoPedido { get; set; }
        public string Nome { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public double Desconto { get; set; }

        public static void ApresentarItens()
        {
            Console.Clear();

            foreach (var pedido in Program.listaPedidos)
            {
                double valorTotal = 0;
                Console.WriteLine("\nPedido: " + pedido.Descricao.ToString() + " Situação: " + pedido.Situacao.ToString() + "\n");

                foreach (var itemPedido in Program.listaItems)
                {
                    if (itemPedido.CodigoPedido == pedido.Codigo)
                    {
                        Console.WriteLine(itemPedido.Nome + " - R$ " + itemPedido.PrecoUnitario + " - X" + itemPedido.Quantidade.ToString());
                        valorTotal += itemPedido.PrecoUnitario * itemPedido.Quantidade;
                    }
                }

                Console.WriteLine("\nValor total do pedido" + pedido.Descricao + ": R$ " + (pedido.Situacao == "Aprovado" ? pedido.ValorTotal.ToString() : valorTotal.ToString()));
                Console.WriteLine("_____________________________________________________\n");
            }

            Console.ReadLine();
        }
    }
}