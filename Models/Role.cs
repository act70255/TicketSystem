using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Role : BaseModel
    {
        public Role()
        {
            CreatorID = Guid.Empty.ToString();
        }
        public string Name { get; set; }

        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<RolePremission> RolePremissions { get; set; }
    }

    public class RolePremission : BaseModel
    {
        public RolePremission()
        {
            CreatorID = Guid.Empty.ToString();
        }

        [ForeignKey("Role")]
        public string RoleID { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Premission")]
        public string PremissionID { get; set; }
        public Premission Premission { get; set; }
    }
}
