using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using DAL;


namespace LN
{
    public interface IContactosService
    {
        Task<IEnumerable<Contactos>> GetAllContactosAsync();
        Task<Contactos> CreateContactosAsync(Contactos contactos);
        Task<Contactos> GetContactosByIdAsync(int contactosId);
        Task<Contactos> PutContactosByIdAsync(int contactosId, Contactos contactos);
        Task<Contactos> DeleteContactosByIdAsync(int contactosId);
        Task<Contactos> GetContactosByContactosnameAsync(string contactosName);
    }

    public class ContactosService : IContactosService
    {
        private readonly IContactosRepository _contactosRepository;

        public ContactosService(IContactosRepository ContactosRepository)
        {
            _contactosRepository = ContactosRepository;
        }

        public async Task<IEnumerable<Contactos>> GetAllContactosAsync()
        {
            return await _contactosRepository.GetAllContactosAsync();
        }
        
        public async Task<Contactos> CreateContactosAsync(Contactos contactos)
        {
            var newContactos = await _contactosRepository.CreateContactosAsync(contactos);
            return newContactos;
        }

        public async Task<Contactos> GetContactosByIdAsync(int contactosId)
        {
            return await _contactosRepository.GetContactosByIdAsync(contactosId);
        }

        public async Task<Contactos> PutContactosByIdAsync(int contactosId, Contactos Contactos)
        {
            return await _contactosRepository.PutContactosByIdAsync(contactosId,Contactos);
        }

        public async Task<Contactos> DeleteContactosByIdAsync(int contactosId)
        {
            return await _contactosRepository.DeleteContactosByIdAsync(contactosId);
        }

        public async Task<Contactos> GetContactosByContactosnameAsync(string ContactosName)
        {
            return await _contactosRepository.GetContactosByContactosnameAsync(ContactosName);
        }
    }
}