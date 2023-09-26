using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;



namespace DAL
{
    public interface IContactosRepository
    {
        Task<IEnumerable<Contactos>> GetAllContactosAsync();
        Task<Contactos> CreateContactosAsync(Contactos contactos);
        Task<Contactos> GetContactosByIdAsync(int contactosId);
        Task<Contactos> PutContactosByIdAsync(int contactosId, Contactos contactos);
        Task<Contactos> DeleteContactosByIdAsync(int contactosId);
        Task<Contactos> GetContactosByContactosnameAsync(string contactosName);
    }

    public class ContactosRepository : IContactosRepository
    {
        private readonly DataContext _context;

        public ContactosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contactos>> GetAllContactosAsync()
        {
            return await _context.Contactos.ToListAsync();
        }

        public async Task<Contactos> CreateContactosAsync(Contactos contactos)
        {           
            _context.Contactos.Add(contactos);
            await _context.SaveChangesAsync();
            return contactos;
        }
        public async Task<Contactos> GetContactosByIdAsync(int contactosId)
        {
            var contactos = await _context.Contactos.FindAsync(contactosId);

            return contactos;
        }

        public async Task<Contactos> PutContactosByIdAsync(int contactosId, Contactos contactos)
        {
            _context.Entry(contactos).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return contactos;
        }

        public async Task<Contactos> DeleteContactosByIdAsync(int contactosId)
        {
            var contactos = await _context.Contactos.FindAsync(contactosId);
            _context.Contactos.Remove(contactos);
            await _context.SaveChangesAsync();
            return contactos;
        }
        //
        public async Task<Contactos> GetContactosByContactosnameAsync(string contactosName)
        {
            var contactosname = await _context.Contactos.FirstOrDefaultAsync(u => u.Correo == contactosName);
            return contactosname;
        }

    }
}
