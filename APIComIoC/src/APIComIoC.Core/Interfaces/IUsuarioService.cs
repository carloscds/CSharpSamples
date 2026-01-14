using APIComIoC.Domain.DTO;

namespace APIComIoC.Services
{
    public interface IUsuarioService
    {
        public void Add(ClienteDTO cliente);
        public void Update(ClienteDTO cliente);
        public void Delete(int clienteID);
        List<ClienteDTO> GetAll();
    }
}
