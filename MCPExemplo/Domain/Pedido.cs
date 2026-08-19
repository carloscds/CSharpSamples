namespace MCPExemplo.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public List<PedidoItem> Items { get; set; } = new List<PedidoItem>();

    }
}
