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

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.Include(s => s.Department).Include(ds=>ds.DoctorServices).ToListAsync();
        }
    }
}
