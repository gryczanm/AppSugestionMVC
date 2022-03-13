using AppSugestionMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppSugestionMVC.Web.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("Application/All")]
        public IActionResult Index()
        {
            var model = _applicationService.GetAllApplicationsForList(2, 1, "");

            return View(model);
        }
    }
}
