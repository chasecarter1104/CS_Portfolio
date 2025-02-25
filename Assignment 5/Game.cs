using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System;

namespace Assignment_5
{
    /// <summary>
    /// Class that holds game logic, including score, correct/incorrect count, question generation, question generation.
    /// </summary>
    public class Game
    {
        private Random random = new Random();
        /// <summary>
        /// Get or Set CurrentQuestion
        /// </summary>
        public string CurrentQuestion { get; private set; }
        /// <summary>
        /// Get or set Correct Answer
        /// </summary>
        public int CorrectAnswer { get; private set; }
        /// <summary>
        /// Get or set Question Count
        /// </summary>
        public int QuestionCount { get; private set; }
        /// <summary>
        /// Get or set Score
        /// </summary>
        public int Score { get; private set; }
        /// <summary>
        /// Get or set Incorrect answers
        /// </summary>
        public int Incorrect {  get; private set; }
        /// <summary>
        /// Get or set ElapsedTime
        /// </summary>
        public int ElapsedTime { get; private set; }

        /// <summary>
        /// Generates a question based on the specified mathematical operation.
        /// </summary>
        /// <param name="operation">the mathmatical operation for te question.</param>
        public void GenerateQuestion(string operation)
        {
            try
            {
                if (QuestionCount >= 10) return;

                int num1 = random.Next(1, 11);
                int num2 = random.Next(1, 11);

                switch (operation)
                {
                    case "Addition":
                        CurrentQuestion = $"{num1} + {num2} = ?";
                        CorrectAnswer = num1 + num2;
                        break;
                    case "Subtraction":
                        if (num1 < num2) (num1, num2) = (num2, num1);
                        CurrentQuestion = $"{num1} - {num2} = ?";
                        CorrectAnswer = num1 - num2;
                        break;
                    case "Multiplication":
                        CurrentQuestion = $"{num1} * {num2} = ?";
                        CorrectAnswer = num1 * num2;
                        break;
                    case "Division":
                        if (num2 == 0) num2 = 1;
                        CurrentQuestion = $"{num1 * num2} / {num2} = ?";
                        CorrectAnswer = num1;
                        break;
                }

                QuestionCount++;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if the users input is correct and updates the score accordingly.
        /// </summary>
        /// <param name="answer">User input</param>
        /// <returns>true or false, correct or incorrect.</returns>
        public bool CheckAnswer(int answer)
        {
            try
            {
                if (answer == CorrectAnswer)
                {
                    Score++;
                    return true;
                }
                Incorrect++;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Resets the game to the original state, includes question count, score, incorrect count, elapsed time.
        /// </summary>
        public void Reset()
        {
            try
            {
                QuestionCount = 0;
                Score = 0;
                Incorrect = 0;
                ElapsedTime = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the ElapsedTime variable.
        /// </summary>
        /// <param name="seconds"></param>
        public void UpdateElapsedTime(int seconds)
        {
            try
            {
                ElapsedTime += seconds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
