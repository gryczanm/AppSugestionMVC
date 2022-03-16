using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.ApplicationType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            var model = _applicationTypeService.GetAllApplicationTypesForList(2, 1, "");

            return View(model);
        }

        [HttpPost]
        [Route("Type/All")]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _applicationTypeService.GetAllApplicationTypesForList(pageSize, pageNumber.Value, searchString);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateApplicationType()
        {
            var applicationType = new ApplicationTypeVm();

            return PartialView("_ApplicationTypeModelPartialForCreate", applicationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateApplicationType(ApplicationTypeVm applicationTypeVm)
        {
            _applicationTypeService.AddApplicationType(applicationTypeVm);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteApplicationType(int id)
        {
            _applicationTypeService.DeleteApplicationType(id);
            _logger.LogInformation($"Application with id: {id} has been deleted.");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditApplicationType()
        {
            var applicationType = new ApplicationTypeVm();

            return PartialView("_ApplicationTypeModelPartialForEdit", applicationType);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditApplicationType(ApplicationTypeVm applicationTypeVm)
        //{
        //    //_applicationTypeService.AddApplicationType(applicationTypeVm);
        //    return RedirectToAction("Index");
        //}
    }
}
