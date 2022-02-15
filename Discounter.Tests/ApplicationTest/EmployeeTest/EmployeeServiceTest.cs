using Discounter.Application.Maps;
using Discounter.Application.Services;
using Discounter.Domain.Enums;
using Discounter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Discounter.UnitTests.ApplicationTest.EmployeeTest
{
    public class EmployeeServiceTest
    {
        private readonly IDiscounterContext _context;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTest()
        {
            _context = ContextFactory.CreateContextForSQLite();
            _employeeService = new EmployeeService(_context);
        }

        [Fact]
        public async Task AddEmployee_GivenAnEmployee_ShouldAddToTheDatabase()
        {
            var employee = new EmployeeRequest
            {
                EmployeeType = EmployeeType.Permanent,
                EmploymentDate = new System.DateTime(2019, 08, 30)
            };

            await _employeeService.AddEmployee(employee);

            var addedEmployee = await _context.Employees.FirstOrDefaultAsync(s => s.EmployeeId == 1);

            Assert.NotNull(addedEmployee);
            Assert.Equal(EmployeeType.Permanent, addedEmployee.EmployeeType);
            Assert.Equal(2019, addedEmployee.EmploymentDate.Year);
        }

        [Fact]
        public async Task ApplyDiscount_GivenAValidEmployeeIdAndAmount_ShouldApplyDiscount()
        {
            var employee = new EmployeeRequest
            {
                EmployeeType = EmployeeType.Permanent,
                EmploymentDate = new System.DateTime(2019, 08, 30)
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(default);

            var discount = await _employeeService.ApplyDiscount(50, 1);

            Assert.Equal(42.5m, discount);
        }

        [Fact]
        public async Task ApplyDiscount_GivenAnUnvalidAmount_ShouldReturnZero()
        {
            var employee = new EmployeeRequest
            {
                EmployeeType = EmployeeType.Permanent,
                EmploymentDate = new System.DateTime(2019, 08, 30)
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(default);

            var discount = await _employeeService.ApplyDiscount(-50, 1);

            Assert.Equal(0, discount);
        }

        [Fact]
        public async Task ApplyDiscount_GivenAnUnvalidEmployeeId_ShouldThrowArgumentException()
        {
            var employee = new EmployeeRequest
            {
                EmployeeType = EmployeeType.Permanent,
                EmploymentDate = new System.DateTime(2019, 08, 30)
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(default);

            await Assert.ThrowsAsync<ArgumentException>(() => _employeeService.ApplyDiscount(50, 2));
        }
    }
}
