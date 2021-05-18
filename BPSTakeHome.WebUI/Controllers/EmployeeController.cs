using BPSTakeHome.Application.Interfaces;
using BPSTakeHome.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPSTakeHome.WebUI.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns> List of all employees</returns>
        [HttpGet]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var model = await _employeeService.GetEmployees();
            return model;
        }
 
        /// <summary>
        /// Gets a specific Employe
        /// </summary>
        /// <param name="employeeId"> Guid of Employee in string format</param>
        /// <returns>Employee details</returns>
        [HttpGet]
        [Route("{employeeId}")]
        public async Task<EmployeeViewModel> GetEmployee([FromRoute(Name = "employeeId")] string employeeId)
        {
            EmployeeViewModel model = await _employeeService.GetEmployee(employeeId);
            return model;
        }

        /// <summary>
        /// Creates an employee
        /// </summary>
        /// <param name="employee"> Employee object model from body</param>
        /// <returns>New created employee</returns>
        [HttpPost]
        public async Task<EmployeeViewModel> CreateEmployee([FromBody] EmployeeViewModel employee)
        {
             EmployeeViewModel model = await _employeeService.CreateEmployee(employee);
            return model;
        }

        /// <summary>
        /// Updates an employee
        /// </summary>
        /// <param name="employeeId">ID of the employee</param>
        /// <param name="employee">Employee update model</param>
        /// <returns> Updated employee model</returns>
        [HttpPut]
        [Route("{employeeId}")]
        public async Task<EmployeeViewModel> UpdateEmployee([FromRoute(Name = "employeeId")] string employeeId, [FromBody] EmployeeViewModel employee)
        {
            EmployeeViewModel model = await _employeeService.UpdateEmployee(employeeId, employee);
            return model;
        }

        /// <summary>
        /// Deletes an employee
        /// </summary>
        /// <param name="employeeId">Guid of employee</param>
        /// <returns> Returns success or failure</returns>
        [HttpDelete]
        [Route("{employeeId}")]
        public async Task<bool> DeleteEmployee([FromRoute(Name = "employeeId")] string employeeId)
        {
            var result = await _employeeService.DeleteEmployee(employeeId);
            return result;
        }
        /// <summary>
        /// Gets a list of all employee positions
        /// </summary>
        /// <returns>
        /// List of all employee positions
        /// </returns>
        [HttpGet]
        [Route("positions")]
        public async Task<List<EmployeePositionViewModel>> GetEmployeePositions()
        {
            var model = await _employeeService.GetEmployeePositions();
            return model;
        }
    }
}
