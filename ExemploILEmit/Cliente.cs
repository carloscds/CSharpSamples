namespace ExemploILEmit
{
    public class Cliente
    {
        private int _id;
        public string nome { get; set; }

        public string Retorna() => "Carlos";

        public int Ret()
        {
            int a = 0;
            int b = 0;
            return a + b;
        }
    }
}
