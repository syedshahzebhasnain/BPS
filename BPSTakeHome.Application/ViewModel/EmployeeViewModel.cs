using BPSTakeHome.Domain.Models;
using System;

namespace BPSTakeHome.Application.ViewModel
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public EmployeePosition Position { get; set; }
    }
}
