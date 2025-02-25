using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_Part_1
{
    /// <summary>
    /// Class for managing flight data and operations.
    /// </summary>
    public class clsFlightManager
    {
        /// <summary>
        /// Retrieves a list of all available flights from the database.
        /// </summary>
        /// <returns>A list of Flight objects representing available flights.</returns>
        public static List<Flight> GetFlights()
        {
            var flights = new List<Flight>();
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.GetFlights();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight flight = new Flight
                        {
                            FlightID = reader.GetInt32(0).ToString(), 
                            FlightNumber = reader.GetString(1), 
                            AircraftType = reader.GetString(2) 
                        };
                        flights.Add(flight);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return flights;
        }


    }
}
