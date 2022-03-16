using AppSugestionMVC.Application.Interfaces;
using AppSugestionMVC.Application.ViewModels.ApplicationType;
using AppSugestionMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.Services
{
    public class ApplicationTypeService : IApplicationTypeService
    {
        private readonly IApplicationTypeRepository _applicationTypeRepository;

        public ApplicationTypeService(IApplicationTypeRepository applicationTypeRepository)
        {
            _applicationTypeRepository = applicationTypeRepository;
        }

        public int AddApplicationType(ApplicationTypeVm model)
        {
            var applicationType = new Domain.Model.ApplicationType()
            {
                Id = model.Id,
                Name = model.Name,
            };

            var applicationTypeId = _applicationTypeRepository.AddApplicationType(applicationType);

            return applicationTypeId;
        }

        public void DeleteApplicationType(int id)
        {
            _applicationTypeRepository.DeleteApplicationTypeById(id);
        }

        public ApplicationTypeListVm GetAllApplicationTypesForList(int pageSize, int pageNumber, string searchString)
        {

            var applicationTypes = _applicationTypeRepository.GetAllApplicationTypes()
                .Where(x => x.Name.StartsWith(searchString))
                .Select(x => new ApplicationTypeVm()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            var applicationTypesToShow = applicationTypes.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

            var model = new ApplicationTypeListVm()
            {
                ApplicationTypes = applicationTypesToShow,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = applicationTypes.Count
            };

            return model;
        }
    }
}
