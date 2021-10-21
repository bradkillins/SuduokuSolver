namespace SudokuChallenge
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_upload = new System.Windows.Forms.Button();
            this.pnl_gameArea = new System.Windows.Forms.Panel();
            this.lbl_upload = new System.Windows.Forms.Label();
            this.btn_solve = new System.Windows.Forms.Button();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.SystemColors.Control;
            this.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_upload.Location = new System.Drawing.Point(681, 143);
            this.btn_upload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(112, 37);
            this.btn_upload.TabIndex = 0;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = false;
            // 
            // pnl_gameArea
            // 
            this.pnl_gameArea.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnl_gameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_gameArea.Location = new System.Drawing.Point(12, 12);
            this.pnl_gameArea.Name = "pnl_gameArea";
            this.pnl_gameArea.Size = new System.Drawing.Size(600, 600);
            this.pnl_gameArea.TabIndex = 1;
            // 
            // lbl_upload
            // 
            this.lbl_upload.AutoSize = true;
            this.lbl_upload.Location = new System.Drawing.Point(628, 79);
            this.lbl_upload.MaximumSize = new System.Drawing.Size(220, 60);
            this.lbl_upload.Name = "lbl_upload";
            this.lbl_upload.Size = new System.Drawing.Size(219, 42);
            this.lbl_upload.TabIndex = 2;
            this.lbl_upload.Text = "Upload a text file that contains an unsolved Suduko Puzzle";
            this.lbl_upload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_solve
            // 
            this.btn_solve.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_solve.Enabled = false;
            this.btn_solve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_solve.Location = new System.Drawing.Point(681, 550);
            this.btn_solve.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(112, 37);
            this.btn_solve.TabIndex = 3;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = false;
            this.btn_solve.Visible = false;
            // 
            // lbl_loading
            // 
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.Location = new System.Drawing.Point(631, 503);
            this.lbl_loading.MaximumSize = new System.Drawing.Size(220, 60);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(210, 42);
            this.lbl_loading.TabIndex = 4;
            this.lbl_loading.Text = "Loading...... This may take some time, Please be patient.";
            this.lbl_loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_loading.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(862, 626);
            this.Controls.Add(this.lbl_loading);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.lbl_upload);
            this.Controls.Add(this.pnl_gameArea);
            this.Controls.Add(this.btn_upload);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Suduko Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Panel pnl_gameArea;
        private System.Windows.Forms.Label lbl_upload;
        private System.Windows.Forms.Button btn_solve;
        private System.Windows.Forms.Label lbl_loading;
    }
}

