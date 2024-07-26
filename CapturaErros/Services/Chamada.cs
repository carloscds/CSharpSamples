namespace CapturaErros.Services
{
    public class Chamada
    {
        public void ChamadaErro()
        {
            try
            {
                throw new System.Exception("Erro na chamada");
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro na chamada - Inner", ex);
            }
        }
    }
}