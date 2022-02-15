using Discounter.Application.Helpers.EmployeeHelper;
using Discounter.Application.Interfaces;
using Discounter.Application.Maps;
using Discounter.Domain.Enums;
using Discounter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discounter.Application.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IDiscounterContext _context;

        private readonly IDictionary<EmployeeType, IEmployeeDiscountStrategy> _discountByEmployee = new Dictionary<EmployeeType, IEmployeeDiscountStrategy>(4)
        {
            { EmployeeType.Permanent, new PermanentEmployeeDiscount() },
            { EmployeeType.PartTime, new PartTimeEmployeeDiscount() },
            { EmployeeType.Intern, new InternEmployeeDiscount() },
            { EmployeeType.Contractor, new ContractorEmployeeDiscount() }
        };

        public EmployeeService(IDiscounterContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(EmployeeRequest employee)
        {
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(default);
        }

        public async Task<decimal> ApplyDiscount(decimal amount, long employeeId)
        {
            var employee = await _context.Employees
                .Where(s => s.EmployeeId == employeeId)
                .FirstOrDefaultAsync();

            if (employee == null) throw new ArgumentException("EmployeeId");

            var discount = _discountByEmployee[employee.EmployeeType].Apply(amount, employee);

            if (0 > discount)
                discount = 0;

            return discount;
        }
    }
}
