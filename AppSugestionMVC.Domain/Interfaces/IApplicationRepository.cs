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
        IQueryable<Application> GetAllApplications();
    }
}
