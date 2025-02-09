using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IOpeningHoursRepository
	{
		Task <IEnumerable<OpeningHours>> GetAllOpeningHoursAsync();

	}
}
