using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.ViewModels.ApplicationType
{
    public class ApplicationTypeListVm
    {
        public List<ApplicationTypeVm> ApplicationTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public string SearchString { get; set; }
    }
}
