using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{

    public class ServiceRepository : IServiceRepository
	{
		private MediPlusContext _context;

		public ServiceRepository(MediPlusContext context)
		{
			_context = context;
		}

        public Task AddServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.Include(s => s.Department).Include(ds=>ds.DoctorServices).ToListAsync();
        }

        public Task<Service> GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
