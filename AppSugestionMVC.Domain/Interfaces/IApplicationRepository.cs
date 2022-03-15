using AppSugestionMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        int AddApplication(Application application);
        Application GetApplicationById(int id);
        void UpdateApplication(Application application);
        void DeleteApplicationById(int id);
        IQueryable<Application> GetAllApplications();
    }
}
