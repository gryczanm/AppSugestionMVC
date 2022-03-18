using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Application.ViewModels.Application
{
    public class ApplicationDeleteVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ApplicationTypeName { get; set; }

        public int ApplicationTypeId { get; set; }
    }
}
