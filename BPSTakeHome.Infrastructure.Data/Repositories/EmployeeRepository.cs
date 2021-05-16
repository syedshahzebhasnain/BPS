using BPSTakeHome.Domain.Interfaces;
using BPSTakeHome.Domain.Models;
using BPSTakeHome.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPSTakeHome.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            await Task.Delay(0);
            return _context.Employees;
        }

        public async Task<Employee> GetEmployee(Guid empId)
        {
            await Task.Delay(0);
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == empId);
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            _context.Update();
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<bool> DeleteEmployee(Employee emp)
        {
            try
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Employee> CreateEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
    }
}
