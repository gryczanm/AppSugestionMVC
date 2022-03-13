using AppSugestionMVC.Domain.Interfaces;
using AppSugestionMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Context _context;

        public ApplicationRepository(Context context)
        {
            _context = context;
        }


        public IQueryable<Application> GetAllApplications()
        {
            return _context.Applications;
        }
    }
}
