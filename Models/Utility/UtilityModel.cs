using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class NavigationParameterModel
    {
        public string DisplayName { get; set; }
        public string Controller { get; set; } = "Home";
        public string ID { get; set; }
    }
    public class OperateModel
    {
        public string DisplayName { get; set; }
        public string Controller { get; set; } = "Home";
        public string ID { get; set; }
    }
}
