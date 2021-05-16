using BPSTakeHome.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPSTakeHome.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetEmployees();

        Task<EmployeeViewModel> GetEmployee(string employeeId);

        Task<EmployeeViewModel> DeleteEmployee(string employeeId);

        Task<EmployeeViewModel> UpdateEmployee(string employeeId, EmployeeViewModel employeeModel);

        Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeModel);
    }
}
