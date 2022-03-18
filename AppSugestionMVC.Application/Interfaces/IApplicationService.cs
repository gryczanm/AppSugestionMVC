using AppSugestionMVC.Application.ViewModels.Application;
using AppSugestionMVC.Application.ViewModels.ApplicationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.Interfaces
{
    public interface IApplicationService
    {
        int AddApplication(ApplicationAddVm model);
        void UpdateApplication(ApplicationAddVm model);
        ApplicationAddVm GetApplicationForEdit(int id);
        void DeleteApplication(int id);
        ApplicationDetailsVm GetApplicationDetails(int applicationId);
        ApplicationListVm GetAllApplicationsForList(int pageSize, int pageNumber, string searchString);
        IQueryable<ApplicationTypeVm> GetApplicationTypesToSelectList();
        ApplicationAddVm SetParametersToVm(ApplicationAddVm model);
        ApplicationDeleteVm GetApplicationForDelete(int id);
    }
}
