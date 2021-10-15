using System;

namespace ExemploAPIEFCoreMigrations.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }

    }
}
