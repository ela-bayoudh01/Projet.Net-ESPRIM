using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string? Function { get; set; } 
        public double Salary { get; set; }

        public Staff() { }

        public Staff(DateTime employmentDate, string? function, double salary,
                     string? firstName, string? lastName, string? passportNumber)
        {
            EmploymentDate = employmentDate;
            Function = function;
            Salary = salary;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
        }
    }
}
