using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            ID = Guid.NewGuid().ToString();
            Created = DateTime.Now;
        }

        public string ID { get; set; }
        public DateTime Created { get; set; }
        public string CreatorID { get; set; }
        public DateTime? Deleted { get; set; }
        public string DeleterID { get; set; }
    }
}
