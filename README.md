# Discounter API
This project was created to embellish code-first principles. It uses .Net 5, EntityFramework Sqlite, and DDD. <br>
The database context can be used for the application and testing.

# The problem
There are 4 types of employees: Permanent, Part-time, Interns and Contractors. <br><br>

• Permanent employees get a 10% discount. They also get an extra 5% if they have been in the company for longer than 3 years.<br>
• Part-time employees get a 5% discount. They also get an extra 3% if they have been in the company for longer than 5 years.<br>
• Interns get a 5% discount but only on products with a price greater than 30.<br>
• Contractors never get a discount.<br><br>

Inside the code you will find that a strategy was used to decide what to apply.<br>
All scenarios have unit tests, made with xUnit.

# How to use
Insert one employee using the AddEmployee Endpoint.<br>
Provide your respective employeeType, and employmentDate.<br>
Pass a value and employeeId to the ApplyDiscount Endpoint. (EmployeeIds starts at 1)
