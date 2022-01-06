using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Account: BaseModel
    {
        public Account()
        {
            AccountRoles = new HashSet<AccountRole>();
        }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public ICollection<AccountRole> AccountRoles { get; set; }
    }
    public class AccountRole: BaseModel
    {
        public AccountRole()
        {
            CreatorID = Guid.Empty.ToString();
        }

        [ForeignKey("Account")]
        public string AccountID { get; set; }
        public Account Account { get; set; }

        [ForeignKey("Role")]
        public string RoleID { get; set; }
        public Role Role { get; set; }
    }
}
