using Assignment_6_Part_1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data access object
        clsDataAccess clsData;
        //Instance of AddPassenger window
        wndAddPassenger wndAddPass;
        //List to store flight objects
        List<Flight> flights = new List<Flight>();
        //list to store passenger objects
        List<Passenger> passengers = new List<Passenger>();
        //Temporary variable for first name
        private string tempFirstName;
        //Temporary variable for last name
        private string tempLastName;
        //stores the ID for a passenger
        int newPassengerID;
        //True or false value used for adding a passenger
        bool waitingForSeatSelection;
        //True or false value used for changing a passenger seat
        bool waitingChangeSeatSelection;
        //Variable to store the currently selected seat
        string selectedSeat;

        /// <summary>
        /// Constructor for the main window
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                // Use clsFlightManager to get flights
                var flights = clsFlightManager.GetFlights();

                // Bind flights to the ComboBox
                cbChooseFlight.ItemsSource = flights;

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates seat colors based on whether they are taken or not.
        /// </summary>
        /// <param name="passengers"></param>
        private void UpdateSeatColors(List<Passenger> passengers)
        {
            try
            {
                Passenger clsSelectedPassenger = (Passenger)cbChoosePassenger.SelectedItem;

                var passengerDict = passengers.ToDictionary(p => p.SeatNumber);

                // Loop through both seat canvases
                foreach (var canvas in new[] { c767_Seats, cA380_Seats })
                {
                    // Skip if the canvas is not visible, meaning a flight has not been chosen
                    if (canvas.Visibility != Visibility.Visible)
                        continue;

                    // Iterate through the seat labels in the visible canvas
                    foreach (UIElement element in canvas.Children)
                    {
                        if (element is Label seatLabel && seatLabel.Name.StartsWith("Seat"))
                        {
                            string seatNumber = seatLabel.Content.ToString();

                            // Update seat colors based on availability
                            if (passengerDict.ContainsKey(seatNumber))
                            {
                                seatLabel.Background = Brushes.Red; 
                                seatLabel.Tag = passengerDict[seatNumber]; 
                            }
                            else
                            {
                                seatLabel.Background = Brushes.Blue;
                                seatLabel.Tag = null; 
                            }

                            seatLabel.MouseDown -= SeatLabel_MouseDown;
                            seatLabel.MouseDown += SeatLabel_MouseDown;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Takes the user mouse down information and does one of the following:
        /// If adding a new passenger, Adds a passenger and links to the flight.
        /// If waiting for seat change, Updates the passenger seat link.
        /// If neither of the above, fill the passenger Combo box with chosen passenger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeatLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender is Label seatLabel)
                {
                    if (waitingForSeatSelection)
                    {
                        // Check if the seat is available (i.e., no passenger linked)
                        if (seatLabel.Tag == null)
                        {
                            selectedSeat = seatLabel.Content.ToString();

                            // Store passenger data temporarily
                            clsPassengerManager.AddPassenger(tempFirstName, tempLastName);
                            newPassengerID = clsPassengerManager.GetNewPassengerID(tempFirstName, tempLastName);

                            Flight clsSelectedFlight = (Flight)cbChooseFlight.SelectedItem;

                            // Link passenger to flight
                            clsPassengerLinkManager.LinkPassengerToFlight(clsSelectedFlight.FlightID, newPassengerID, selectedSeat);

                            //Refresh the flight
                            cbChooseFlight_SelectionChanged(this, null);

                            EnableControls();
                            waitingForSeatSelection = false;

                        }
                        else
                        {
                            MessageBox.Show("This seat is already occupied. Please select an empty seat.",
                                            "Seat Occupied", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    if (waitingChangeSeatSelection)
                    {
                        if (seatLabel.Tag == null)
                        {
                            selectedSeat = seatLabel.Content.ToString();

                            Flight clsSelectedFlight = (Flight)cbChooseFlight.SelectedItem;
                            Passenger clsSelectedPassenger = (Passenger)cbChoosePassenger.SelectedItem;

                            //Update the passenger Seat Number link
                            clsPassengerLinkManager.UpdateSeatNumber(clsSelectedFlight.FlightID, clsSelectedPassenger.PassengerID, selectedSeat);

                            //Refresh the flight
                            cbChooseFlight_SelectionChanged(this, null);

                            EnableControls();
                            waitingChangeSeatSelection = false;
                        }
                        else
                        {
                            MessageBox.Show("This seat is already occupied. Please select an empty seat.",
                                            "Seat Occupied", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        // Get the passenger from the Tag property
                        var passenger = seatLabel.Tag as Passenger;

                        if (passenger != null)
                        {
                            // Select the passenger in the combo box
                            cbChoosePassenger.SelectedItem = passenger;
                        }
                        else
                        {
                            cbChoosePassenger.SelectedItem = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Populates the passengers in the combo box after a flight is selected.
        /// Makes the chosen flight visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get the selected flight object
                Flight clsSelectedFlight = (Flight)cbChooseFlight.SelectedItem;

                if (clsSelectedFlight != null)
                {
                    // Hide both planes initially
                    CanvasA380.Visibility = Visibility.Collapsed;
                    Canvas767.Visibility = Visibility.Collapsed;
                    cbChoosePassenger.IsEnabled = true;
                    gPassengerCommands.IsEnabled = true;

                    // Populate passenger combo box based on the selected flight
                    var passengers = clsPassengerManager.GetPassengers(clsSelectedFlight.FlightID);

                    cbChoosePassenger.ItemsSource = passengers;

                    // Show the appropriate canvas based on the aircraft type
                    if (clsSelectedFlight.AircraftType == "Airbus A380")
                    {
                        CanvasA380.Visibility = Visibility.Visible;
                        Flight_Title.Content = "A380";
                    }
                    else if (clsSelectedFlight.AircraftType == "Boeing 767")
                    {
                        Canvas767.Visibility = Visibility.Visible;
                        Flight_Title.Content = "767";
                    }
                    UpdateSeatColors(passengers);

                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Event handler for when the selected passenger changes in the combo box.
        /// </summary>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedItem is Passenger selectedPassenger)
                {
                    // Log the passenger's name and seat number to ensure the correct item is selected
                    Console.WriteLine($"Selected: {selectedPassenger.FirstName} {selectedPassenger.LastName} - Seat Number: {selectedPassenger.SeatNumber}");

                    // Update the label with the SeatNumber
                    lblPassengersSeatNumber.Content = selectedPassenger.SeatNumber;
                }
                else
                {
                    lblPassengersSeatNumber.Content = string.Empty;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Event handler for AddPassenger button.
        /// Opens the Add Passenger dialog. Takes the inputs from the dialog and stores them for use.
        /// Disables controls making the customer select a seat for the new passenger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open AddPassenger window as a dialog
                wndAddPassenger addPassengerWindow = new wndAddPassenger();
                bool? result = addPassengerWindow.ShowDialog();

                if (result == true)
                {
                    // Store passenger information
                    string firstName = addPassengerWindow.FirstName;
                    string lastName = addPassengerWindow.LastName;

                    // Disable MainWindow controls during the seat selection process
                    cbChooseFlight.IsEnabled = false;
                    cbChoosePassenger.IsEnabled = false;
                    cmdChangeSeat.IsEnabled = false;
                    cmdDeletePassenger.IsEnabled = false;
                    cmdAddPassenger.IsEnabled = false;

                    // Temporarily store the passenger details for seat assignment
                    tempFirstName = firstName;
                    tempLastName = lastName;

                    // Set a flag to indicate that a seat selection is expected
                    waitingForSeatSelection = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Event handler for ChangeSeat button.
        /// Disables all inputs making the user click on a new seat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedItem is Passenger selectedPassenger)
                {

                    cbChooseFlight.IsEnabled = false;
                    cbChoosePassenger.IsEnabled = false;
                    cmdChangeSeat.IsEnabled = false;
                    cmdDeletePassenger.IsEnabled = false;
                    cmdAddPassenger.IsEnabled = false;

                    waitingChangeSeatSelection = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Deletes the passenger, deletes the passenger link in database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ensure that a passenger is selected
                if (cbChoosePassenger.SelectedItem is Passenger selectedPassenger)
                {
                    // Confirm the deletion
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete passenger {selectedPassenger.FirstName} {selectedPassenger.LastName}?",
                        "Confirm Deletion",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Ensure a flight is selected
                        if (cbChooseFlight.SelectedItem is Flight selectedFlight)
                        {
                            // Delete the link between the passenger and the flight
                            clsPassengerLinkManager.DeletePassengerLink(selectedFlight.FlightID, selectedPassenger.PassengerID);
                        }

                        // Delete passenger from the database
                        clsPassengerManager.DeletePassenger(selectedPassenger.PassengerID);

                        // Refresh the passenger list for the current flight
                        if (cbChooseFlight.SelectedItem is Flight refreshFlight)
                        {
                            cbChoosePassenger.ItemsSource = clsPassengerManager.GetPassengers(refreshFlight.FlightID);
                            cbChoosePassenger.SelectedIndex = -1; // Deselect the passenger
                        }

                        cbChooseFlight_SelectionChanged(this, null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a passenger to delete.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables all controlls after seat selection and passenger linking.
        /// </summary>
        private void EnableControls()
        {
            try
            {
                // Enable controls again after seat selection and passenger linking
                cbChooseFlight.IsEnabled = true;
                cbChoosePassenger.IsEnabled = true;
                cmdChangeSeat.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles exception errors showing a path for each error.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

    }
}
