using EmployeeManagement.Model;


namespace EmployeeManagement.Service.Abstraction
{
    public interface IMeetingAttendeesService
    {
        public List<MeetingAttendees> GetAllMeetingAttendees();
        public Task AddMeetingAttendees(Guid meetingId, Guid employeeId);
        public Task RemoveMeetingAttendees(Guid meetingId);
        public Task UpdateMeetingAttendees(Guid meetingId, Guid employeeId);
    }
}
