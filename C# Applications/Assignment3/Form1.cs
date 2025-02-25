using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment3
{
    /// <summary>
    /// Form for a student score management application.
    /// Handles inputs for student, assignment scores, and displays structures results for each student.
    /// </summary>
    public partial class Scores : Form
    {
        //Total number of students
        private int numStudents;
        //Total number of assignments
        private int numAssignments;
        //Array with names of all students
        private string[] studentNames;
        //Two-dimentional array holding the scores for each student for each assignment
        private int[,] studentScores;
        //index of the currently selected student
        private int currStudent = 0;

        // FileWriter instance
        private FileWriter fileWriter = new FileWriter();


        /// <summary>
        /// initialize the form
        /// </summary>
        public Scores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validate User input for Num students & NumAssignments, ensuring it fits given criteria
        /// create an array of strings and an array of integers for student names and Scores
        /// Set default names and default scores for all students and assignments
        /// Handle Errors and invalid inputs with a Error Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitCntBTN_Click(object sender, EventArgs e)
        {
            //Validate user input 
            if (int.TryParse(NumStudentsTB.Text, out numStudents) && numStudents >= 1 && numStudents <= 10 &&
                int.TryParse(NumAssignmentsTB.Text, out numAssignments) && numAssignments >= 1 && numAssignments <= 99)
            {
                //Create Arrays
                studentNames = new string[numStudents];
                studentScores = new int[numStudents, numAssignments];

                //Default Names
                for (int i = 0; i < numStudents; i++)
                {
                    studentNames[i] = "Student #" + (i + 1);
                }

                //Default Scores for each student and each assignment
                for (int i = 0; i < numStudents; i++)
                {
                    for (int j = 0; j < numAssignments; j++)
                    {
                        studentScores[i, j] = 0;
                    }
                }
                //Reset error if applicable & adjust number of assignments
                Error1LBL.Text = "";
                AssignNumLBL.Text = $"Enter Assignment Number(1-{numAssignments}):";
            }
            //Error handling for Counts section
            else
            {
                Error1LBL.Text = "Invalid. Students must be 1-10, Assignments must be 1-99";
            }
        }

        /// <summary>
        /// The First Student button makes the currStudent Index = 0
        /// UpdateStudentInfo so that the generic name reflects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FStudentBTN_Click(object sender, EventArgs e)
        {
            currStudent = 0;
            UpdateStudentInfo();
        }

        /// <summary>
        /// As long as the Current index is not 0, subtract 1 from current index
        /// This traverses the array backwards
        /// UpdateStudentInfo so that the generic name reflects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PStudentBTN_Click(object sender, EventArgs e)
        {
            //validate user input before traversing the array
            if (currStudent > 0)
            {
                currStudent--;
                UpdateStudentInfo();
            }
        }

        /// <summary>
        /// As long as the current index is not the last index, add 1 to the current index
        /// This traverses the array forwards
        /// UpdateStudentInfo so that the generic name reflects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NStudentBTN_Click(object sender, EventArgs e)
        {
            //validate User input before traversing the array
            if (currStudent < numStudents - 1)
            {
                currStudent++;
                UpdateStudentInfo();
            }
        }

        /// <summary>
        /// Set the current index to equal the last index
        /// UpdateStudentInfo so that the generic name reflects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LStudentBTN_Click(object sender, EventArgs e)
        {
            currStudent = numStudents - 1;
            UpdateStudentInfo();
        }

        /// <summary>
        /// Ensures NumStudents and numAssignments has been set to avoid crashing
        /// Sets the studentNum label to be the saved or generic student name
        /// Sets StudentName textbox to be the saved or generic student name
        /// </summary>
        private void UpdateStudentInfo()
        {
            //Validate User input
            if (numStudents == 0 || numAssignments == 0)
            {
                return;
            }
            //Shows the saved or generic student name, lbl & textbox
            else
            {
                StudentNameTB.Text = studentNames[currStudent];
                StudentNumLBL.Text = studentNames[currStudent] + ":";
            }
        }

        /// <summary>
        /// Ensures NumStudents and numAssignments has been set to avoid crashing
        /// Set the current index name equal to user input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveNameBTN_Click(object sender, EventArgs e)
        {
            //Validate user input
            if (numStudents == 0 || numAssignments == 0)
            {
                return;
            }
            //Set name based on User input
            else
            {
                studentNames[currStudent] = StudentNameTB.Text;
            }
        }

        /// <summary>
        /// On click, validates user input for both Assignment Number and Assignment Score.
        /// If it fits criteria, set the score for current student index and given Assignment Number.
        /// If not, throw a Error Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScoreBTN_Click(object sender, EventArgs e)
        {
            //Validate user input
            if (int.TryParse(AssignNumTB.Text, out int assignmentNum) && assignmentNum >= 1 && assignmentNum <= numAssignments &&
                int.TryParse(AssignScoreTB.Text, out int assignmentScore) && assignmentScore >= 0 && assignmentScore <= 100)
            {
                studentScores[currStudent, assignmentNum - 1] = assignmentScore;
                Error2LBL.Text = "";
            }
            //Error handling
            else
            {
                Error2LBL.Text = "Invalid Assignment Number or Score";
            }
        }

        /// <summary>
        /// Handles displaying each students score for every assignment.
        /// Populated a textbox with student names, assignments, scores, averages, and grades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayScoreBTN_Click(object sender, EventArgs e)
        {
            //For Assignment 7
            OutputToFileBTN.Enabled = true;


            //Instantiate the empty textbox
            ScoreTB.Text = "";
            //Create a string that serves as the header
            string Assignments = "";
            //Takes the number of assignments and evenly distributes them on the textbox
            for (int j = 0; j < numAssignments; j++)
            {
                Assignments = Assignments + $"#{j + 1,-6}";
            }
            //prints the header at the top of the textbox.
            ScoreTB.Text = $"Student             {Assignments} AVG    GRADE  ";

            //Iterates through each student in the array
            for (int i = 0; i < numStudents; i++)
            {
                //string to hold student names for printing
                string name = studentNames[i];
                //string to hold scores for printing
                string AssignmentScores = "";
                
                //iterates through each assignment for each student
                for (int j = 0; j < numAssignments; j++)
                {
                    //adds each score onto the end of the string, evenly distributed
                    AssignmentScores = AssignmentScores + $"{studentScores[i, j],-7}";
                }
                //Takes the average of all scores
                double average = CalculateAverage(i);
                //stores average as a string with a %
                string averageScore = $"{average}%";
                //Stores the letter grade as a string
                string grade = LetterGrade(average);
                //print out scores for each student on individual lines.
                ScoreTB.Text += $"\r\n{name,-19} {AssignmentScores} {averageScore,-8} {grade}";
            }
        }

        /// <summary>
        /// Calculates the average score of all assignments for a selected student.
        /// When called, it sums up each score and divides it by the total number of assignments.
        /// </summary>
        /// <param name="currStudent"></param>
        /// <returns></returns>
        private double CalculateAverage(int currStudent)
        {
            //instantiate the totalscore variable
            int totalScore = 0;
            //iterate through each assignment
            for (int i = 0; i < numAssignments; i++)
            {
                //adds score to total
                totalScore += studentScores[currStudent, i];
            }
            //take total and divide by total number of assignments
            return (double)totalScore / numAssignments;
        }

        /// <summary>
        /// When called, takes the average and compares with grade percentages.
        /// returns LetterGrade of the category it fits.
        /// </summary>
        /// <param name="average"></param>
        /// <returns></returns>
        private string LetterGrade(double average)
        {
            if (average >= 90) return "A";
            if (average >= 80) return "B";
            if (average >= 70) return "C";
            if (average >= 60) return "D";
            return "F";
        }

        /// <summary>
        /// On click, resets every variable to its default.
        /// Resets the form to its original state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBTN_Click(object sender, EventArgs e)
        {
            numStudents = 0;
            numAssignments = 0;
            studentNames = null;
            studentScores = null;
            currStudent = 0;

            NumStudentsTB.Text = "";
            NumAssignmentsTB.Text = "";
            AssignNumTB.Text = "";
            AssignScoreTB.Text = "";
            StudentNameTB.Text = "";
            StudentNumLBL.Text = "Student #1:";
            Error1LBL.Text = "";
            Error2LBL.Text = "";
            ScoreTB.Text = "";

            //Assignment 7
            Error3LBL.Text = "";
            OutputToFileBTN.Enabled = false;

            AssignNumLBL.Text = "Enter Assignment Number (1-X):";
        }



        //Assignment 7 Code

        /// <summary>
        /// OutputToFile button event handler.
        /// On click, validates file name, sets file path, takes scores and calls "WriteToFile"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputToFileBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = fileNameTB.Text.Trim();
                if (string.IsNullOrEmpty(fileName))
                {
                    Error3LBL.Text = "Enter a valid file name";

                    return;
                }

                string filePath = $@"C:\Users\Public\{fileName}.txt";
                string data = ScoreTB.Text;

                // Disable button and show status
                OutputToFileBTN.Enabled = false;
                Error3LBL.Text = "Writing to file ...";

                //Start Writing on background thread
                new Thread(() =>   // https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
                {
                    try
                    {
                        // Mark the thread as a background thread
                        Thread.CurrentThread.IsBackground = true;

                        fileWriter.WriteToFile(filePath, data, (status) =>
                        {
                            // Use Invoke to update the UI after the background operation
                            Invoke(new Action(() =>
                            {
                                Error3LBL.Text = status;
                                OutputToFileBTN.Enabled = true;
                            }));
                        });
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            Error3LBL.Text = "Error occurred while writing to file.";
                            OutputToFileBTN.Enabled = true;
                        }));
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                       MethodInfo.GetCurrentMethod().Name, ex.Message);
                Error3LBL.Text = "Error occurred";
                OutputToFileBTN.Enabled = true;
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
