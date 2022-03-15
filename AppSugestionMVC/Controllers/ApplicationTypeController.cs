using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.ApplicationType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppSugestionMVC.Web.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ILogger<ApplicationTypeController> _logger;
        private readonly IApplicationTypeService _applicationTypeService;

        public ApplicationTypeController(ILogger<ApplicationTypeController> logger, IApplicationTypeService applicationService)
        {
            _logger = logger;
            _applicationTypeService = applicationService;
        }

        [HttpGet]
        [Route("Type/All")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult CreateApplicationType()
        {
            var applicationType = new ApplicationTypeVm();

            return PartialView("_ApplicationTypeModelPartialForCreate", applicationType);
        }
    }
}
