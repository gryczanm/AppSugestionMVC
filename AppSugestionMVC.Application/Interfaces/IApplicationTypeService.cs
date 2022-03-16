using AppSugestionMVC.Application.ViewModels.ApplicationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.Interfaces
{
    public interface IApplicationTypeService
    {
        ApplicationTypeListVm GetAllApplicationTypesForList(int pageSize, int pageNumber, string searchString);
        int AddApplicationType(ApplicationTypeVm model);
        void DeleteApplicationType(int id);
    }
}
