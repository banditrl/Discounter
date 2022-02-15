using Discounter.Application.Interfaces;
using Discounter.Domain.Entities;
using System;

namespace Discounter.Application.Helpers.EmployeeHelper
{
    internal class PermanentEmployeeDiscount : IEmployeeDiscountStrategy
    {
        private const decimal _fixedDiscount = 0.10m;
        private const decimal _discountByDate = 0.15m;

        private const int _yearsToReceiveDiscountByDate = 3;

        public decimal Apply(decimal amount, Employee employee)
        {
            if (DateTime.Now.Year - employee.EmploymentDate.Year >= _yearsToReceiveDiscountByDate)
                return amount - (amount * _discountByDate);

            return amount - (amount * _fixedDiscount);
        }
    }
}
