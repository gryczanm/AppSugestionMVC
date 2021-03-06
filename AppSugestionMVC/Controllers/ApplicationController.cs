using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            var model = _applicationService.GetAllApplicationsForList(10, 1, "");

            return View(model);
        }

        [HttpPost]
        [Route("Application/All")]
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

            var model = _applicationService.GetAllApplicationsForList(pageSize, pageNumber.Value, searchString);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddApplication()
        {
            var model = new ApplicationAddVm();
            _applicationService.SetParametersToVm(model);

            return PartialView("_AddApplicationModalPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddApplication(ApplicationAddVm applicationAddVm)
        {
            _applicationService.AddApplication(applicationAddVm);
            var model = _applicationService.GetAllApplicationsForList(10, 1, "");

            return PartialView("_ListOfApplicationsPartial", model);
        }

        [HttpGet]
        [Route("Application/Details/{id}")]
        public IActionResult DetailsApplication(int id)
        {
            var model = _applicationService.GetApplicationDetails(id);

            return View(model);
        }

        //[HttpGet]
        //[Route("Application/Edit/{id}")]
        //public IActionResult EditApplication(int id)
        //{
        //    var model = _applicationService.GetApplicationForEdit(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Application/Edit/{id}")]
        //public IActionResult EditApplication(ApplicationAddVm model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    _applicationService.UpdateApplication(model);

        //    return RedirectToAction("DetailsApplication", new { model.Id });
        //}

        //public IActionResult DeleteApplication(int id)
        //{
        //    _applicationService.DeleteApplication(id);
        //    _logger.LogInformation($"Application with id: {id} has been deleted.");

        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult EditApplication(int id)
        {
            var model = _applicationService.GetApplicationForEdit(id);
            _applicationService.SetParametersToVm(model);

            return PartialView("_EditApplicationPartial", model);
        }
    }
}
