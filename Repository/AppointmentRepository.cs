﻿using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{
    public class AppointmentRepository : IAppointmentRepository
	{
		private MediPlusContext _context;

		public AppointmentRepository(MediPlusContext context)
		{
			_context = context;
		}



		async Task<IEnumerable<Appointment>> IAppointmentRepository.GetAllAppointments()
		{
			return await _context.Appointments
				.Include(a => a.Department)
				.Include(a => a.Doctor)
				.ToListAsync();
		}

		async Task IAppointmentRepository.AddAppointment(Appointment appointment)
		{
			await _context.Appointments.AddAsync(appointment);
			await _context.SaveChangesAsync();
		}
	}
}
