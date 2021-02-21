namespace EFCoreSample.Domain
{
    public class Produto
    {
        public int Id { get; set;}
        public string Nome { get; set;}
        public decimal Preco { get; set;}

        public virtual Grupo Grupo { get; set;}
        public int GrupoId { get ;set;}

    }
}