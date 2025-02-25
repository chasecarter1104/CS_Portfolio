using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Reflection;

namespace Assignment_5
{
    /// <summary>
    /// Game Window manages game events, 
    /// </summary>
    public partial class GameWindow : Window
    {
        private MainWindow mainWindow;
        private Game game;
        private User user;
        private DispatcherTimer timer;
        private int elapsedTime;
        private string operation;

        /// <summary>
        /// Initialize a new instance of the Game Window class with the user and chosen operation.
        /// </summary>
        /// <param name="user">User playing</param>
        /// <param name="operation">the game type mathematic operator</param>
        public GameWindow(User user, string operation)
        {
            InitializeComponent();
            this.user = user;  // Ensure user is assigned here
            game = new Game();
            this.operation = operation;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            StartGame();

            this.Closing += GameWindow_Closing;
        }

        /// <summary>
        /// Start the game, calls Reset from game class
        /// Sets elapsedTime to 0, reset the Timer label, starts timer, Calls GenerageNextQuestion.
        /// </summary>
        private void StartGame()
        {
            try
            {
                game.Reset();
                elapsedTime = 0;
                TimerLBL.Content = "Time: 0s";
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
                GenerateNextQuestion();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Stops the timer, when game ends, Calls the FinalScoreWindow
        /// Calls GenerateQuestion from the game class.
        /// </summary>
        private void GenerateNextQuestion()
        {
            try
            {
                if (game.QuestionCount >= 10)
                {
                    timer.Stop();
                    FinalScoreWindow finalScoreWindow = new FinalScoreWindow(game, user);
                    finalScoreWindow.Show();
                    this.Close();
                    return;
                }

                game.GenerateQuestion(operation);
                QuestionLBL.Content = game.CurrentQuestion;
                AnswerTB.Clear();
                FeedbackLBL.Content = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Submit button click event, calls CheckAnswer from Game class.
        /// Validates the return from CheckAnswer and handles Feedback and Errors to user.
        /// Calls LaunchRocketWithFlames method.
        /// </summary>
        private async void SubmitBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear previous feedback
                FeedbackLBL.Content = "";

                // Check if input is a valid integer
                if (int.TryParse(AnswerTB.Text, out int userAnswer))
                {
                    bool isCorrect = game.CheckAnswer(userAnswer);

                    // Update the feedback label
                    FeedbackLBL.Content = isCorrect ? "Correct!" : "Incorrect!";

                    // Clear the answer input field
                    AnswerTB.Clear();

                    // Launch rockets if the answer is correct
                    if (isCorrect)
                    {
                        LaunchRocketWithFlames(RocketL, RocketFlamesL);
                        LaunchRocketWithFlames(RocketR, RocketFlamesR);
                    }

                    // Wait for 2.5 seconds to display feedback
                    await Task.Delay(2500);
                    RocketL.Visibility = Visibility.Visible;
                    RocketR.Visibility = Visibility.Visible;

                    // Generate the next question
                    GenerateNextQuestion();
                }
                else
                {
                    ErrorLBL.Content = "Please enter a valid number.";
                }
            }
            catch (Exception ex)
            {
                mainWindow.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the CancelBTN click event.
        /// Stops timer, goes back to MainWindow, closes GameWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Stop the game timer if running
                timer.Stop();

                // Show the main menu
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the current game window
                this.Close();
            }
            catch (Exception ex)
            {
                mainWindow.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the window closing event.
        /// Closes the GameWindow and Displays the MainWindow.
        /// </summary>
        private void GameWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                mainWindow.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Displays the timer label changes.
        /// Takes the elapsed time from the UpdateElapsedTime method in Game class
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                elapsedTime++;
                TimerLBL.Content = $"Time: {elapsedTime}s";
                game.UpdateElapsedTime(1);
            }
            catch (Exception ex)
            { 
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Takes images of a rocket with flames and translates it up.
        /// Plays Rocket sounds while the rocket moves up.
        /// </summary>
        /// <param name="staticRocket">Image of rocket without flames</param>
        /// <param name="rocketFlame">Image of rocket with flames</param>
        private void LaunchRocketWithFlames(Image staticRocket, Image rocketFlame)
        {
            try
            {
                // Hide Static show Flames
                staticRocket.Visibility = Visibility.Hidden;
                rocketFlame.Visibility = Visibility.Visible;

                // Move the flame rocket up
                DoubleAnimation moveUp = new DoubleAnimation
                {
                    From = 0,
                    To = -500,
                    Duration = TimeSpan.FromSeconds(2.5)
                };

                // Run the transformation
                TranslateTransform transform = new TranslateTransform();
                rocketFlame.RenderTransform = transform;
                transform.BeginAnimation(TranslateTransform.YProperty, moveUp);

                // Play rocket sound
                SoundPlayer simpleSound = new SoundPlayer("../../Sounds/RocketSound.wav");
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}