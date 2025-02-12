using MediPlus.Data.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Data
{
    public class MediPlusContext : IdentityDbContext<ApplicationUser>
    {
        public MediPlusContext() : base() { }

        public MediPlusContext(DbContextOptions<MediPlusContext> options) : base(options) { }

        // main Models
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DoctorTimetable> DoctorTimetables { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<EmergencyCase> EmergencyCases { get; set; }

        // Bolg Models
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // others 
        public DbSet<MedicalCase> MedicalCases { get; set; }
        public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }
		public DbSet<OpeningHours> OpeningHours { get; set; }
		public DbSet<ContactMessage> ContactMessages { get; set; }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Doctor>().
                HasOne(d=>d.Department)
                .WithMany(d=>d.Doctors)
                .HasForeignKey(d=>d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<DoctorTimetable>()
			   .HasOne(dt => dt.Doctor)
			   .WithMany(d => d.Timetables)
			   .HasForeignKey(dt => dt.DoctorId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Appointment>()
			   .HasOne(a => a.Doctor)
			   .WithMany(d => d.Appointments)
			   .HasForeignKey(a => a.DoctorId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Appointment>()
				.HasOne(a => a.Department)
				.WithMany(dep => dep.Appointments)
				.HasForeignKey(a => a.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<BlogPost>()
			   .HasOne(bp => bp.Category)
			   .WithMany(c => c.BlogPosts)
			   .HasForeignKey(bp => bp.CategoryId)
			   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<EmergencyCase>()
				.HasOne(ec => ec.Doctor)
				.WithMany(d => d.EmergencyCases)
				.HasForeignKey(ec => ec.DoctorId)
				.OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<BlogPost>().
				HasMany(c=>c.Comments).
				WithOne(B=>B.BlogPost).
				HasForeignKey(b=>b.BlogPostId).
				OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<DoctorService>()
				.HasKey(ds => new { ds.DoctorId, ds.ServiceId });

			modelBuilder.Entity<DoctorService>()
				.HasOne(ds => ds.Doctor)
				.WithMany(d => d.DoctorServices)
				.HasForeignKey(ds => ds.DoctorId)
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<DoctorService>()
				.HasOne(ds => ds.Service)
				.WithMany(s => s.DoctorServices)
				.HasForeignKey(ds => ds.ServiceId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Service>()
				.HasOne(s => s.Department)
				.WithMany(d => d.Services)
				.HasForeignKey(s => s.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict);


		}



	}
}
