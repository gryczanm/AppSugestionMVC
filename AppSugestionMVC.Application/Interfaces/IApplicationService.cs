using AppSugestionMVC.Application.ViewModels.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.Interfaces
{
    public interface IApplicationService
    {
        ApplicationListViewModel GetAllApplicationsForList(int pageSize, int pageNumber, string searchString);
    }
}
