using System.Runtime.CompilerServices;

namespace Trabalho
{
    public interface Ilingua
    {
        string pNome();
        string BemVindo(string nome);
        string Prato_principal();
        string Bebida();
        string Sobremesa();
        string MenuPrincipal();
        string CardapioVazio();
        string TituloCardapio();
        string DetalheItem(int id, string nome, string categoria, float preco, string descricao);
        string DigiteIdItem();
        string ItemAdicionado(string nome);
        string DigiteIdRemover();
        string ItemRemovido(string nome);
        string ItemNaoEncontrado();
        string TituloPedido();
        string PedidoVazio();
        string TotalAtual(float total);
        string PedidoVazioNaoFecha();
        string ValorTotal(float total);
        string DividirConta();
        string ValorPessoa(float valor);
        string PedidoFechado();
        string ErroString();
        string ErroOP();
        string cadastro(string nome);
        public string email();
        string DigiteObservacao();
    }
}