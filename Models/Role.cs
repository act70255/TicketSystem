using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Role
    {
        public Role()
        {
            CreatorID = Guid.Empty.ToString();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatorID { get; set; }

        public ICollection<AccountRole> AccountRoles { get; set; }
        public ICollection<RolePremission> RolePremissions { get; set; }
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
