using MediPlus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
    public class ServiceController : Controller
    {
        IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Services = await _serviceRepository.GetAllServicesAsync();
            ViewData["Page"] = "Services";
            return View("Index", Services);
        }
    }
}
