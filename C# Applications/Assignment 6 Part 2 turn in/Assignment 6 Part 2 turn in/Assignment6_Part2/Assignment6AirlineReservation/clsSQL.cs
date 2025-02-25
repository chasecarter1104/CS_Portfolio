using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assignment_6_Part_1
{
    /// <summary>
    /// Class for handling SQL-related operations.
    /// </summary>
    public static class clsSQL
    {
        /// <summary>
        /// Retrieves the SQL query string for fetching flight details.
        /// </summary>
        /// <returns>SQL query string for flight details.</returns>
        public static string GetFlights()
        {
            try
            {
                string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the SQL query string for fetching passenger details for a specific flight.
        /// </summary>
        /// <param name="sFlightID">The flight ID to filter passengers by.</param>
        /// <returns>SQL query string for passenger details.</returns>
        public static string GetPassengers(string sFlightID)
        {
            try
            {
                string sSQL = $"SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
                              "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
                              $"WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
                              "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
                              $"FLIGHT.FLIGHT_ID = {sFlightID}";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string AddPassenger(string firstName, string lastName)
        {
            try
            {
                string sSQL = $"INSERT INTO PASSENGER(First_Name, Last_Name) VALUES('{firstName}', '{lastName}')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string LinkPassengerToFlight(string flightID, int passengerID, string seatNumber)
        {
            try
            {
                string sSQL = $"INSERT INTO FLIGHT_PASSENGER_LINK(Flight_ID, Passenger_ID, Seat_Number) " +
                              $"VALUES({flightID}, {passengerID}, '{seatNumber}')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string GetNewPassengerID(string firstName, string lastName)
        {
            try
            {
                string sSQL = $"SELECT Passenger_ID FROM PASSENGER WHERE First_Name = '{firstName}' AND Last_Name = '{lastName}'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string UpdateSeatNumber(string flightID, int passengerID, string seatNumber)
        {
            try
            {
                string sSQL = $"UPDATE FLIGHT_PASSENGER_LINK SET Seat_Number = '{seatNumber}' " +
                              $"WHERE FLIGHT_ID = {flightID} AND PASSENGER_ID = {passengerID}";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string DeletePassengerLink(string flightID, int passengerID)
        {
            try
            {
                string sSQL = $"DELETE FROM FLIGHT_PASSENGER_LINK WHERE FLIGHT_ID = {flightID} AND PASSENGER_ID = {passengerID}";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string DeletePassenger(int passengerID)
        {
            try
            {
                string sSQL = $"DELETE FROM PASSENGER WHERE PASSENGER_ID = {passengerID}";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}