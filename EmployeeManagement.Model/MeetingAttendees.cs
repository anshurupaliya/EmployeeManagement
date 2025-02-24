using Practical123.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Model
{
    [Table("MeetingAttendee")]
    public class MeetingAttendees : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        // Foreign Key to Meeting
        public Guid SelectedMeetingId { get; set; }

        [ForeignKey("SelectedMeetingId")]
        public virtual Meeting MeetingObject { get; set; }

        // Foreign Key to Employee
        public Guid SelectedEmployeeId { get; set; }

        [ForeignKey("SelectedEmployeeId")]
        public virtual Employee EmployeeObject { get; set; }
    }
}
