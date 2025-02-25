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
    /// Class for managing passenger data.
    /// </summary>
    public class clsPassengerManager
    {
        /// <summary>
        /// Retrieves a list of passengers for a specific flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <returns>A list of passengers for the specified flight.</returns>
        public static List<Passenger> GetPassengers(string flightId)
        {
            var passengers = new List<Passenger>();
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.GetPassengers(flightId);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Passenger passenger = new Passenger
                        {
                            PassengerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            SeatNumber = reader.GetString(3) 
                        };
                        passengers.Add(passenger);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return passengers;
        }
        /// <summary>
        /// Adds a new passenger to the database.
        /// </summary>
        public static void AddPassenger(string firstName, string lastName)
        {
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.AddPassenger(firstName, lastName);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the ID of a newly added passenger.
        /// </summary>
        public static int GetNewPassengerID(string firstName, string lastName)
        {
            int passengerID = -1;
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.GetNewPassengerID(firstName, lastName);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    passengerID = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return passengerID;
        }

        /// <summary>
        /// Deletes a passenger from the database.
        /// </summary>
        public static void DeletePassenger(int passengerID)
        {
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.DeletePassenger(passengerID);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}