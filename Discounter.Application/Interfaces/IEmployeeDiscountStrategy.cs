using Discounter.Domain.Entities;


namespace Discounter.Application.Interfaces
{
    internal interface IEmployeeDiscountStrategy
    {
        decimal Apply(decimal amount, Employee employee);
    }
}
