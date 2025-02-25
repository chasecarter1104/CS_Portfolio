using System;
using System.Collections.Generic;
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
using System.Reflection;
using System.Windows.Shapes;

namespace Assignment_5
{
    /// <summary>
    /// Main form that takes user input for starting the game.
    /// Holds error handling and launches the game window.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the event when Start Game button is clicked. Validates user inputs.
        /// Displays error messages and launches the game window if valid.
        /// </summary>
        private void StartGameBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = NameTB.Text;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    ShowError("Please enter your name to continue.");
                    return;
                }

                if (!int.TryParse(AgeTB.Text, out int userAge) || userAge < 3 || userAge > 10)
                {
                    ShowError("Please enter a valid age between 3 and 10.");
                    return;
                }

                string operation = GetSelectedOperation();
                if (string.IsNullOrEmpty(operation))
                {
                    ShowError("Please select a game type.");
                    return;
                }

                User user = new User(userName, userAge);
                GameWindow gameWindow = new GameWindow(user, operation);
                gameWindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles error messages, displays to ErrorMessage Text Block
        /// </summary>
        /// <param name="message">The error message for User</param>
        private void ShowError(string message)
        {
            try
            {
                ErrorMessageTB.Text = message;
                ErrorMessageTB.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the selected game type (operation) from which radio button is selected.
        /// </summary>
        private string GetSelectedOperation()
        {
            try
            {
                if (AdditionRB.IsChecked == true) return "Addition";
                if (SubtractionRB.IsChecked == true) return "Subtraction";
                if (MultiplicationRB.IsChecked == true) return "Multiplication";
                if (DivisionRB.IsChecked == true) return "Division";
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles errors for all classes and forms. 
        /// Shows the class where the error occured
        /// shows the method in which the error occured.
        /// </summary>
        public void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                            "HandleError Exception: " + ex.Message);
            }
        }
    }
}