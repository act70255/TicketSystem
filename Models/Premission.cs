using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Premission
    {
        public enum PremissionEnum
        {
            AccountCreate = 0,
            AccountView = 1,
            AccountModify = 2,
            TicketCreate = 100,
            TicketView = 101,
            TicketModify = 102,
            TicketResolve = 103,
            FeatureRequestCreate = 200,
            FeatureRequestView = 201,
            FeatureRequestResolve = 203,
            TestCaseCreate = 300,
            TestCaseView = 301,
            TestCaseResolve = 303,
        }

        public PremissionEnum PremissionType { get; set; }
        public string ID { get; set; }
        public DateTime Created { get; set; }
        public string CreatorID { get; set; }

        public ICollection<RolePremission> RolePremissions { get; set; }
    }
}
