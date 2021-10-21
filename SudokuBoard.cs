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
        /// The event handler for a click event  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (!sudoku.Parse(sr.ReadToEnd(), loadedPuzzle))
                    MessageBox.Show("Invalid file used, try again.");
                else
                {
                    btn_solve.Enabled = true;
                    btn_solve.Visible = true;
                    sudoku.UpdateBoard(boardCells, loadedPuzzle);
                }
            }
        }

        public void SolveOnClick(Object sender, EventArgs e)
        {
            lbl_loading.Visible = true;
            btn_solve.Enabled = false;
            //this.Invalidate();
            this.Update();
            int[,] solvedBoard = new int[9, 9];
            if (sudoku.Solve(loadedPuzzle, solvedBoard))
            {
                lbl_loading.Visible = false;
                sudoku.UpdateBoard(boardCells, solvedBoard);
            }
        }
    }
}
