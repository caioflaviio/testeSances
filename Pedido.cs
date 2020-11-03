using System;
using System.Linq;
using teste;

namespace testeSances2
{
    public class Pedido
    {
        public int Codigo;
        public DateTime Data;
        public string Descricao;
        public string Situacao;
        public double ValorTotal;

        public Pedido(int codigo, DateTime data, string descricao, string situacao, double valorTotal)
        {
            Codigo = codigo;
            Data = data;
            Descricao = descricao;
            Situacao = situacao;
            ValorTotal = valorTotal;
        }

        public static void CriarNovoPedido(int codigoPedido)
        {
            Pedido novoPedido = new Pedido(codigoPedido, DateTime.Now, "Pedido de número " + codigoPedido.ToString(), "Em análise", 0);
            Program.listaPedidos.Add(novoPedido);
        }

        public static void FazerEscolhaPedido(Program.TipoPedido tipo)
        {
            int escolha = 0;
            Console.WriteLine("\nInforme o código para o pedido ou 0 para sair: ");
            escolha = int.Parse(Console.ReadLine());

            if (escolha != 0)
            {
                foreach (var pedido in Program.listaPedidos)
                {
                    if (Program.codigoPedido == pedido.Codigo)
                    {
                        foreach (var item in Program.listaItems)
                        {
                            if (item.CodigoItem == escolha)
                            {
                                Console.WriteLine("\nItem já adicionado no pedido.");
                                Console.ReadLine();
                                return;
                            }
                        }
                    }
                }

                Console.WriteLine("\nInforme a quantidade do item: ");
                int quantidade = 0;
                quantidade = int.Parse(Console.ReadLine());

                //se a mesma tem mais do q ZERO pedidos   - verifica se o ultimo é diferente de nulo e se a situação é diferente de "Em analise"
                if (Program.listaPedidos.Count > 0 && Program.listaPedidos.Last().Situacao != "Em análise")
                    CriarNovoPedido(Program.codigoPedido);
                else if (Program.listaPedidos.Count == 0)
                    CriarNovoPedido(Program.codigoPedido);

                if (tipo == Program.TipoPedido.Carne)
                    foreach (var carne in Program.carnes)
                        if (escolha == carne.Codigo)
                            Program.listaItems.Add(new ItemPedido(carne.Codigo, Program.codigoPedido, carne.Nome, carne.Preco, quantidade));
                if (tipo == Program.TipoPedido.Bebida)
                    foreach (var bebida in Program.bebidas)
                        if (escolha == bebida.Codigo)
                            Program.listaItems.Add(new ItemPedido(bebida.Codigo, Program.codigoPedido, bebida.Nome, bebida.Preco, quantidade));
            }
        }

        public static void ConfirmarPedido()
        {
            foreach (var pedido in Program.listaPedidos)
                if (pedido.Codigo == Program.codigoPedido)
                    pedido.Situacao = "Aprovado";

            int formaPagamento = 0;
            Console.WriteLine("\nInforme a forma de pagamento (Cartão (1) | Dinheiro (2)):");
            formaPagamento = int.Parse(Console.ReadLine());

            SomarValoresItems(Program.codigoPedido);

            if (formaPagamento == 2)
                AplicarDesconto();
        }

        private static void SomarValoresItems(int codigoPedido)
        {
            foreach (var pedido in Program.listaPedidos)
                if (pedido.Codigo == codigoPedido)
                    foreach (var item in Program.listaItems)
                        if (item.CodigoPedido == codigoPedido)
                            pedido.ValorTotal += item.PrecoUnitario * item.Quantidade;
        }

        private static void AplicarDesconto()
        {
            foreach (var pedido in Program.listaPedidos)
                if (pedido.Codigo == Program.codigoPedido)
                    pedido.ValorTotal = pedido.ValorTotal * 0.9;
        }

        public static void CancelarPedido()
        {
            foreach (var pedido in Program.listaPedidos)
                if (pedido.Codigo == Program.codigoPedido)
                    pedido.Situacao = "Cancelado";
        }
    }
}