using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult portfolioDetails()
        {
            return View("portfolioDetails");
        }
    }
}
