using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_Part_1
{
    /// <summary>
    /// Class representing a flight.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Gets or sets the flight ID.
        /// </summary>
        public string FlightID { get; set; }
        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        public string FlightNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of aircraft.
        /// </summary>
        public string AircraftType { get; set; }

        /// <summary>
        /// Returns a string representation of the flight.
        /// </summary>
        /// <returns>A string representing the flight number and aircraft type.</returns>
        public override string ToString()
        {
            try
            {
                return $"{FlightNumber} ({AircraftType})";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
