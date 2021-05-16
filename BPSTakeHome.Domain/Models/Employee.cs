using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPSTakeHome.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public EmployeePosition Position { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
