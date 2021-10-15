using System.Collections.Generic;

namespace ExemploAPIEFCoreMigrations.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string CNPJCPF { get; set; }
        public string Cidade { get; set; }
        public Area Area { get; set; }
        public int? AreaId { get; set; }
        public ICollection<Pedido> Pedidos {  get; set; }
    }
}
