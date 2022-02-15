using Discounter.Application.Maps;
using System.Threading.Tasks;

namespace Discounter.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeRequest employee);

        Task<decimal> ApplyDiscount(decimal amount, long employeeId);
    }
}
