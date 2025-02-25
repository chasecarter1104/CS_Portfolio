using Assignment_6_Part_1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    public class clsPassengerLinkManager
    {
        /// <summary>
        /// Links a passenger to a flight with a seat number.
        /// </summary>
        public static void LinkPassengerToFlight(string flightId, int passengerId, string seatNumber)
        {
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.LinkPassengerToFlight(flightId, passengerId, seatNumber);
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
        /// Updates the seat number of a passenger in a flight.
        /// </summary>
        public static void UpdateSeatNumber(string flightId, int passengerId, string newSeatNumber)
        {
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.UpdateSeatNumber(flightId, passengerId, newSeatNumber);
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
        /// Unlinks a passenger from a flight.
        /// </summary>
        public static void DeletePassengerLink(string flightId, int passengerId)
        {
            try
            {
                string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ReservationSystem.accdb;Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string sql = clsSQL.DeletePassengerLink(flightId, passengerId);
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
