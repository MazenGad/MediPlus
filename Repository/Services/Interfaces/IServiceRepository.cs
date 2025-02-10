using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IServiceRepository
    {
        public Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);

    }
}
