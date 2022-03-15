using AppSugestionMVC.Domain.Interfaces;
using AppSugestionMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
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

        public int AddApplication(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();

            return application.Id;
        }

        public Application GetApplicationById(int id)
        {
            var application = _context.Applications
                .Include(x => x.ApplicationType)
                .FirstOrDefault(x => x.Id == id);

            return application;
        }

        public void UpdateApplication(Application application)
        {
            _context.Attach(application);
            _context.Entry(application).Property("Title").IsModified = true;
            _context.Entry(application).Property("Description").IsModified = true;
            _context.Entry(application).Property("ApplicationTypeId").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteApplicationById(int id)
        {
            var application = _context.Applications.FirstOrDefault(x => x.Id == id);

            if (application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }

        public IQueryable<Application> GetAllApplications()
        {
            return _context.Applications;
        }
    }
}
