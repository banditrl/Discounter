using Discounter.Application.Interfaces;
using Discounter.Application.Maps;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Discounter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequest employee)
        {
            await _employeeService.AddEmployee(employee);

            return new OkObjectResult("Employed create successfully!");
        }

        [HttpGet]
        public async Task<IActionResult> ApplyDiscount(decimal amount, long employeeId)
        {
            try
            {
                var discountedAmount = await _employeeService.ApplyDiscount(amount, employeeId);

                return new OkObjectResult(discountedAmount);
            }
            catch (ArgumentException)
            {
                return new BadRequestObjectResult("Employee not found.");
            }
        }
    }
}
