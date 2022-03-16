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

        public int AddApplicationType(ApplicationType applicationType)
        {
            _context.ApplicationTypes.Add(applicationType);
            _context.SaveChanges();

            return applicationType.Id;
        }

        public void DeleteApplicationTypeById(int id)
        {
            var applicationType = _context.ApplicationTypes.FirstOrDefault(x => x.Id == id);

            if (applicationType != null)
            {
                _context.ApplicationTypes.Remove(applicationType);
                _context.SaveChanges();
            }
        }

        public IQueryable<ApplicationType> GetAllApplicationTypes()
        {
            return _context.ApplicationTypes;
        }
    }
}
