using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.ViewModel
{
    public class MeetingAttendeesViewModel
    {
        public Guid MeetingId { get; set; }
        public List<Guid> EmployeeIds { get; set; } = new List<Guid>();
    }
}
