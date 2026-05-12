namespace Trabalho
{
    public class MenuPT : Ilingua
    {
        public string pNome()
        {
            return "Olá, qual o seu nome ?";
        }
        public string BemVindo(string nome)
        {
            return $"Bem vindo {nome}, qual seu pedido.";
        }
        public string Prato_principal()
        {
            return "Por favor, escolha o prato principal.";
        }
        public string Bebida()
        {
            return "Por favor, escolha uma bebida.";
        }

        public string Sobremesa()
        {
            return "Por favor, escolha uma sobremesa.";
        }
        public string MenuPrincipal()
        {
            string menu = "";
            menu += "\n=== MENU CLIENTE ===\n";
            menu += "1. Ver Cardápio e Adicionar ao Pedido\n";
            menu += "2. Ver Meu Pedido e Remover Itens\n";
            menu += "3. Fechar Pedido e Pagar\n";
            menu += "4. Sair\n";
            menu += "\nEscolha uma opção: ";
            return menu;
        }

        public string CardapioVazio()
        {
            return "Cardápio vazio no momento.";
        }

        public string TituloCardapio()
        {
            return "\n--- CARDÁPIO ---";
        }

        public string DetalheItem(int id, string nome, string categoria, float preco, string descricao)
        {
            return $"ID: {id} | {nome} - {descricao} - {categoria} - R${preco}";
        }

        public string DigiteIdItem()
        {
            return "\nDigite o ID do item que deseja adicionar ao pedido (ou 0 para cancelar): ";
        }

        public string ItemAdicionado(string nome)
        {
            return $"{nome} adicionado ao pedido!";
        }

        public string DigiteIdRemover()
        {
            return "\nDigite o ID do item que deseja remover do pedido (ou 0 para voltar): ";
        }

        public string ItemRemovido(string nome)
        {
            return $"{nome} removido do pedido!";
        }

        public string ItemNaoEncontrado()
        {
            return "Item não encontrado.";
        }

        public string TituloPedido()
        {
            return "\n--- SEU PEDIDO ---";
        }

        public string PedidoVazio()
        {
            return "Seu pedido está vazio.";
        }

        public string TotalAtual(float total)
        {
            return $"Total atual: R${total}";
        }

        public string PedidoVazioNaoFecha()
        {
            return "Seu pedido está vazio. Não é possível fechar.";
        }

        public string ValorTotal(float total)
        {
            return $"\nValor total: R${total}";
        }

        public string DividirConta()
        {
            return "Deseja dividir a conta com quantas pessoas? (Digite 1 se for pagar sozinho): ";
        }

        public string ValorPessoa(float valor)
        {
            return $"O valor para cada pessoa será: R${valor}";
        }

        public string PedidoFechado()
        {
            return "Pedido pago e fechado com sucesso!";
        }

        public string OpcaoInvalida()
        {
            return "Opção inválida!";
        }
        public string ErroString()
        {
            return "Digite um número";
        }
        public string ErroOP()
        {
            return "Digite um valor válido.";
        }
        public string cadastro(string nome)
        {
            return $"Gostaria de realizar o cadastro {nome}? Sim (1) | Não (2)";
        }
        public string email()
        {
            return "Digite seu email";
        }
        public string fim()
        {
            return "Encerrando";
        }
        public string DigiteObservacao()
        {
            return "Deseja adicionar alguma observação a este item? (Deixe em branco para nenhuma): ";
        }
    }
}