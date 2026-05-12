using System;
using System.Collections.Generic;

namespace Trabalho
{
    public class MenuADM
    {
        private enum Categoria
        {
            Entrada = 1,
            Bebida = 2,
            PratoPrincipal = 3,
            Sobremesa = 4
        }



        private List<Item> cardapioPT;
        private List<Item> cardapioESP;
        private List<Pedido> pedidos;
        private List<Cliente> clientes;
        private List<Item> CardapioEscolhido;

        public MenuADM(List<Item> cpt, List<Item> cesp, List<Pedido> p, List<Cliente> cli)
        {
            cardapioPT = cpt;
            cardapioESP = cesp;
            pedidos = p;
            clientes = cli;
        }

         private void ImprimirDetalhesPedido(Pedido p)
        {
            string nomeCliente = "Desconhecido";
            if (p.Cliente != null)
            {
                nomeCliente = p.Cliente.Nome;
            }

            Console.WriteLine($"\nPedido ID: {p.Id} | Cliente: {nomeCliente} | Data: {p.DataHoraSolicitacao}");
            Console.WriteLine("Itens:");

            if (p.Itens != null)
            {
                for (int j = 0; j < p.Itens.Count; j++)
                {
                    string obsTexto = string.IsNullOrEmpty(p.Itens[j].Observacao) ? "" : $" (Obs: {p.Itens[j].Observacao})";
                    Console.WriteLine($"  - {p.Itens[j].Nome}{obsTexto}: R${p.Itens[j].Preco:F2}");
                }
            }
            Console.WriteLine($"Total Pago: R${p.ValorTotal:F2}");
        }

        public void ExibirMenu()
        {
            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("\n=== MENU ADMINISTRATIVO ===");
                Console.WriteLine("1. Adicionar Prato");
                Console.WriteLine("2. Excluir Prato");
                Console.WriteLine("3. Editar Prato");
                Console.WriteLine("4. Relatórios");
                Console.WriteLine("5. Sair");
                Console.Write("\nEscolha uma opção: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Opção inválida! Digite um número inteiro: ");
                    continue;
                }

                if (opcao == 1)
                {
                    AdicionarPrato();
                }
                else if (opcao == 2)
                {
                    ExcluirPrato();
                }
                else if (opcao == 3)
                {
                    EditarPrato();
                }
                else if (opcao == 4)
                {
                    EmitirRelatorio();
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("Saindo do menu administrativo...");
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
            }
        }

        public void AdicionarPrato()
        {
            Console.WriteLine("\n--- ADICIONAR PRATO ---");
            Console.WriteLine("Escolha o cardápio: (1) Português (2) Español (0) Sair");
            bool op = false;
            while (op == false)
            {
                try
                {
                    int opMenu = int.Parse(Console.ReadLine());

                    if (opMenu == 1)
                    {
                        CardapioEscolhido = cardapioPT;
                        op = true;
                    }
                    else if (opMenu == 2)
                    {
                        CardapioEscolhido = cardapioESP;
                        op = true;
                    }
                    else if (opMenu == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! Escolha 1, 2 ou 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Digite um número.");
                }
            }
            Item novoItem = new Item();
            bool isPT = CardapioEscolhido == cardapioPT;

            Console.Write("Nome do prato: ");
            novoItem.Nome = Console.ReadLine();

            Console.Write("Descrição: ");
            novoItem.Descricao = Console.ReadLine();

            Console.Write("Preço: ");
            float precoAdicionar;

            while (true)
            {
                try
                {
                    precoAdicionar = float.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido! Digite um número.");
                    Console.Write("Preço: ");
                }
            }
            novoItem.Preco = precoAdicionar;

            Console.WriteLine("Categorias disponíveis:");
            Console.WriteLine("1 - Entrada");
            Console.WriteLine("2 - Bebida");
            Console.WriteLine("3 - Prato Principal");
            Console.WriteLine("4 - Sobremesa");
            Console.Write("Escolha a categoria (1-4): ");

            while (true)
            {
                try
                {
                    int opCategoria = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(Categoria), opCategoria))
                    {
                        Categoria cat = (Categoria)opCategoria;
                        if (isPT)
                        {
                            if (cat == Categoria.PratoPrincipal)
                                novoItem.Categoria = "Prato Principal";
                            else
                                novoItem.Categoria = cat.ToString();
                        }
                        else
                        {
                            if (cat == Categoria.Entrada) novoItem.Categoria = "Entrada";
                            else if (cat == Categoria.Bebida) novoItem.Categoria = "Bebida";
                            else if (cat == Categoria.PratoPrincipal) novoItem.Categoria = "Plato Principal";
                            else if (cat == Categoria.Sobremesa) novoItem.Categoria = "Postre";
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! Escolha um número de 1 a 4.");
                        Console.Write("Escolha a categoria (1-4): ");
                    }
                }
                catch
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro.");
                    Console.Write("Escolha a categoria (1-4): ");
                }
            }

            novoItem.Oferecido = true;

            if (CardapioEscolhido.Count == 0)
            {
                novoItem.Id = 1;
            }
            else
            {
                novoItem.Id = CardapioEscolhido.Count + 1;
            }
            CardapioEscolhido.Add(novoItem);

            Console.WriteLine("Prato adicionado com sucesso!");
        }

        private void ExcluirPrato()
        {
            Console.WriteLine("\n--- EXCLUIR PRATO ---");
            Console.WriteLine("Escolha o cardápio: (1) Português (2) Español (0) Sair");
            bool op = false;
            while (op == false)
            {
                try
                {
                    int opMenu = int.Parse(Console.ReadLine());

                    if (opMenu == 1)
                    {
                        CardapioEscolhido = cardapioPT;
                        op = true;
                    }
                    else if (opMenu == 2)
                    {
                        CardapioEscolhido = cardapioESP;
                        op = true;
                    }
                    else if (opMenu == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! Escolha 1, 2 ou 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite um número válido.");
                }
            }

            if (CardapioEscolhido.Count == 0)
            {
                Console.WriteLine("Não há pratos cadastrados neste cardápio.");
                return;
            }

            Console.WriteLine("\n--- PRATOS CADASTRADOS ---");
            bool temPratos = false;
            for (int i = 0; i < CardapioEscolhido.Count; i++)
            {
                if (CardapioEscolhido[i].Oferecido)
                {
                    Console.WriteLine($"ID: {CardapioEscolhido[i].Id} - {CardapioEscolhido[i].Nome}");
                    temPratos = true;
                }
            }

            if (!temPratos)
            {
                Console.WriteLine("Não há pratos ativos cadastrados neste cardápio.");
                return;
            }

            Console.Write("\nID do prato a excluir (0 para sair): ");
            int idExcluir;
            while (true)
            {
                try
                {
                    idExcluir = int.Parse(Console.ReadLine());
                    if (idExcluir == 0) return;
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro.");
                    Console.Write("ID do prato a excluir (0 para sair): ");
                }
            }

            int indexEncontrado = -1;

            for (int i = 0; i < CardapioEscolhido.Count; i++)
            {
                if (CardapioEscolhido[i].Id == idExcluir && CardapioEscolhido[i].Oferecido)
                {
                    indexEncontrado = i;
                    break;
                }
            }

            if (indexEncontrado != -1)
            {
                CardapioEscolhido[indexEncontrado].Oferecido = false;
                Console.WriteLine("Prato desativado (excluído logicamente) com sucesso!");
            }
            else
            {
                Console.WriteLine("Prato não encontrado ou já inativo.");
            }
        }

        private void EditarPrato()
        {
            Console.WriteLine("\n--- EDITAR PRATO ---");
            Console.WriteLine("Escolha o cardápio: (1) Português (2) Español (0) Sair");

            bool op = false;
            while (op == false)
            {
                try
                {
                    int opMenu = int.Parse(Console.ReadLine());

                    if (opMenu == 1)
                    {
                        CardapioEscolhido = cardapioPT;
                        op = true;
                    }
                    else if (opMenu == 2)
                    {
                        CardapioEscolhido = cardapioESP;
                        op = true;
                    }
                    else if (opMenu == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! Escolha 1, 2 ou 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite um número válido.");
                }
            }

            if (CardapioEscolhido.Count == 0)
            {
                Console.WriteLine("Não há pratos cadastrados neste cardápio.");
                return;
            }

            Console.WriteLine("\n--- PRATOS CADASTRADOS ---");
            bool temPratos = false;
            for (int i = 0; i < CardapioEscolhido.Count; i++)
            {
                if (CardapioEscolhido[i].Oferecido)
                {
                    Console.WriteLine($"ID: {CardapioEscolhido[i].Id} - {CardapioEscolhido[i].Nome}");
                    temPratos = true;
                }
            }

            if (!temPratos)
            {
                Console.WriteLine("Não há pratos ativos cadastrados neste cardápio.");
                return;
            }

            Console.Write("\nID do prato a editar (0 para sair): ");
            int idEditar;
            while (true)
            {
                try
                {
                    idEditar = int.Parse(Console.ReadLine());
                    if (idEditar == 0) return;
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro.");
                    Console.Write("ID do prato a editar (0 para sair): ");
                }
            }

            Item prato = null;

            for (int i = 0; i < CardapioEscolhido.Count; i++)
            {
                if (CardapioEscolhido[i].Id == idEditar && CardapioEscolhido[i].Oferecido)
                {
                    prato = CardapioEscolhido[i];
                    break;
                }
            }

            if (prato != null)
            {
                Console.Write("Novo nome (deixe vazio para não alterar): ");
                string novoNome = Console.ReadLine();
                if (novoNome != "")
                {
                    prato.Nome = novoNome;
                }

                Console.Write("Nova descrição (deixe vazio para não alterar): ");
                string novaDescricao = Console.ReadLine();
                if (novaDescricao != "")
                {
                    prato.Descricao = novaDescricao;
                }

                Console.Write("Novo preço (0 para não alterar): ");
                float novoPreco;
                while (true)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            novoPreco = 0;
                            break;
                        }
                        novoPreco = float.Parse(input);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Valor inválido! Digite um número.");
                        Console.Write("Novo preço (0 para não alterar): ");
                    }
                }
                if (novoPreco > 0)
                {
                    prato.Preco = novoPreco;
                }

                Console.WriteLine("Prato editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Prato não encontrado ou inativo.");
            }
        }

        private void EmitirRelatorio()
        {
            int op = 0;
            while (op != 6)
            {
                Console.WriteLine("\n--- RELATÓRIOS ---");
                Console.WriteLine("1. Todos os Pedidos");
                Console.WriteLine("2. Por Período");
                Console.WriteLine("3. Por Cliente Específico");
                Console.WriteLine("4. Por Cliente em um Período");
                Console.WriteLine("5. Consumo de Item Específico");
                Console.WriteLine("6. Voltar");
                Console.Write("Opção: ");

                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Opção inválida! Digite um número inteiro.");
                    continue;
                }

                if (op == 1)
                {
                    RelatorioTodosPedidos();
                }
                else if (op == 2)
                {
                    RelatorioPorPeriodo();
                }
                else if (op == 3)
                {
                    RelatorioPorCliente();
                }
                else if (op == 4)
                {
                    RelatorioPorClienteEPeriodo();
                }
                else if (op == 5)
                {
                    RelatorioPorItem();
                }
            }
        }

        private void RelatorioTodosPedidos()
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido registrado.");
                return;
            }

            Console.WriteLine("\n--- RELATÓRIO DE PEDIDOS ---");
            float totalArrecadado = 0;

            for (int i = 0; i < pedidos.Count; i++)
            {
                ImprimirDetalhesPedido(pedidos[i]);
                totalArrecadado += pedidos[i].ValorTotal;
            }
            Console.WriteLine($"\nFaturamento Total: R${totalArrecadado:F2}");
        }

        private void RelatorioPorPeriodo()
        {
            Console.Write("Data Inicial (dd/MM/yyyy) ou '0' para sair: ");
            DateTime dataInicial;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0") return;
                try
                {
                    dataInicial = DateTime.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Data inválida.");
                    Console.Write("Data Inicial (dd/MM/yyyy) ou '0' para sair: ");
                }
            }

            Console.Write("Data Final (dd/MM/yyyy) ou '0' para sair: ");
            DateTime dataFinal;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0") return;
                try
                {
                    dataFinal = DateTime.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Data inválida.");
                    Console.Write("Data Final (dd/MM/yyyy) ou '0' para sair: ");
                }
            }

            dataFinal = dataFinal.Date.AddDays(1).AddTicks(-1); // Formata para pegar o relatório correto;

            Console.WriteLine($"\n--- RELATÓRIO POR PERÍODO ({dataInicial:dd/MM/yyyy} a {dataFinal:dd/MM/yyyy}) ---");
            float totalArrecadado = 0;
            int count = 0;

            for (int i = 0; i < pedidos.Count; i++)
            {
                if (pedidos[i].DataHoraSolicitacao >= dataInicial && pedidos[i].DataHoraSolicitacao <= dataFinal)
                {
                    ImprimirDetalhesPedido(pedidos[i]);
                    totalArrecadado += pedidos[i].ValorTotal;
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado neste período.");
            }
            else
            {
                Console.WriteLine($"\nFaturamento Total no Período: R${totalArrecadado:F2}");
            }
        }

        private void RelatorioPorCliente()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("\n--- CLIENTES CADASTRADOS ---");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"ID: {clientes[i].Id} | Nome: {clientes[i].Nome}");
            }

            Console.Write("\nDigite o ID do cliente (0 para sair): ");
            int idCliente;
            while (true)
            {
                try
                {
                    idCliente = int.Parse(Console.ReadLine());
                    if (idCliente == 0) return;
                    if (idCliente < 0 || idCliente > clientes.Count)
                    {
                        Console.WriteLine("ID inválido. Cliente não encontrado.");
                        Console.Write("\nDigite o ID do cliente (0 para sair): ");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("ID inválido.");
                    Console.Write("\nDigite o ID do cliente (0 para sair): ");
                }
            }

            Console.WriteLine($"\n--- RELATÓRIO DO CLIENTE ID {idCliente} ---");
            float totalArrecadado = 0;
            int count = 0;

            for (int i = 0; i < pedidos.Count; i++)
            {
                if (pedidos[i].Cliente != null && pedidos[i].Cliente.Id == idCliente)
                {
                    ImprimirDetalhesPedido(pedidos[i]);
                    totalArrecadado += pedidos[i].ValorTotal;
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado para este cliente.");
            }
            else
            {
                Console.WriteLine($"\nTotal Gasto pelo Cliente: R${totalArrecadado:F2}");
            }
        }

        private void RelatorioPorClienteEPeriodo()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("\n--- CLIENTES CADASTRADOS ---");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"ID: {clientes[i].Id} | Nome: {clientes[i].Nome}");
            }

            Console.Write("\nDigite o ID do cliente (0 para sair): ");
            int idCliente;
            while (true)
            {
                try
                {
                    idCliente = int.Parse(Console.ReadLine());
                    if (idCliente == 0) return;
                    if (idCliente < 0 || idCliente > clientes.Count)
                    {
                        Console.WriteLine("ID inválido. Cliente não encontrado.");
                        Console.Write("\nDigite o ID do cliente (0 para sair): ");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("ID inválido.");
                    Console.Write("\nDigite o ID do cliente (0 para sair): ");
                }
            }

            Console.Write("Data Inicial (dd/MM/yyyy) ou '0' para sair: ");
            DateTime dataInicial;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0") return;
                try
                {
                    dataInicial = DateTime.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Data inválida.");
                    Console.Write("Data Inicial (dd/MM/yyyy) ou '0' para sair: ");
                }
            }

            Console.Write("Data Final (dd/MM/yyyy) ou '0' para sair: ");
            DateTime dataFinal;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0") return;
                try
                {
                    dataFinal = DateTime.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Data inválida.");
                    Console.Write("Data Final (dd/MM/yyyy) ou '0' para sair: ");
                }
            }

            dataFinal = dataFinal.Date.AddDays(1).AddTicks(-1);

            Console.WriteLine($"\n--- RELATÓRIO DO CLIENTE ID {idCliente} NO PERÍODO ---");
            float totalArrecadado = 0;
            int count = 0;

            for (int i = 0; i < pedidos.Count; i++)
            {
                if (pedidos[i].Cliente != null && pedidos[i].Cliente.Id == idCliente)
                {
                    if (pedidos[i].DataHoraSolicitacao >= dataInicial && pedidos[i].DataHoraSolicitacao <= dataFinal)
                    {
                        ImprimirDetalhesPedido(pedidos[i]);
                        totalArrecadado += pedidos[i].ValorTotal;
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado para este cliente no período informado.");
            }
            else
            {
                Console.WriteLine($"\nTotal Gasto no Período: R${totalArrecadado:F2}");
            }
        }

        private void RelatorioPorItem()
        {
            Console.WriteLine("\n--- RELATÓRIO DE CONSUMO POR ITEM ---");
            
            if (cardapioPT.Count == 0 && cardapioESP.Count == 0)
            {
                Console.WriteLine("Não há itens cadastrados nos cardápios.");
                return;
            }

            Console.WriteLine("Escolha o cardápio para visualizar os itens: (1) Português (2) Español (0) Sair");
            List<Item> cardapioRelatorio = null;
            while (true)
            {
                try
                {
                    int opMenu = int.Parse(Console.ReadLine());
                    if (opMenu == 1) { cardapioRelatorio = cardapioPT; break; }
                    else if (opMenu == 2) { cardapioRelatorio = cardapioESP; break; }
                    else if (opMenu == 0) return;
                    else Console.WriteLine("Opção inválida! Escolha 1, 2 ou 0.");
                }
                catch
                {
                    Console.WriteLine("Digite um número válido.");
                }
            }

            Console.WriteLine("\n--- ITENS CADASTRADOS ---");
            for (int i = 0; i < cardapioRelatorio.Count; i++)
            {
                if (cardapioRelatorio[i].Oferecido)
                {
                    Console.WriteLine($"ID: {cardapioRelatorio[i].Id} - {cardapioRelatorio[i].Nome}");
                }
            }

            Console.Write("\nDigite o ID do item (0 para sair): ");
            int idBusca;
            while (true)
            {
                try
                {
                    idBusca = int.Parse(Console.ReadLine());
                    if (idBusca == 0) return;
                    if (idBusca < 0 || idBusca > cardapioRelatorio.Count)
                    {
                        Console.WriteLine("ID inválido. Item não encontrado.");
                        Console.Write("\nDigite o ID do item (0 para sair): ");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro.");
                    Console.Write("\nDigite o ID do item (0 para sair): ");
                }
            }

            string buscaItem = idBusca.ToString();

            int countPedidos = 0;
            int quantidadeConsumida = 0;

            Console.WriteLine($"\nPedidos que contêm o item '{buscaItem}':");

            for (int i = 0; i < pedidos.Count; i++)
            {
                Pedido p = pedidos[i];
                if (p.Itens != null)
                {
                    int qtdNoPedido = 0;
                    bool encontrou = false;
                    for (int j = 0; j < p.Itens.Count; j++)
                    {
                        ItemPedido item = p.Itens[j];
                        if (item.IdItemCardapio.ToString() == buscaItem || (item.Nome != null && item.Nome.ToLower().Contains(buscaItem)))
                        {
                            encontrou = true;
                            qtdNoPedido++;
                            quantidadeConsumida++;
                        }
                    }

                    if (encontrou)
                    {
                        string nomeCliente = p.Cliente != null ? p.Cliente.Nome : "Desconhecido";
                        Console.WriteLine($"  - Pedido ID: {p.Id} | Cliente: {nomeCliente} | Data: {p.DataHoraSolicitacao} | Quantidade no pedido: {qtdNoPedido}");
                        countPedidos++;
                    }
                }
            }

            if (countPedidos == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado com este item.");
            }
            else
            {
                Console.WriteLine($"\nResumo: O item esteve presente em {countPedidos} pedido(s), totalizando {quantidadeConsumida} unidade(s) consumida(s).");
            }
        }

       
    }
}