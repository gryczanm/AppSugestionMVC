using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.Application;
using AppSugestionMVC.Application.ViewModels.ApplicationType;
using AppSugestionMVC.Domain.Interfaces;
using System.Linq;

namespace AppSugestionMVC.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationTypeRepository _applicationTypeRepository;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IApplicationTypeRepository applicationTypeRepository
            )
        {
            _applicationRepository = applicationRepository;
            _applicationTypeRepository = applicationTypeRepository;
        }

        public int AddApplication(ApplicationAddVm model)
        {
            var application = new Domain.Model.Application()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                ApplicationTypeId = model.ApplicationTypeId,
            };

            var applicationTypeId = _applicationRepository.AddApplication(application);

            return applicationTypeId;
        }

        public void UpdateApplication(ApplicationAddVm model)
        {
            var application = new Domain.Model.Application()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                ApplicationTypeId = model.ApplicationTypeId,
            };

            _applicationRepository.UpdateApplication(application);
        }

        public void DeleteApplication(int id)
        {
            _applicationRepository.DeleteApplicationById(id);
        }

        public ApplicationDetailsVm GetApplicationDetails(int applicationId)
        {
            var application = _applicationRepository.GetApplicationById(applicationId);

            var applicationDetailsVm = new ApplicationDetailsVm()
            {
                Id = application.Id,
                Title = application.Title,
                Description = application.Description,
                TypeOfApplication = application.ApplicationType.Name
            };

            return applicationDetailsVm;
        }

        public ApplicationListVm GetAllApplicationsForList (int pageSize, int pageNumber, string searchString)
        {
            var applications = _applicationRepository.GetAllApplications()
                .Where(x => x.Title.StartsWith(searchString))
                .Select(x => new ApplicationForListVm()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    TypeOfApplication = x.ApplicationType.Name
                })
                .ToList();

            var applicationsToShow = applications.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

            var applicationList = new ApplicationListVm()
            {
                Applications = applicationsToShow,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = applications.Count
            };

            return applicationList;
        }

        public IQueryable<ApplicationTypeVm> GetApplicationTypesToSelectList()
        {
            var applicationTypeVm = _applicationTypeRepository.GetAllApplicationTypes()
                .Select(x => new ApplicationTypeVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                });

            return applicationTypeVm;
        }
        public ApplicationAddVm GetApplicationForEdit(int id)
        {
            var application = _applicationRepository.GetApplicationById(id);
            var applicationVm = new ApplicationAddVm()
            {
                Title = application.Title,
                Description = application.Description,
                ApplicationTypeId = application.ApplicationTypeId
            };
            var model = SetParametersToVm(applicationVm);

            return model;
        }

        public ApplicationAddVm SetParametersToVm(ApplicationAddVm model)
        {
            model.ApplicationTypes = GetApplicationTypesToSelectList().ToList();

            return model;
        }
    }
}
