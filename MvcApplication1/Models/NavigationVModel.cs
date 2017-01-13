using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class NavigationVModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<NavigationVModel> SubMenu { get; set; }
    }
}