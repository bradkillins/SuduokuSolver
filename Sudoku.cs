using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuChallenge
{
    public class Sudoku : ISudokuChallenge
    {
        const int SIZE = 9;

        /// <summary>
        /// Sets up a list of Lables to be used as the display for the 9 x 9 gameboard.
        /// </summary>
        /// <param name="form">The form in which the gameboard will be loaded.</param>
        /// <param name="panel">The panel that dictakes the size and location of the gameboard.</param>
        /// <param name="cells">The list of Lables that represent the cells of the board.</param>
        public void SetupBoard(Form form, Panel panel, List<Label> cells)
        {
            const int OFFSET = 2; //number of pixels to offset the grid to the right

            for (int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    Label boardCell = new Label();
                    boardCell.Name = $"lbl_cell{r}{c}";
                    //Cell size is calculated based on the game panel's dimensions
                    boardCell.MaximumSize = new Size(
                        (int)((panel.Width - panel.Width * 0.05) / SIZE),
                        (int)((panel.Height - panel.Height * 0.05) / SIZE)
                    );
                    boardCell.Size = boardCell.MinimumSize = boardCell.MaximumSize;
                    //Cells are placed in 3x3 groupings, with 2.5% panel witdh/height between each grouping
                    boardCell.Location = new Point(
                        panel.Location.X + (int)(c < 3 ? boardCell.Width * c : c < 6 ? boardCell.Width * c + panel.Width * 0.025 : boardCell.Width * c + panel.Width * 0.05) + OFFSET,
                        panel.Location.Y + (int)(r < 3 ? boardCell.Height * r : r < 6 ? boardCell.Height * r + panel.Height * 0.025 : boardCell.Height * r + panel.Height * 0.05) + OFFSET
                    );
                    //Cell's appearance
                    boardCell.BackColor = Color.White;
                    boardCell.Font = new Font("Segoe UI Semibold", 24f, FontStyle.Regular);
                    boardCell.BorderStyle = BorderStyle.FixedSingle;
                    boardCell.TextAlign = ContentAlignment.MiddleCenter;
                    //Adding to Form's controls and list of cells
                    form.Controls.Add(boardCell);
                    cells.Add(boardCell);
                    boardCell.BringToFront();
                }
            }
        }

        /// <summary>
        /// Updates the gameboard's list of lables to display the digits in a 9x9 int array. 
        /// </summary>
        /// <param name="cells">The list of labels that represent the gameboard display.</param>
        /// <param name="newBoard">The 9x9 int array that has the new set of digits to display.</param>
        public void UpdateBoard(List<Label> cells, int[,] newBoard)
        {
            int index = 0;
            for (int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    int value = newBoard[r, c];
                    cells[index++].Text = value > 0 ? value.ToString() : String.Empty;
                }
            }
        }

        /// <summary>
        /// Parse a string for a Sudoku puzzle and fill out a 9x9 int array. 
        /// Looks for 81 digits 0-9 and the '*' character where * and 0 represent
        /// a blank cell in the puzzle.
        /// </summary>
        /// <param name="content">The string that has 81 digits or '*' charaters.</param>
        /// <param name="board">The 2d 9x9 array to store the resulting parsed puzzle.</param>
        /// <returns></returns>
        public bool Parse(string content, int[,] board)
        {
            int r = 0, c = 0;
            foreach (char ch in content)
            {
                if(Char.IsDigit(ch) || ch == '.')
                {
                    //'*' stored as 0
                    board[r, c++] = (ch == '.') ? 0 : Int32.Parse(ch.ToString());
                    if (c == SIZE)
                    {
                        r++;
                        c = 0;
                    }
                    
                }
            }
            //Check that a 9x9 grid, or 81 digits 
            return r == 9 && c == 0;
        }

        /// <summary>
        /// Takes a partially complete Sudoku puzzle in the form of a 2d 9x9 int array and 
        /// Solves it if possible. 0s are treated as blank cells.
        /// </summary>
        /// <param name="inputBoard">The partially complete 9x9 int array.</param>
        /// <param name="solvedBoard">The 2d 9x9 array to store the solution.</param>
        /// <returns>Ture if a valid solution was found.</returns>
        public bool Solve(int[,] inputBoard, int[,] solvedBoard)
        {
            CopyArray(inputBoard, solvedBoard);
            return SolveRecursive(inputBoard, solvedBoard, 0);
        }

        /// <summary>
        /// Recursivly solves a sudoku puzzle. 
        /// </summary>
        /// <param name="inputBoard">The partially complete 9x9 int array.</param>
        /// <param name="solvedBoard">The 2d 9x9 array to store the solution.</param>
        /// <param name="cell">The cell number currently being examinied. 0 to 80 cells in a 9x9 grid.</param>
        /// <returns>True if a valid solution is found.</returns>
        bool SolveRecursive(int[,] inputBoard, int[,] solvedBoard, int cell) 
        {
            int r = cell / SIZE;
            int c = cell % SIZE;
            
            //should only reach the 81st cell if a solution hhas been found
            if (cell == SIZE * SIZE) return true; 

            //check if current cell is an answer from the input board then skip accordingly
            if(inputBoard[r,c]>0)
                return SolveRecursive(inputBoard, solvedBoard, cell + 1);
            
            //check valid digits from 1 - 9
            for (int i = 1; i < 10; i++)
            {
                if (ValidCell(solvedBoard, cell, i))
                {
                    //assign the current number in the loop then recursively check 
                    //if the remaining cells in the board are vaild, otherwise come back
                    //and increase this cell and check again
                    solvedBoard[r, c] = i;
                    if (SolveRecursive(inputBoard, solvedBoard, cell + 1)) return true;
                }
                //reset to zero if not valid cell 
                solvedBoard[r, c] = 0;
            }
            //if no digits from 1-9 are valid then there is no solution to the puzzle
            return false;
        }

        /// <summary>
        /// Checks if a number could be inserted into a cell in the puzzle.
        /// </summary>
        /// <param name="board">The puzzle to check.</param>
        /// <param name="cell">The cell to check.</param>
        /// <param name="num">The number to be inserted into the cell.</param>
        /// <returns></returns>
        bool ValidCell(int[,] board, int cell, int num)
        {
            int r = cell / 9;
            int c = cell % 9;
            return ValidRow(board, r, num) && ValidCol(board, c, num) && ValidBlock(board, r, c, num);
        }
        bool ValidRow(int[,] board, int r, int num)
        {
            for (int c = 0; c < SIZE; c++)
                if (board[r, c] == num) return false;

            return true;
        }
        bool ValidCol(int[,] board, int c, int num)
        {
            for (int r = 0; r < SIZE; r++)
                if (board[r, c] == num) return false;
            return true;
        }
        bool ValidBlock(int[,] board, int r, int c, int num)
        {
            //set the row and colum values to the top left cell in its block
            r = r > 5 ? 6 : r > 2 ? 3 : 0;
            c = c > 5 ? 6 : c > 2 ? 3 : 0;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[r + i, c + j] == num) 
                        return false;

            return true;
        }
        
        /// <summary>
        /// A helper function that copies one 2d array to another.
        /// </summary>
        void CopyArray(int[,] copyFrom, int[,] copyTo)
        {
            for (int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    copyTo[r, c] = copyFrom[r, c];
                }
            }
        }
    }
}
