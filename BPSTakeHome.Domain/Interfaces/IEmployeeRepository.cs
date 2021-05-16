using BPSTakeHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPSTakeHome.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(Guid empId);

        Task<bool> DeleteEmployee(Employee emp);

        Task<Employee> UpdateEmployee(Employee emp);

        Task<Employee> CreateEmployee(Employee emp);

        Task<IEnumerable<EmployeePosition>> GetAllPositions();

    }
}
