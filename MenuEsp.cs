namespace Trabalho
{

    public class MenuEsp : Ilingua
    {
        public string pNome()
        {
            return "Hola, ¿cómo te llamas?";
        }

        public string BemVindo(string nome)
        {
            return $"Bienvenido {nome}, ¿cuál es tu pedido?";
        }

        public string Prato_principal()
        {
            return "Por favor, elige el plato principal.";
        }

        public string Bebida()
        {
            return "Por favor, elige una bebida.";
        }

        public string Sobremesa()
        {
            return "Por favor, elige un postre.";
        }
        public string MenuPrincipal()
        {
            string menu = "";
            menu += "\n=== MENÚ DEL CLIENTE ===\n";
            menu += "1. Ver Menú y Añadir al Pedido\n";
            menu += "2. Ver Mi Pedido y Eliminar Artículos\n";
            menu += "3. Cerrar Pedido y Pagar\n";
            menu += "4. Salir\n";
            menu += "\nElige una opción: ";
            return menu;
        }

        public string CardapioVazio()
        {
            return "El menú está vacío en este momento.";
        }

        public string TituloCardapio()
        {
            return "\n--- MENÚ ---";
        }

        public string DetalheItem(int id, string nome, string categoria, float preco, string descricao)
        {
            return $"ID: {id} | {nome} - {descricao} - {categoria} - ${preco}";
        }

        public string DigiteIdItem()
        {
            return "\nIngresa el ID del artículo que deseas pedir (o 0 para cancelar): ";
        }

        public string ItemAdicionado(string nome)
        {
            return $"¡{nome} añadido al pedido!";
        }

        public string DigiteIdRemover()
        {
            return "\nIngresa el ID del artículo que deseas eliminar del pedido (o 0 para volver): ";
        }

        public string ItemRemovido(string nome)
        {
            return $"¡{nome} eliminado del pedido!";
        }

        public string ItemNaoEncontrado()
        {
            return "Artículo no encontrado.";
        }

        public string TituloPedido()
        {
            return "\n--- TU PEDIDO ---";
        }

        public string PedidoVazio()
        {
            return "Tu pedido está vacío.";
        }

        public string TotalAtual(float total)
        {
            return $"Total actual: ${total}";
        }

        public string PedidoVazioNaoFecha()
        {
            return "Tu pedido está vacío. No es posible cerrar.";
        }

        public string ValorTotal(float total)
        {
            return $"\nValor total: ${total}";
        }

        public string DividirConta()
        {
            return "¿Deseas dividir la cuenta entre cuántas personas? (Ingresa 1 si vas a pagar solo): ";
        }

        public string ValorPessoa(float valor)
        {
            return $"El valor para cada persona será: ${valor}";
        }

        public string PedidoFechado()
        {
            return "¡Pedido pagado y cerrado con éxito!";
        }

        public string ErroOP()
        {
            return "¡Opción inválida!";
        }
        public string ErroString()
        {
            return "Ingrese un valor númerico";
        }
        public string cadastro(string nome)
        {
            return ($"¿Desea realizar el registro {nome}? Sí (1) | No (2)");
        }
        public string email()
        {
            return "Ingrese su email";
        }
        public string DigiteObservacao()
        {
            return "¿Desea agregar alguna observación a este artículo? (Deje en blanco para ninguna): ";
        }
    }
}