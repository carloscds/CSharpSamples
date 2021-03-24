using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFLog.Dominio
{
    public class Pedido
    {
        [Key]
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
