namespace MCPExemplo.Domain
{
    public class PedidoItem
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
