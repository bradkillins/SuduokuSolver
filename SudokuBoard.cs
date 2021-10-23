using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuChallenge
{
    public partial class MainForm : Form
    {
        Sudoku sudoku = new Sudoku();
        List<Label> boardCells = new List<Label>();
        int[,] loadedPuzzle = new int[9,9];

        public MainForm()
        {
            InitializeComponent();
            btn_upload.Click += UploadOnClick;
            btn_solve.Click += SolveOnClick;

            sudoku.SetupBoard(this, pnl_gameArea, boardCells);
        }

        /// <summary>
        /// The event handler for the click event of the Upload button.
        /// Opens a file dialog for a user to pick an apropriate file,
        /// then, if that file is valid, loads it to the board and
        /// enables the Solve button.
        /// </summary>
        public void UploadOnClick(Object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() 
            {
                FileName = "Select a file with a Puzzle",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open a Sudoku Puzzle to Solve"
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dialog.FileName);
                if (sudoku.Parse(sr.ReadToEnd(), loadedPuzzle))
                {
                    btn_solve.Enabled = true;
                    btn_solve.Visible = true;
                    sudoku.UpdateBoard(boardCells, loadedPuzzle);
                }
                else
                    MessageBox.Show("Invalid file used, try again.");
                
            }
        }

        /// <summary>
        /// The event handler for the click event of the Solve button.
        /// Calls the solve method on the loaded puzzle and displays 
        /// a loading message while solving. Updates the board with the
        /// solved puzzle if a solution was found, otherwise displays
        /// an error message.
        /// </summary>
        public void SolveOnClick(Object sender, EventArgs e)
        {
            lbl_loading.Visible = true;
            btn_solve.Enabled = false;
            Update();
            int[,] solvedBoard = new int[9, 9];
            if (sudoku.Solve(loadedPuzzle, solvedBoard))
            {
                lbl_loading.Visible = false;
                sudoku.UpdateBoard(boardCells, solvedBoard);
            }
            else
            {
                lbl_loading.Visible = false;
                MessageBox.Show("Invalid puzzel, could not find a solution.");
            }
        }
    }
}
