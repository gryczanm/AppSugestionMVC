using AppSugestionMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Domain.Interfaces
{
    public interface IApplicationTypeRepository
    {
        int AddApplicationType(ApplicationType applicationType);
        void DeleteApplicationTypeById(int id);
        IQueryable<ApplicationType> GetAllApplicationTypes();
    }
}
