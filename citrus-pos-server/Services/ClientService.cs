using Microsoft.EntityFrameworkCore;

using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services
{
    public class ClientService : IClientService
    {
        private readonly SqliteDbContext _context;
        public ClientService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Client>> GetByIdAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return ServiceResponse<Client>.NotFound();
            return ServiceResponse<Client>.SuccessResponse(client);
        }

        public async Task<ServiceResponse<List<ClientDto>>> GetAllAsync()
        {
            var clients = await _context.Clients.ToListAsync();

            var dtos = clients.Select(c => new ClientDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Location = c.Location
            }).ToList();

            return ServiceResponse<List<ClientDto>>.SuccessResponse(dtos);
        }

        public async Task<ServiceResponse<Client>> CreateAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return ServiceResponse<Client>.SuccessResponse(client);
        }

        public async Task<ServiceResponse<Client>> UpdateAsync(Client client)
        {
            var existing = await _context.Clients.FindAsync(client.ClientId);
            if (existing == null)
                return ServiceResponse<Client>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();
            return ServiceResponse<Client>.SuccessResponse(client);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return ServiceResponse<bool>.NotFound();
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}