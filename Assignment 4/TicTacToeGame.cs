using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    /// <summary>
    /// Class holding Logic for the Tic Tac Toe game.
    /// </summary>
    public class TicTacToeGame
    {
        /// <summary>
        /// Creates a 2d array to hold board data
        /// </summary>
        public char[,] Board { get; private set; }
        /// <summary>
        /// Represents current player in the game, either x or o
        /// </summary>
        public char CurrPlayer { get; private set; }
        /// <summary>
        /// Indicates when the game is over.
        /// True when a player has won or there is a tie.
        /// </summary>
        public bool GameOver { get; private set; }
        /// <summary>
        /// This is how I was able to highlight the winning move.
        /// This holds data for the move that won the game.
        /// </summary>
        public (int row, int)[] WinningMove { get; private set; }

        /// <summary>
        /// Constructor for the tic tac toe game.
        /// makes a 3x3 array to represent the game.
        /// </summary>
        public TicTacToeGame()
        {
            Board = new char[3, 3];
            Reset();
        }

        /// <summary>
        /// Resets the board, sets each button back to original and changes player turn to X
        /// </summary>
        public void Reset()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Board[row, col] = ' ';
                }
            }
            CurrPlayer = 'X';
            GameOver = false;
        }

        /// <summary>
        /// Checks if given button is empty and game is not over.
        /// Calls checkWin.
        /// Calls CheckTie.
        /// Calls SwitchPlayer
        /// </summary>
        public bool MakeMove(int row, int col)
        {
            if (Board[row, col] == ' ' && !GameOver)
            {
                Board[row, col] = CurrPlayer;
                (int Row, int Col)[] WinningMove;

                if (CheckWin(row, col, out WinningMove))
                {
                    GameOver = true;
                    return true;

                }
                else if (CheckTie())
                {
                    GameOver = true;
                    return true;
                }
                SwitchPlayer();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes the input button and checks if it makes a win.
        /// Checks row, then column, then diagonals.
        /// </summary>
        public bool CheckWin(int row, int col, out(int Row, int Col)[] WinningMove)
        {
            WinningMove = null;
            if (Board[row, 0] == CurrPlayer && Board[row, 1] == CurrPlayer && Board[row, 2] == CurrPlayer)
            {
                WinningMove = new[] { (row, 0), (row, 1), (row, 2) };
                return true;
            }
            if (Board[0, col] == CurrPlayer && Board[1, col] == CurrPlayer && Board[2, col] == CurrPlayer)
            {    
                WinningMove = new[] {(0,col), (1,col), (2,col)};
                return true; 
            }
            if (Board[0, 0] == CurrPlayer && Board[1, 1] == CurrPlayer && Board[2, 2] == CurrPlayer)
            {
                WinningMove = new[] { (0, 0), (1, 1), (2, 2) };
                return true;
            }
            if (Board[0, 2] == CurrPlayer && Board[1, 1] == CurrPlayer && Board[2, 0] == CurrPlayer)
            {
                WinningMove = new[] { (0, 2), (1, 1), (2, 0) };
                return true;
            }
            return false;
        }

        /// <summary>
        /// Loops through each row and column, Checks if any are empty.
        /// Returns true if board is full, returns false if board has empty spots.
        /// </summary>
        public bool CheckTie()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// One Line if else, Checks what the current player is then changes to the opposite.
        /// </summary>
        private void SwitchPlayer()
        {
            CurrPlayer = CurrPlayer == 'X' ? 'O' : 'X';
        }
    }
}
