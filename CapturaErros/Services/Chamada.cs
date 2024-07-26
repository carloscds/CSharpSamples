namespace CapturaErros.Services
{
    public class Chamada
    {
        public void ChamadaErro()
        {
            try
            {
                throw new Exception("Erro na chamada");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na chamada - Inner", ex);
            }
        }
    }
}