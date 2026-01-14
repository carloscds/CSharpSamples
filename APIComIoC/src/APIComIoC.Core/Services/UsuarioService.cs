using System;
using APIComIoC.Domain;
using APIComIoC.Domain.DTO;
using APIComIoC.InfraEstrutura.Data;

namespace APIComIoC.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly APIContext _db;
        public UsuarioService(APIContext db) 
        {
            _db = db;
        }

        public void Add(ClienteDTO cliente)
        {
            var rnd = new Random();
            var cli = new Cliente 
            { 
                Id = rnd.Next(1, int.MaxValue),
                Nome = cliente.Nome,
                Email = cliente.Email
            };
            _db.Cliente.Add(cli);
            _db.SaveChanges();
        }

        public void Delete(int clienteID)
        {
            var cli = _db.Cliente.Find(clienteID);
            if (cli != null)
            {
                _db.Cliente.Remove(cli);
                _db.SaveChanges();
            }
        }

        public void Update(ClienteDTO cliente)
        {
            var cli = _db.Cliente.Find(cliente.Id);
            if (cli != null)
            {
                cli.Nome = cliente.Nome;
                cli.Email = cliente.Email;
                _db.Cliente.Update(cli);
                _db.SaveChanges();
            }
        }

        public List<ClienteDTO> GetAll()
        {
            return _db.Cliente.Select(c => new ClienteDTO 
            { 
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email
            }).ToList();
        }
    }
}
