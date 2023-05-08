using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(
           IEmployeeService employeeservice)
        {
            _EmployeeService = employeeservice;
        }

        [HttpPost("createemployee")]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeModel model)
        {
            StatusResponse Result = await _EmployeeService.CreateAsync(model);

            if (Result.Errors.Count > 0)
            {
                string errors = string.Empty;

                foreach (var error in Result.Errors)
                {
                    errors += error.Field + " " +  error.Message + Environment.NewLine;
                }

                return NotFound(errors);
            }

            return Ok(Result.Data);
        }
    }
}
