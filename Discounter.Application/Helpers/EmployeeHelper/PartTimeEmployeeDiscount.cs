using Discounter.Application.Interfaces;
using Discounter.Domain.Entities;
using System;

namespace Discounter.Application.Helpers.EmployeeHelper
{
    internal class PartTimeEmployeeDiscount : IEmployeeDiscountStrategy
    {
        private const decimal _fixedDiscount = 0.05m;
        private const decimal _discountByDate = 0.08m;

        private const int _yearsToReceiveDiscountByDate = 5;

        public decimal Apply(decimal amount, Employee employee)
        {
            if (DateTime.Now.Year - employee.EmploymentDate.Year >= _yearsToReceiveDiscountByDate)
                return amount - (amount * _discountByDate);

            return amount - (amount * _fixedDiscount);
        }
    }
}
