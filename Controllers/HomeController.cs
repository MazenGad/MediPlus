using MediPlus.Data;
using MediPlus.Models;
using MediPlus.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediPlus.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IOpeningHoursRepository _openingHoursRepository;
		private IServiceRepository _serviceRepository;
		private IDoctorRepository _doctorRepository;
		private IDepartmentRepository _departmentRepository;
		private IAppointmentRepository _appointmentRepository;
		private IBlogPostRepository _blogPostRepository;
		private INewsSubscriptionsRepository _newsSubscriptionsRepository;



		public HomeController(
			ILogger<HomeController> logger,
			 IOpeningHoursRepository openingHoursRepository,
			 IServiceRepository serviceRepository,
			 IDoctorRepository doctorRepository,
			 IDepartmentRepository departmentRepository,
			 IAppointmentRepository appointmentRepository,
			 IBlogPostRepository blogPostRepository,
			 INewsSubscriptionsRepository newsSubscriptionsRepository
			)
		{
			_logger = logger;
			_openingHoursRepository = openingHoursRepository;
			_serviceRepository = serviceRepository;
			_doctorRepository = doctorRepository;
			_departmentRepository = departmentRepository;
			_appointmentRepository = appointmentRepository;
			_blogPostRepository = blogPostRepository;
			_newsSubscriptionsRepository = newsSubscriptionsRepository;

		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var appointmentViewModel = new AppointmentViewModel
			{
				Appointment = new Appointment { AppointmentDate = DateTime.Now.Date },
				Departments = await _departmentRepository.GetAllDepartmentsAsync(),
			};

			var viewModel = new HomeViewModel
			{
				OpeningHours = await _openingHoursRepository.GetAllOpeningHoursAsync(),
				Services = await _serviceRepository.GetAllServicesAsync(),
				Departments = await _departmentRepository.GetAllDepartmentsAsync(),
				Appointment = appointmentViewModel
			};

			ViewBag.Posts = await _blogPostRepository.GetRecentBlogPostsAsync();

			return View("Index", viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult NotFound()
		{
			Response.StatusCode = 404;
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> BookAppointment()
		{
			var appointmentViewModel = new AppointmentViewModel
			{
				Appointment = new Appointment { AppointmentDate = DateTime.Now.Date },
				Departments = await _departmentRepository.GetAllDepartmentsAsync(),
			};

			return View("AppointmentView", appointmentViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> BookAppointment(AppointmentViewModel model)
		{

			if (ModelState.IsValid)
			{
				var appointment = model.Appointment;

				await _appointmentRepository.AddAppointmentAsync(appointment);
				return Ok();
			}

			model.Departments = await _departmentRepository.GetAllDepartmentsAsync();
			model.Doctors = await _doctorRepository.GetAllDoctorsAsync();
			return BadRequest(ModelState);

		}
		[HttpGet]

		public async Task<IActionResult> GetDoctorsByDepartmetns(int deptID)
		{
			var doctors = await _doctorRepository.GetDoctorsByDeptAsync(deptID);

			return Json(doctors);
		}

		[HttpPost]
		public async Task<IActionResult> AddSubscribe(NewsletterSubscription subscription)
		{

			if (ModelState.IsValid)
			{

				await _newsSubscriptionsRepository.AddSubscribeAsync(subscription);
				return Ok();
			}

			return BadRequest(ModelState);

		}
	}
}
