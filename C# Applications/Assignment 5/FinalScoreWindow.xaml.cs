using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Shapes;

namespace Assignment_5
{
    /// <summary>
    /// Initializes a new instance of the FinalScoreWindow class
    /// Displays user info and score details from the game.
    /// </summary>
    public partial class FinalScoreWindow : Window
    {
        private MainWindow mainWindow;
        public FinalScoreWindow(Game game, User user)
        {
            InitializeComponent();
            DisplayPlayer(user);
            DisplayScore(game);
        }

        /// <summary>
        /// Gets User info from User class
        /// Displays Player info.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="Exception"></exception>
        private void DisplayPlayer(User user)
        {
            try
            {
                PlayerNameTB.Text = $"Name: {user.Name}";
                PlayerAgeTB.Text = $"Age: {user.Age}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    /// <summary>
    /// Gets score info from Game class
    /// Displays Answer and time info.
    /// </summary>
    /// <param name="game"></param>
    /// <exception cref="Exception"></exception>
    private void DisplayScore(Game game)
        {
            try
            {
                CorrectAnswersTB.Text = $"Correct Answers: {game.Score}";
                IncorrectAnswersTB.Text = $"Incorrect Answers: {game.Incorrect}";
                ElapsedTimeTB.Text = $"Time Taken: {game.ElapsedTime} seconds";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the close button click event to return to the main window
        /// </summary>
        /// <param name="sender">close button</param>
        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                mainWindow.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
