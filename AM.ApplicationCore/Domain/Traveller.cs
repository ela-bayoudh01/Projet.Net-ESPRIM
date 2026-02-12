using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string? HealthInformation { get; set; }   
        public string? Nationality { get; set; }         

        public Traveller() { }

        public Traveller(string? healthInfo, string? nationality,
                         string? firstName, string? lastName, string? passportNumber)
        {
            HealthInformation = healthInfo;
            Nationality = nationality;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
        }

        public override string PassengerType
        {
            get { return "Traveller passenger type"; }
        }
        public override string ToString()
        {
            return base.ToString() + ", Nationality: " + Nationality + ", Health: " + HealthInformation;
        }
    }

}

