using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.Application;
using AppSugestionMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public ApplicationListViewModel GetAllApplicationsForList   (int pageSize, int pageNumber, string searchString)
        {
            var applications = _applicationRepository.GetAllApplications()
                .Where(x => x.Title.StartsWith(searchString))
                .Select(x => new ApplicationForListViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                })
                .ToList();

            var applicationsToShow = applications.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

            var applicationList = new ApplicationListViewModel()
            {
                Applications = applicationsToShow,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = applications.Count
            };

            return applicationList;
        }
    }
}
