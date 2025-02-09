using MediPlus.Data;
using MediPlus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorRepository _doctorRepository;
        private IDepartmentRepository _departmentRepository;

        public DoctorController(IDoctorRepository doctorRepository , IDepartmentRepository departmentRepository)
        {
            _doctorRepository = doctorRepository;
            _departmentRepository = departmentRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Doctors = await _doctorRepository.GetAllDoctorsAsync();
            return View("Index", Doctors);
        }

		[HttpGet]
		public async Task<IActionResult> Create()
        {
            ViewBag.DeptList = await _departmentRepository.GetAllDepartmentsAsync();

            return View("Create");

		}

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if(ModelState.IsValid == true)
            {
                await _doctorRepository.AddDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            ViewBag.DeptList = await _departmentRepository.GetAllDepartmentsAsync();
            return View("Create", doctor);
        }




    }
}
