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

		public async Task<IEnumerable<OpeningHours>> GetAllOpeningHoursAsync()
		{
			return await _context.OpeningHours.ToListAsync();
		}
	}
}
