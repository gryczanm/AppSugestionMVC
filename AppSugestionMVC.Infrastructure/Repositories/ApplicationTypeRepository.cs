using AppSugestionMVC.Domain.Interfaces;
using AppSugestionMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Infrastructure.Repositories
{
    public class ApplicationTypeRepository : IApplicationTypeRepository
    {
        private readonly Context _context;

        public ApplicationTypeRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<ApplicationType> GetAllApplicationTypes()
        {
            return _context.ApplicationTypes;
        }
    }
}
