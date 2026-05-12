namespace Trabalho
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int IdItemCardapio { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Categoria { get; set; }
        public string Observacao { get; set; }
    }
}