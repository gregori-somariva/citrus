using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services.Interfaces
{
    public interface IClientService
    {
        Task<ServiceResponse<Client?>> GetByIdAsync(int id);
        Task<ServiceResponse<List<ClientDto>>> GetAllAsync();
        Task<ServiceResponse<Client>> CreateAsync(Client client);
        Task<ServiceResponse<Client>> UpdateAsync(Client client);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}