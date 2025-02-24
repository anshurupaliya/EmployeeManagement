using EmployeeManagement.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Practical123.Models;


namespace EmployeeManagement.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MeetingRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Meeting> AddMeeting(Meeting m)
        {
            m.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            m.CreatedAt = DateTime.Now;
            m.IsDeleted = false;
            await _context.Meetings.AddAsync(m);
            await _context.SaveChangesAsync();
            return m;
        }

        public async Task<bool> DeleteMeeting(Meeting m)
        {
            Meeting data = _context.Meetings.FirstOrDefault(c1 => c1.Id == m.Id);
            data.IsDeleted = true;
            data.DeletedAt = DateTime.Now;
            data.IsDeletedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Meeting> GetAllMeetings()
        {
            return _context.Meetings.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Meeting> UpdateMeeting(Meeting m)
        {
            var Data = GetAllMeetings().FirstOrDefault(c1 => c1.Id == m.Id);
            Data.Ajenda = m.Ajenda;
            Data.Date = m.Date;
            Data.UpdatedAt = DateTime.Now;
            Data.UpdatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return m;
        }
    }
}
