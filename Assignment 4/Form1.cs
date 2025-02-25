using System.Numerics;

namespace Assignment_4
{
    /// <summary>
    /// The main form holding my Tic Tac Toe Game form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The game instance that handles the Tic Tac Toe logic.
        /// </summary>
        private TicTacToeGame game;

        /// <summary>
        /// A 2D array of buttons representing the Tic Tac Toe board.
        /// </summary>
        private Button[,] buttons;

        /// <summary>
        /// The count of Player 1 wins.
        /// </summary>
        private int player1Wins;

        /// <summary>
        /// The count of Player 2 wins.
        /// </summary>
        private int player2Wins;

        /// <summary>
        /// The count of ties.
        /// </summary>
        private int ties;
        /// <summary>
        /// Initializes the form and sets up buttons for the game.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            game = new TicTacToeGame();
            buttons = new Button[3, 3] { { TTTBTN1, TTTBTN2, TTTBTN3 }, { TTTBTN4, TTTBTN5, TTTBTN6 }, { TTTBTN7, TTTBTN8, TTTBTN9 } };
            UpdateGameStatus();
        }

        /// <summary>
        /// Handles the click event for all board buttons
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Find row based on button name
            int row = (int.Parse(btn.Name[6].ToString()) - 1) / 3;
            // Find column based on button name
            int col = (int.Parse(btn.Name[6].ToString()) - 1) % 3;

            // Store the current player's symbol before the move is made
            char currentSymbol = game.CurrPlayer;

            if (game.MakeMove(row, col))
            {
                // Set the button text to the current player's symbol
                btn.Text = currentSymbol.ToString();

                if (game.GameOver)
                {
                    (int Row, int Col)[] WinningMove;
                    if (game.CheckWin(row, col, out WinningMove))
                    {
                        UpdateGameStatus($"{btn.Text} Wins!");
                        if (currentSymbol == 'X')
                        {
                            player1Wins++;
                        }
                        else
                        {
                            player2Wins++;
                        }
                        HighlightWin(WinningMove);
                        DisableButtons();
                    }
                    else
                    {
                        UpdateGameStatus("It's a Tie!");
                        ties++;
                        DisableButtons();
                    }
                }
                else
                {
                    UpdateGameStatus();
                }
            }
        }

        /// <summary>
        /// Highlights the Winning buttons on the game board
        /// </summary>
        private void HighlightWin((int Row, int Col)[] WinningMove)
        {
            if (WinningMove != null)
            {
                foreach (var position in WinningMove)
                {
                    buttons[position.Row, position.Col].BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// Updates the GameStatus that dislays player turn and results.
        /// Updates win/tie results
        /// </summary>
        private void UpdateGameStatus(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                GameStatusTXT.Text = $"{ [game.CurrPlayer]}'s turn";
            }
            else
            {
                GameStatusTXT.Text = message;
            }

            //Update win/tie results
            P1WinsLBL.Text = $"Player 1 Wins: {player1Wins}";
            P2WinsLBL.Text = $"Player 2 Wins: {player2Wins}";
            TiesLBL.Text = $"Ties: {ties}";
        }

        /// <summary>
        /// Disable buttons, iterates through each row and column and disable it.
        /// </summary>
        private void DisableButtons()
        {
            {
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Resets the board allowing the user to play again.
        /// </summary>
        private void StartBTN_Click(object sender, EventArgs e)
        {
            game.Reset();
            foreach (Button btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            UpdateGameStatus();
        }


        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN1_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN2_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN3_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN4_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN5_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN6_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN7_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN8_Click(object sender, EventArgs e) => Button_Click(sender, e);
        /// <summary>
        /// Click event for board buttons, each calls the Button_Click method
        /// </summary>
        private void TTTBTN9_Click(object sender, EventArgs e) => Button_Click(sender, e);

    }
}
