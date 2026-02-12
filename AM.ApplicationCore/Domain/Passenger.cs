using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Key]
        public string? PassportNumber { get; set; }

        public string? TelNumber { get; set; }

        public IList<Flight> Flights { get; set; }


        public virtual string PassengerType
        {
            get { return "Unknown passenger type"; }
        }
        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName + ", Email: " + EmailAddress + ", BirthDate: " + BirthDate.ToShortDateString();
        }


    }

}
