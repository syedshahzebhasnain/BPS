using BPSTakeHome.Application.Interfaces;
using BPSTakeHome.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPSTakeHome.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IEmployeeService _employeeService;

        public EmployeeController(ILogger<WeatherForecastController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var model = await _employeeService.GetEmployees();
            return model;
        }

        [HttpGet]
        [Route("/{employeeId}")]
        public async Task<EmployeeViewModel> GetEmployee([FromRoute(Name = "employeeId")] string employeeId)
        {
            EmployeeViewModel model = await _employeeService.GetEmployee(employeeId);
            return model;
        }

        [HttpPost]
        public async Task<EmployeeViewModel> CreateEmployee([FromBody] EmployeeViewModel employee)
        {
            EmployeeViewModel model = await _employeeService.CreateEmployee(employee);
            return model;
        }

        [HttpPut]
        [Route("/{employeeId}")]
        public async Task<EmployeeViewModel> UpdateEmployee([FromRoute(Name = "employeeId")] string employeeId, [FromBody] EmployeeViewModel employee)
        {
            EmployeeViewModel model = await _employeeService.UpdateEmployee(employeeId, employee);
            return model;
        }

        [HttpDelete]
        [Route("/{employeeId}")]
        public async Task<EmployeeViewModel> DeleteEmployee([FromRoute(Name = "employeeId")] string employeeId)
        {
            EmployeeViewModel model = await _employeeService.DeleteEmployee(employeeId);
            return model;
        }
    }
}
