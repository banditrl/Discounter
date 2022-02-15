using Discounter.Application.Helpers.EmployeeHelper;
using Discounter.Domain.Entities;
using System;
using Xunit;

namespace Discounter.UnitTests.ApplicationTest.EmployeeTest
{
    public class EmployeeDiscountStrategyTest
    {
        private readonly PermanentEmployeeDiscount _permanent;
        private readonly PartTimeEmployeeDiscount _partTime;
        private readonly InternEmployeeDiscount _intern;
        private readonly ContractorEmployeeDiscount _contractor;

        public EmployeeDiscountStrategyTest()
        {
            _permanent = new PermanentEmployeeDiscount();
            _partTime = new PartTimeEmployeeDiscount();
            _intern = new InternEmployeeDiscount();
            _contractor = new ContractorEmployeeDiscount();            
        }

        [Fact]
        public void Permanent_GivenAnAmount_ShouldApplyTenPercentDiscount()
        {
            var employee = new Employee
            {
                EmploymentDate = DateTime.Now
            };

            var discount = _permanent.Apply(50, employee);

            Assert.Equal(45, discount);
        }

        [Fact]
        public void Permanent_GivenAnEmployeeWithMoreThanThreeYears_ShouldApplyFifteenPercentDiscount()
        {
            var employee = new Employee
            {
                EmploymentDate = new DateTime(2000, 01, 01)
            };

            var discount = _permanent.Apply(50, employee);

            Assert.Equal(42.5m, discount);
        }

        [Fact]
        public void PartTime_GivenAnAmount_ShouldApplyFivePercentDiscount()
        {
            var employee = new Employee
            {
                EmploymentDate = DateTime.Now
            };

            var discount = _partTime.Apply(50, employee);

            Assert.Equal(47.5m, discount);
        }

        [Fact]
        public void PartTime_GivenAnEmployeeWithMoreThanFiveYears_ShouldApplyEigthPercentDiscount()
        {
            var employee = new Employee
            {
                EmploymentDate = new DateTime(2000, 01, 01)
            };

            var discount = _partTime.Apply(50, employee);

            Assert.Equal(46, discount);
        }

        [Fact]
        public void Intern_GivenAnAmountHigherThan30_ShouldApplyFivePercentDiscount()
        {
            var employee = new Employee();

            var discount = _intern.Apply(50, employee);

            Assert.Equal(47.5m, discount);
        }

        [Fact]
        public void Intern_GivenAnAmountLowerThan30_ShouldNotApplyDiscount()
        {
            var employee = new Employee();

            var discount = _intern.Apply(25, employee);

            Assert.Equal(25, discount);
        }

        [Fact]
        public void Contractor_GivenAnAmount_ShouldNotApplyDiscount()
        {
            var employee = new Employee();

            var discount = _contractor.Apply(50, employee);

            Assert.Equal(50, discount);
        }
    }
}
