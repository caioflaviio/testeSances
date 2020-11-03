using System;
using System.Collections.Generic;
using testeSances2;

namespace teste
{
    public class Program
    {
        public static List<Bebida> bebidas = new List<Bebida>();
        public static List<Carne> carnes = new List<Carne>();
        public static List<ItemPedido> listaItems = new List<ItemPedido>();
        public static List<Pedido> listaPedidos = new List<Pedido>();
        public static int codigoPedido = 1;

        public enum TipoPedido
        {
            Carne,
            Bebida
        }

        static void ApresentarMenuInicial()
        {
            DateTime thisDay = DateTime.Now;
            Console.WriteLine(thisDay.ToString());

            Console.WriteLine("Seja bem vindo!\n");

            Console.WriteLine("1 - Carta de bebidas");
            Console.WriteLine("2 - Carta de carnes");
            Console.WriteLine("3 - Lista de pedidos");
            Console.WriteLine("4 - Confirmar pedido");
            Console.WriteLine("5 - Cancelar pedido");
            Console.WriteLine("6 - Sair");
        }

        static void Main(string[] args)
        {
            Bebida.PreencherListaBebidas();
            Carne.PreencherListaCarnes();
            int escolha = 0;

            while (escolha != 6)
            {
                Console.Clear();
                ApresentarMenuInicial();
                escolha = int.Parse(Console.ReadLine());

                if (escolha == 1)
                    Bebida.ApresentarMenuBebidas();
                else if (escolha == 2)
                    Carne.ApresentarMenuCarnes();
                else if (escolha == 3)
                    ItemPedido.ApresentarItens();
                else if (escolha == 4)
                {
                    Pedido.ConfirmarPedido();
                    codigoPedido++;
                }
                else if (escolha == 5)
                {
                    Pedido.CancelarPedido();
                    codigoPedido++;
                }
            }
        }
    }
}