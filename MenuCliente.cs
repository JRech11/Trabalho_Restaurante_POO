using System;
using System.Collections.Generic;

namespace Trabalho
{
    public class MenuCliente
    {
        DateTime agr;

        DateTime PegaHora(DateTime agr)
        {
            return agr = DateTime.Now;
        }
        DateTime ImprimiHora(DateTime agrr)
        {
            return agr;
        }

        public void ExibirMenu(Cliente clienteLogado, List<Item> cardapio, List<Pedido> pedidos, Ilingua l)
        {
            int opcao = 0;
            List<ItemPedido> itensPedido = new List<ItemPedido>();
            float totalPedido = 0;

            while (opcao != 4)
            {
                Console.WriteLine(l.MenuPrincipal());
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(l.ErroString());
                    continue;
                }

                if (opcao == 1)
                {
                    if (cardapio.Count == 0)
                    {
                        Console.WriteLine(l.CardapioVazio());
                    }
                    else
                    {
                        Console.WriteLine(l.TituloCardapio());
                        for (int i = 0; i < cardapio.Count; i++)
                        {
                            Item it = cardapio[i];
                            if (it != null && it.Oferecido == true)
                            {
                                Console.WriteLine(l.DetalheItem(it.Id, it.Nome, it.Categoria, it.Preco, it.Descricao));
                            }
                        }

                        Console.Write(l.DigiteIdItem());
                        int idEscolhido;
                        while (true)
                        {
                            try
                            {
                                idEscolhido = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine(l.ErroOP());
                            }
                        }
                        agr = DateTime.Now;

                        while (idEscolhido != 0)
                        {
                            Item itemEncontrado = null;
                            for (int i = 0; i < cardapio.Count; i++)
                            {
                                if (cardapio[i] != null && cardapio[i].Id == idEscolhido && cardapio[i].Oferecido == true)
                                {
                                    itemEncontrado = cardapio[i];
                                    PegaHora(agr);
                                    break;
                                }
                            }

                            if (itemEncontrado != null)
                            {
                                Console.Write(l.DigiteObservacao());
                                string obs = Console.ReadLine();

                                ItemPedido novoItemPedido = new ItemPedido
                                {
                                    Id = itensPedido.Count + 1,
                                    IdItemCardapio = itemEncontrado.Id,
                                    Nome = itemEncontrado.Nome,
                                    Preco = itemEncontrado.Preco,
                                    Categoria = itemEncontrado.Categoria,
                                    Observacao = obs
                                };

                                itensPedido.Add(novoItemPedido);
                                totalPedido = totalPedido + itemEncontrado.Preco;
                                Console.WriteLine(l.ItemAdicionado(itemEncontrado.Nome));
                            }
                            else
                            {
                                Console.WriteLine(l.ItemNaoEncontrado());
                            }
                            while (true)
                            {
                                try
                                {
                                    idEscolhido = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine(l.ErroOP());
                                }
                            }

                        }
                    }
                }
                else if (opcao == 2)
                {
                    Console.WriteLine(l.TituloPedido());
                    if (itensPedido.Count == 0)
                    {
                        Console.WriteLine(l.PedidoVazio());
                    }
                    else
                    {
                        for (int i = 0; i < itensPedido.Count; i++)
                        {
                            string obsTexto = string.IsNullOrEmpty(itensPedido[i].Observacao) ? "" : $" (Obs: {itensPedido[i].Observacao})";
                            Console.WriteLine($"- ID: {itensPedido[i].Id} | {itensPedido[i].Nome}{obsTexto}: R${itensPedido[i].Preco}");
                        }
                        Console.WriteLine(l.TotalAtual(totalPedido));

                        Console.Write(l.DigiteIdRemover());
                        int idRemover;
                        while (true)
                        {
                            try
                            {
                                idRemover = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine(l.ErroOP());
                            }
                        }

                        while (idRemover != 0)
                        {
                            ItemPedido itemParaRemover = null;
                            for (int i = 0; i < itensPedido.Count; i++)
                            {
                                if (itensPedido[i].Id == idRemover)
                                {
                                    itemParaRemover = itensPedido[i];
                                    break;
                                }
                            }

                            if (itemParaRemover != null)
                            {
                                itensPedido.Remove(itemParaRemover);
                                totalPedido = totalPedido - itemParaRemover.Preco;

                                for (int k = 0; k < itensPedido.Count; k++)
                                {
                                    itensPedido[k].Id = k + 1;
                                }

                                Console.WriteLine(l.ItemRemovido(itemParaRemover.Nome));
                            }
                            else
                            {
                                Console.WriteLine(l.ItemNaoEncontrado());
                            }

                            if (itensPedido.Count == 0)
                            {
                                Console.WriteLine(l.PedidoVazio());
                                break;
                            }

                            Console.Write(l.DigiteIdRemover());
                            while (true)
                            {
                                try
                                {
                                    idRemover = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine(l.ErroOP());
                                }
                            }
                        }
                    }
                    Console.WriteLine(ImprimiHora(agr));
                }
                else if (opcao == 3)
                {
                    if (itensPedido.Count == 0)
                    {
                        Console.WriteLine(l.PedidoVazioNaoFecha());
                    }
                    else
                    {
                        Console.WriteLine(l.ValorTotal(totalPedido));
                        Console.Write(l.DividirConta());
                        int numPessoas;
                        while (true)
                        {
                            try
                            {
                                numPessoas = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine(l.ErroOP());
                            }
                        }

                        if (numPessoas > 1)
                        {
                            float valorDividido = totalPedido / numPessoas;
                            Console.WriteLine(l.ValorPessoa(valorDividido));
                        }

                        Console.WriteLine(l.PedidoFechado());

                        Pedido novoPedido = new Pedido();

                        if (pedidos.Count == 0)
                        {
                            novoPedido.Id = 1;
                        }
                        else
                        {
                            novoPedido.Id = pedidos.Count + 1;
                        }

                        novoPedido.Cliente = clienteLogado;
                        novoPedido.Itens = itensPedido;
                        novoPedido.DataHoraSolicitacao = DateTime.Now;
                        novoPedido.ValorTotal = totalPedido;
                        novoPedido.Pago = true;

                        pedidos.Add(novoPedido);

                        
                        itensPedido = new List<ItemPedido>();
                        totalPedido = 0;
                        opcao = 4; 
                    }
                }
                else if (opcao == 4)
                {
                    // Apenas sai
                }
                else
                {
                    Console.WriteLine(l.ErroOP());
                }
            }
        }
    }
}