using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{
    public class OpeningHoursRepository : IOpeningHoursRepository
	{
		private MediPlusContext _context;

		public OpeningHoursRepository(MediPlusContext context)
		{
			_context = context;
		}

        public Task AddOpeningHoursAsync(OpeningHours openingHours)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOpeningHoursAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OpeningHours>> GetAllOpeningHoursAsync()
		{
			return await _context.OpeningHours.ToListAsync();
		}

        public Task UpdateOpeningHoursAsync(OpeningHours openingHours)
        {
            throw new NotImplementedException();
        }
    }
}
