using Practical123.Models;

namespace EmployeeManagement.Service.Abstraction
{
    public interface IMeetingService
    {
        public List<Meeting> GetAllMeetings();
        public Task<Meeting> AddMeeting(Meeting m);
        public Task<bool> DeleteMeeting(Guid id);
        public Task<Meeting> UpdateMeeting(Meeting m);
    }
}
