using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public enum TicketTypeEnum
    {
        Ticket,
        TestCase,
        FeatureRequest
    }
    public class Ticket : BaseModel
    {
        public Ticket()
        {
            Type = TicketTypeEnum.Ticket;
        }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        public TicketTypeEnum Type { get; set; }
        public DateTime? Resolved { get; set; }
    }
}
