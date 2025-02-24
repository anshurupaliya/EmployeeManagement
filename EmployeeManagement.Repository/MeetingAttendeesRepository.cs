using EmployeeManagement.Model;
using EmployeeManagement.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Practical123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class MeetingAttendeesRepository : IMeetingAttendeesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MeetingAttendeesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddMeetingAttendees(Guid meetingId, Guid employeeId)
        {
            MeetingAttendees meetingAttendees = new MeetingAttendees();
            meetingAttendees.SelectedMeetingId = meetingId;
            meetingAttendees.SelectedEmployeeId = employeeId;
            meetingAttendees.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            meetingAttendees.CreatedAt = DateTime.Now;
            meetingAttendees.IsDeleted = false;
            await _context.MeetingAttendees.AddAsync(meetingAttendees);
            await _context.SaveChangesAsync();
        }

        public List<MeetingAttendees> GetAllMeetingAttendees()
        {
            return _context.MeetingAttendees.Where(c => c.IsDeleted == false).OrderBy(c=>c.MeetingObject.Ajenda).ToList();
        }

        public async Task UpdateMeetingAttendees(Guid meetingId, Guid employeeId)
        {
            GetAllMeetingAttendees().FirstOrDefault(c => c.SelectedMeetingId == meetingId && c.SelectedEmployeeId == employeeId).IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveMeetingAttendees(Guid meetingId)
        {
            foreach (var item in GetAllMeetingAttendees().Where(c => c.SelectedMeetingId == meetingId))
            {
                item.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

    }
}
