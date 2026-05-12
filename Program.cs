using System;
using System.Collections.Generic;
using Trabalho;

Ilingua idioma;
MenuPT mPT = new MenuPT();
MenuEsp mES = new MenuEsp();
List<Item> cardapioPT = new List<Item>();
List<Item> cardapioESP = new List<Item>();
List<Pedido> pedidos = new List<Pedido>();
List<Cliente> clientes = new List<Cliente>();

// Mock de dados - Cardápio
cardapioPT.Add(new Item { Id = 1, Nome = "Hambúrguer", Categoria = "Prato principal", Descricao = "Pao, Carne e Queijo", Preco = 25.50f, Oferecido = true });
cardapioPT.Add(new Item { Id = 2, Nome = "Mousse de Maracuja", Categoria = "Sobremesa",Descricao = "Maracuja" ,Preco = 12.00f, Oferecido = true });
cardapioPT.Add(new Item { Id = 3, Nome = "Suco de Laranja", Categoria = "Bebida", Descricao = "Com açucar",Preco = 8.00f, Oferecido = true });

cardapioESP.Add(new Item { Id = 1, Nome = "Hamburguesa", Categoria = "Plato principal",Descricao = "Pan, Carne y Queso" ,Preco = 25.50f, Oferecido = true });
cardapioESP.Add(new Item { Id = 2, Nome = "Mousse de Maracuyá", Categoria = "Postre",Descricao = "Maracuyá" ,Preco = 12.00f, Oferecido = true });
cardapioESP.Add(new Item { Id = 3, Nome = "Jugo de Naranja", Categoria = "Bebida", Descricao = "Con azúcar", Preco = 8.00f, Oferecido = true });

// Mock de dados - Clientes
Cliente cli1 = new Cliente { Id = 1, Nome = "João", Email = "joao@email.com" };
Cliente cli2 = new Cliente { Id = 2, Nome = "Maria", Email = "maria@email.com" };
Cliente cli3 = new Cliente { Id = 3, Nome = "Carlos", Email = "carlos@email.com" };

clientes.Add(cli1);
clientes.Add(cli2);
clientes.Add(cli3);

// Mock de dados - Pedidos
Pedido ped1 = new Pedido {
    Id = 1,
    Cliente = cli1,
    DataHoraSolicitacao = DateTime.Now.AddDays(-2),
    Pago = true,
    Itens = new List<ItemPedido> {
        new ItemPedido { Id = 1, IdItemCardapio = 1, Nome = "Hambúrguer", Categoria = "Prato principal", Preco = 25.50f, Observacao = "Sem cebola" },
        new ItemPedido { Id = 2, IdItemCardapio = 3, Nome = "Suco de Laranja", Categoria = "Bebida", Preco = 8.00f, Observacao = "" }
    },
    ValorTotal = 33.50f
};

Pedido ped2 = new Pedido {
    Id = 2,
    Cliente = cli2,
    DataHoraSolicitacao = DateTime.Now.AddDays(-1),
    Pago = true,
    Itens = new List<ItemPedido> {
        new ItemPedido { Id = 1, IdItemCardapio = 2, Nome = "Mousse de Maracuja", Categoria = "Sobremesa", Preco = 12.00f, Observacao = "" }
    },
    ValorTotal = 12.00f
};

Pedido ped3 = new Pedido {
    Id = 3,
    Cliente = cli3,
    DataHoraSolicitacao = DateTime.Now.AddHours(-5),
    Pago = true,
    Itens = new List<ItemPedido> {
        new ItemPedido { Id = 1, IdItemCardapio = 1, Nome = "Hambúrguer", Categoria = "Prato principal", Preco = 25.50f, Observacao = "Bem passado" },
        new ItemPedido { Id = 2, IdItemCardapio = 1, Nome = "Hambúrguer", Categoria = "Prato principal", Preco = 25.50f, Observacao = "" },
        new ItemPedido { Id = 3, IdItemCardapio = 2, Nome = "Mousse de Maracuja", Categoria = "Sobremesa", Preco = 12.00f, Observacao = "" }
    },
    ValorTotal = 63.00f
};

Pedido ped4 = new Pedido {
    Id = 4,
    Cliente = cli1,
    DataHoraSolicitacao = DateTime.Now,
    Pago = true,
    Itens = new List<ItemPedido> {
        new ItemPedido { Id = 1, IdItemCardapio = 3, Nome = "Suco de Laranja", Categoria = "Bebida", Preco = 8.00f, Observacao = "Com gelo" }
    },
    ValorTotal = 8.00f
};

pedidos.Add(ped1);
pedidos.Add(ped2);
pedidos.Add(ped3);
pedidos.Add(ped4);

MenuADM adm = new MenuADM(cardapioPT, cardapioESP, pedidos, clientes);

int op = 1;

while (op != 0)
{
    bool val = false;

while (val == false)
{
    try
    {
        Console.WriteLine("Português/PT (1) | Español (2) | Sair (0): ");
        op = int.Parse(Console.ReadLine());

        if (op != 1 && op != 2 && op != 0 && op != 90210)
        {
            throw new Exception("Digite uma opção válida.");
        }

        val = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Digite um número.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
    if (op == 90210) // ADM
    {
        adm.ExibirMenu();
    }
    else if (op == 1 || op == 2)
    {
        MenuCliente menuCliente = new MenuCliente();

        if (op == 1)
        {
            idioma = mPT;
        }
        else
        {
            idioma = mES;
        }

        Console.WriteLine(idioma.pNome());
        string nome = Console.ReadLine();
        Cliente c = new Cliente();
        c.Nome = nome;

        val = false;

        while (val == false)
        {
            try
            {
                Console.WriteLine(idioma.cadastro(nome));
                int cad = int.Parse(Console.ReadLine());

                if (cad != 1 && cad != 2)
                {
                    throw new Exception(idioma.ErroOP());
                }
                if (cad == 1)
                {
                    Console.WriteLine(idioma.email());
                    c.Email = c.cadastro();
                    val = true;
                }
                if (cad == 2)
                {
                    val = true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(idioma.ErroString());

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        if (clientes.Count == 0)
            c.Id = 1;
        else
            c.Id = clientes.Count + 1;

        clientes.Add(c);

        Console.WriteLine(idioma.BemVindo(nome));

        try
        {
            if (op == 1)
                menuCliente.ExibirMenu(c, cardapioPT, pedidos, idioma);
            if (op == 2)
                menuCliente.ExibirMenu(c, cardapioESP, pedidos, idioma);
        }
        catch (Exception)
        {
            Console.WriteLine(idioma.ErroOP());
        }
    }
    else if (op == 0)
    {
        break;
    }
}