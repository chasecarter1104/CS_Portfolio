using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_Part_1
{
    /// <summary>
    /// Class representing a passenger.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Gets or sets the passenger ID.
        /// </summary>
        public int PassengerID { get; set; }
        /// <summary>
        /// Gets or sets the first name of the passenger.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name of the passenger.
        /// </summary>
        public string LastName { get; set; }

        public string SeatNumber { get; set; }

        /// <summary>
        /// Returns a string representation of the passenger's full name.
        /// </summary>
        /// <returns>A string representing the full name of the passenger.</returns>
        public override string ToString()
        {
            try
            {
                return $"{FirstName} {LastName}"; // full name
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
