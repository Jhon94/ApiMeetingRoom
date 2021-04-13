using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Models
{
    public class BookingDto
    {
            public Guid BookingId { get; set; }
            public Guid UserId { get; set; }
            public Guid RoomsId { get; set; }
            public bool Catering { get; set; }
            public DateTime DateOfAdmission { get; set; }
            public DateTime DeapertureDate { get; set; }
            public bool Status { get; set; }
        
    }
}
