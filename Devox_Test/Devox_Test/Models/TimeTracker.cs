using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devox_Test.Models
{
    public class TimeTracker
    {
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }

        [Key, Column(Order = 2, TypeName = "Date")]
        public DateTime Date { get; set; }

        [Key, Column(Order = 3)]
        public int ProjectId { get; set; }

        [Key, Column(Order = 4)]
        public int RoleID { get; set; }

        [Key, Column(Order = 5)]
        public int ActivityTypeId { get; set; }

        public int HoursNumber { get; set; }
    }
}