using Discounter.Application.Interfaces;
using Discounter.Domain.Entities;

namespace Discounter.Application.Helpers.EmployeeHelper
{
    internal class InternEmployeeDiscount : IEmployeeDiscountStrategy
    {
        private const decimal _fixedDiscount = 0.05m;

        private const decimal _amountToReceiveDiscount = 30;

        public decimal Apply(decimal amount, Employee employee)
        {
            if (amount > _amountToReceiveDiscount)
                return amount - (amount * _fixedDiscount);

            return amount;
        }
    }
}
