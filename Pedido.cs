using System;
using System.Collections.Generic;
namespace Trabalho
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
        public float ValorTotal { get; set; }
        public bool Pago { get; set; }
        public string Observacao { get; set; }
    }
}
