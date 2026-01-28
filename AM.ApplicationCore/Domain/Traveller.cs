using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string? HealthInformation { get; set; }   // ex: "Aucune allergie", "Diabète contrôlé"
        public string? Nationality { get; set; }         // ex: "Tunisienne", "Française"

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
    }
}
