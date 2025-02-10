using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IOpeningHoursRepository
    {
        Task<IEnumerable<OpeningHours>> GetAllOpeningHoursAsync();
        Task AddOpeningHoursAsync(OpeningHours openingHours);
        Task UpdateOpeningHoursAsync(OpeningHours openingHours);
        Task DeleteOpeningHoursAsync(int id);
    }
}
