using MediPlus.Data;
using MediPlus.Data.Users;
using MediPlus.Helpers;
using MediPlus.Repository;
using MediPlus.Repository.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediPlus
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<MediPlusContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<MediPlusContext>()
			.AddDefaultTokenProviders();

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
			builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();
			builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
			builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
			builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
			builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
			builder.Services.AddScoped<ICommentRepository, CommentRepository>();
			builder.Services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
			builder.Services.AddScoped<INewsSubscriptionsRepository, NewsSubscriptionsRepository>();
			builder.Services.AddSingleton<IServiceHelper, ServiceHelper>();





			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStatusCodePagesWithReExecute("/Home/NotFound");

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
