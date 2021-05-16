using BPSTakeHome.Application.Interfaces;
using BPSTakeHome.Application.Mapper;
using BPSTakeHome.Application.ViewModel;
using BPSTakeHome.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPSTakeHome.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository bookRepository)
        {
            _employeeRepository = bookRepository;
        }
        public async Task<List<EmployeeViewModel>> GetEmployees()
        {

            var result = await _employeeRepository.GetEmployees();

            return result.Select(x => x.ToViewModel()).ToList();

        }

        public async Task<EmployeeViewModel> GetEmployee(string employeeId)
        {
            var empId = new Guid(employeeId);

            var employee = await _employeeRepository.GetEmployee(empId);

            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }

            return employee.ToViewModel();
        }

        public async Task<Boolean> DeleteEmployee(string employeeId)
        {

            var empId = new Guid(employeeId);

            var employee = await _employeeRepository.GetEmployee(empId);

            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }

            var result = await _employeeRepository.DeleteEmployee(employee);
            return result;
        }
        public async Task<EmployeeViewModel> UpdateEmployee(string employeeId, EmployeeViewModel employeeModel)
        {

            var empId = new Guid(employeeId);

            var employee = await _employeeRepository.GetEmployee(empId);

            if (employee == null)
            {
                throw new Exception("Employee Not Found");

            }

            var result = await _employeeRepository.UpdateEmployee(employeeModel.ToDomainModel());

            return result.ToViewModel();
        }

        public async Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeModel)
        {

            var result = await _employeeRepository.CreateEmployee(employeeModel.ToCreateDomainModel());

            return result.ToViewModel();
        }

        public async Task<List<EmployeePositionViewModel>> GetEmployeePositions()
        {

            var result = await _employeeRepository.GetAllPositions();

            return result.Select(x => x.ToViewModel()).ToList();
        }

    }
}
