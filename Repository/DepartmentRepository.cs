using MediPlus.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MediPlus.Repository
{
    public class DepartmentRepository : IDepartmentRepository
	{
		private MediPlusContext _context;
		
		public DepartmentRepository(MediPlusContext context) { 
			
			_context = context;
		}

		public async Task AddDepartment(Department department)
		{
			await _context.Departments.AddAsync(department);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteDepartment(Department department)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
		{
			return await _context.Departments
				.Include(d=>d.Doctors)
				.Include(a=>a.Appointments)
				.Include(s=>s.Services)
				.ToListAsync();
		}

		public async Task<Department> GetDepartmentByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateDepartment(Department department)
		{
			throw new NotImplementedException();
		}
	}
}
