using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IServiceRepository
	{
		public Task<IEnumerable<Service>> GetAllServicesAsync();

	}
}
