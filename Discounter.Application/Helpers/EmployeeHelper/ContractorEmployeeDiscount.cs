using Discounter.Application.Interfaces;
using Discounter.Domain.Entities;

namespace Discounter.Application.Helpers.EmployeeHelper
{
    internal class ContractorEmployeeDiscount : IEmployeeDiscountStrategy
    {
        public decimal Apply(decimal amount, Employee employee)
        {
            return amount;
        }
    }
}
