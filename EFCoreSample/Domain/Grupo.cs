using System.Collections.Generic;

namespace EFCoreSample.Domain
{
    public class Grupo
    {
        public int Id { get; set;}
        public string Nome { get; set;}

        public virtual ICollection<Produto> Produto {get; set;}
    }
}