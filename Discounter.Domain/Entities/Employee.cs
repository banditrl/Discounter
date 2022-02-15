using Discounter.Domain.Enums;
using System;

namespace Discounter.Domain.Entities
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        public EmployeeType EmployeeType { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}