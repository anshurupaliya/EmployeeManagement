using Practical123.Models;


namespace EmployeeManagement.Repository.Abstraction
{
    public interface IMeetingRepository
    {
        public List<Meeting> GetAllMeetings();
        public Task<Meeting> AddMeeting(Meeting m);
        public Task<bool> DeleteMeeting(Meeting m);
        public Task<Meeting> UpdateMeeting(Meeting m);
    }
}
