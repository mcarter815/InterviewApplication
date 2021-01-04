using System.Diagnostics;
using System.Threading.Tasks;
using InterviewApplication.Core.Interfaces;
using InterviewApplication.Models;
using InterviewApplication.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewApplication.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;

        public HomeController(ILogger<HomeController> logger, IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
        }
        public async Task<IActionResult> Index(string searchText, int pageId = 0, int pageSize = 25)
        {
            var model = new DashboardViewModel
            {
                CurrentPage = pageId,
                NextPage = pageId + 1,
                PreviousPage = pageId - 1,
                SearchText = searchText,
                PageSize = pageSize,
                DashboardList = await _dashboardService.GetDashboard(searchText, pageId, pageSize)
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
