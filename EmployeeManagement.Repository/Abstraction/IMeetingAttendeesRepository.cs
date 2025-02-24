using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Abstraction
{
    public interface IMeetingAttendeesRepository
    {
        List<MeetingAttendees> GetAllMeetingAttendees();
        Task AddMeetingAttendees(Guid meetingId, Guid employeeId);
        Task RemoveMeetingAttendees(Guid meetingId);
        Task UpdateMeetingAttendees(Guid meetingId, Guid employeeId);
    }
}
