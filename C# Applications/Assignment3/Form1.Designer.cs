using System;

namespace Assignment3
{
    partial class Scores
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
            this.CountsGB = new System.Windows.Forms.GroupBox();
            this.Error1LBL = new System.Windows.Forms.Label();
            this.SubmitCntBTN = new System.Windows.Forms.Button();
            this.NumAssignmentsTB = new System.Windows.Forms.TextBox();
            this.NumStudentsTB = new System.Windows.Forms.TextBox();
            this.NumAssignLBL = new System.Windows.Forms.Label();
            this.NumStudentLBL = new System.Windows.Forms.Label();
            this.NavigateGB = new System.Windows.Forms.GroupBox();
            this.LStudentBTN = new System.Windows.Forms.Button();
            this.NStudentBTN = new System.Windows.Forms.Button();
            this.PStudentBTN = new System.Windows.Forms.Button();
            this.FStudentBTN = new System.Windows.Forms.Button();
            this.StudentInfoGB = new System.Windows.Forms.GroupBox();
            this.SaveNameBTN = new System.Windows.Forms.Button();
            this.StudentNameTB = new System.Windows.Forms.TextBox();
            this.StudentNumLBL = new System.Windows.Forms.Label();
            this.ResetBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Error2LBL = new System.Windows.Forms.Label();
            this.AssignScoreTB = new System.Windows.Forms.TextBox();
            this.AssignScoreLBL = new System.Windows.Forms.Label();
            this.SaveScoreBTN = new System.Windows.Forms.Button();
            this.AssignNumTB = new System.Windows.Forms.TextBox();
            this.AssignNumLBL = new System.Windows.Forms.Label();
            this.DisplayScoreBTN = new System.Windows.Forms.Button();
            this.ScoreTB = new System.Windows.Forms.TextBox();
            this.OutputToFileBTN = new System.Windows.Forms.Button();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.Error3LBL = new System.Windows.Forms.Label();
            this.CountsGB.SuspendLayout();
            this.NavigateGB.SuspendLayout();
            this.StudentInfoGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CountsGB
            // 
            this.CountsGB.Controls.Add(this.Error1LBL);
            this.CountsGB.Controls.Add(this.SubmitCntBTN);
            this.CountsGB.Controls.Add(this.NumAssignmentsTB);
            this.CountsGB.Controls.Add(this.NumStudentsTB);
            this.CountsGB.Controls.Add(this.NumAssignLBL);
            this.CountsGB.Controls.Add(this.NumStudentLBL);
            this.CountsGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountsGB.Location = new System.Drawing.Point(16, 25);
            this.CountsGB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CountsGB.Name = "CountsGB";
            this.CountsGB.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CountsGB.Size = new System.Drawing.Size(442, 87);
            this.CountsGB.TabIndex = 0;
            this.CountsGB.TabStop = false;
            this.CountsGB.Text = "Counts";
            // 
            // Error1LBL
            // 
            this.Error1LBL.AutoSize = true;
            this.Error1LBL.ForeColor = System.Drawing.Color.Red;
            this.Error1LBL.Location = new System.Drawing.Point(211, 1);
            this.Error1LBL.Name = "Error1LBL";
            this.Error1LBL.Size = new System.Drawing.Size(0, 13);
            this.Error1LBL.TabIndex = 5;
            // 
            // SubmitCntBTN
            // 
            this.SubmitCntBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SubmitCntBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SubmitCntBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SubmitCntBTN.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitCntBTN.ForeColor = System.Drawing.Color.Black;
            this.SubmitCntBTN.Location = new System.Drawing.Point(310, 25);
            this.SubmitCntBTN.Name = "SubmitCntBTN";
            this.SubmitCntBTN.Size = new System.Drawing.Size(115, 45);
            this.SubmitCntBTN.TabIndex = 4;
            this.SubmitCntBTN.Text = "Submit Counts";
            this.SubmitCntBTN.UseVisualStyleBackColor = false;
            this.SubmitCntBTN.Click += new System.EventHandler(this.SubmitCntBTN_Click);
            // 
            // NumAssignmentsTB
            // 
            this.NumAssignmentsTB.Location = new System.Drawing.Point(214, 61);
            this.NumAssignmentsTB.Name = "NumAssignmentsTB";
            this.NumAssignmentsTB.Size = new System.Drawing.Size(77, 20);
            this.NumAssignmentsTB.TabIndex = 3;
            // 
            // NumStudentsTB
            // 
            this.NumStudentsTB.Location = new System.Drawing.Point(214, 17);
            this.NumStudentsTB.Name = "NumStudentsTB";
            this.NumStudentsTB.Size = new System.Drawing.Size(77, 20);
            this.NumStudentsTB.TabIndex = 2;
            // 
            // NumAssignLBL
            // 
            this.NumAssignLBL.AutoSize = true;
            this.NumAssignLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAssignLBL.Location = new System.Drawing.Point(6, 60);
            this.NumAssignLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumAssignLBL.Name = "NumAssignLBL";
            this.NumAssignLBL.Size = new System.Drawing.Size(193, 18);
            this.NumAssignLBL.TabIndex = 1;
            this.NumAssignLBL.Text = "Number of Assignments:";
            // 
            // NumStudentLBL
            // 
            this.NumStudentLBL.AutoSize = true;
            this.NumStudentLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumStudentLBL.Location = new System.Drawing.Point(36, 16);
            this.NumStudentLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumStudentLBL.Name = "NumStudentLBL";
            this.NumStudentLBL.Size = new System.Drawing.Size(163, 18);
            this.NumStudentLBL.TabIndex = 0;
            this.NumStudentLBL.Text = "Number of Students:";
            // 
            // NavigateGB
            // 
            this.NavigateGB.Controls.Add(this.LStudentBTN);
            this.NavigateGB.Controls.Add(this.NStudentBTN);
            this.NavigateGB.Controls.Add(this.PStudentBTN);
            this.NavigateGB.Controls.Add(this.FStudentBTN);
            this.NavigateGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavigateGB.Location = new System.Drawing.Point(16, 118);
            this.NavigateGB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NavigateGB.Name = "NavigateGB";
            this.NavigateGB.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NavigateGB.Size = new System.Drawing.Size(547, 68);
            this.NavigateGB.TabIndex = 1;
            this.NavigateGB.TabStop = false;
            this.NavigateGB.Text = "Navigate";
            // 
            // LStudentBTN
            // 
            this.LStudentBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LStudentBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LStudentBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LStudentBTN.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStudentBTN.Location = new System.Drawing.Point(410, 19);
            this.LStudentBTN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LStudentBTN.Name = "LStudentBTN";
            this.LStudentBTN.Size = new System.Drawing.Size(126, 33);
            this.LStudentBTN.TabIndex = 3;
            this.LStudentBTN.Text = "Last Student>>";
            this.LStudentBTN.UseVisualStyleBackColor = false;
            this.LStudentBTN.Click += new System.EventHandler(this.LStudentBTN_Click);
            // 
            // NStudentBTN
            // 
            this.NStudentBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.NStudentBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.NStudentBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NStudentBTN.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NStudentBTN.Location = new System.Drawing.Point(276, 19);
            this.NStudentBTN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NStudentBTN.Name = "NStudentBTN";
            this.NStudentBTN.Size = new System.Drawing.Size(126, 33);
            this.NStudentBTN.TabIndex = 2;
            this.NStudentBTN.Text = "Next Student>";
            this.NStudentBTN.UseVisualStyleBackColor = false;
            this.NStudentBTN.Click += new System.EventHandler(this.NStudentBTN_Click);
            // 
            // PStudentBTN
            // 
            this.PStudentBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PStudentBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PStudentBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PStudentBTN.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PStudentBTN.Location = new System.Drawing.Point(142, 19);
            this.PStudentBTN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PStudentBTN.Name = "PStudentBTN";
            this.PStudentBTN.Size = new System.Drawing.Size(126, 33);
            this.PStudentBTN.TabIndex = 1;
            this.PStudentBTN.Text = "<Prev Student";
            this.PStudentBTN.UseVisualStyleBackColor = false;
            this.PStudentBTN.Click += new System.EventHandler(this.PStudentBTN_Click);
            // 
            // FStudentBTN
            // 
            this.FStudentBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.FStudentBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.FStudentBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FStudentBTN.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FStudentBTN.Location = new System.Drawing.Point(8, 19);
            this.FStudentBTN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FStudentBTN.Name = "FStudentBTN";
            this.FStudentBTN.Size = new System.Drawing.Size(126, 33);
            this.FStudentBTN.TabIndex = 0;
            this.FStudentBTN.Text = "<<First Student";
            this.FStudentBTN.UseVisualStyleBackColor = false;
            this.FStudentBTN.Click += new System.EventHandler(this.FStudentBTN_Click);
            // 
            // StudentInfoGB
            // 
            this.StudentInfoGB.Controls.Add(this.SaveNameBTN);
            this.StudentInfoGB.Controls.Add(this.StudentNameTB);
            this.StudentInfoGB.Controls.Add(this.StudentNumLBL);
            this.StudentInfoGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentInfoGB.Location = new System.Drawing.Point(16, 192);
            this.StudentInfoGB.Name = "StudentInfoGB";
            this.StudentInfoGB.Size = new System.Drawing.Size(547, 58);
            this.StudentInfoGB.TabIndex = 2;
            this.StudentInfoGB.TabStop = false;
            this.StudentInfoGB.Text = "Student Info";
            // 
            // SaveNameBTN
            // 
            this.SaveNameBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveNameBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveNameBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveNameBTN.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNameBTN.ForeColor = System.Drawing.Color.Black;
            this.SaveNameBTN.Location = new System.Drawing.Point(413, 22);
            this.SaveNameBTN.Name = "SaveNameBTN";
            this.SaveNameBTN.Size = new System.Drawing.Size(115, 29);
            this.SaveNameBTN.TabIndex = 5;
            this.SaveNameBTN.Text = "Save Name";
            this.SaveNameBTN.UseVisualStyleBackColor = false;
            this.SaveNameBTN.Click += new System.EventHandler(this.SaveNameBTN_Click);
            // 
            // StudentNameTB
            // 
            this.StudentNameTB.AccessibleDescription = "";
            this.StudentNameTB.Location = new System.Drawing.Point(122, 27);
            this.StudentNameTB.Name = "StudentNameTB";
            this.StudentNameTB.Size = new System.Drawing.Size(266, 20);
            this.StudentNameTB.TabIndex = 5;
            this.StudentNameTB.Tag = "";
            // 
            // StudentNumLBL
            // 
            this.StudentNumLBL.AutoSize = true;
            this.StudentNumLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentNumLBL.Location = new System.Drawing.Point(7, 26);
            this.StudentNumLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StudentNumLBL.Name = "StudentNumLBL";
            this.StudentNumLBL.Size = new System.Drawing.Size(93, 18);
            this.StudentNumLBL.TabIndex = 5;
            this.StudentNumLBL.Text = "Student #1:";
            // 
            // ResetBTN
            // 
            this.ResetBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ResetBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.ResetBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ResetBTN.Font = new System.Drawing.Font("Cascadia Code", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBTN.ForeColor = System.Drawing.Color.Black;
            this.ResetBTN.Location = new System.Drawing.Point(471, 43);
            this.ResetBTN.Name = "ResetBTN";
            this.ResetBTN.Size = new System.Drawing.Size(91, 59);
            this.ResetBTN.TabIndex = 3;
            this.ResetBTN.Text = "RESET SCORES";
            this.ResetBTN.UseVisualStyleBackColor = false;
            this.ResetBTN.Click += new System.EventHandler(this.ResetBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Error2LBL);
            this.groupBox1.Controls.Add(this.AssignScoreTB);
            this.groupBox1.Controls.Add(this.AssignScoreLBL);
            this.groupBox1.Controls.Add(this.SaveScoreBTN);
            this.groupBox1.Controls.Add(this.AssignNumTB);
            this.groupBox1.Controls.Add(this.AssignNumLBL);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Info";
            // 
            // Error2LBL
            // 
            this.Error2LBL.AutoSize = true;
            this.Error2LBL.ForeColor = System.Drawing.Color.Red;
            this.Error2LBL.Location = new System.Drawing.Point(273, 11);
            this.Error2LBL.Name = "Error2LBL";
            this.Error2LBL.Size = new System.Drawing.Size(0, 13);
            this.Error2LBL.TabIndex = 6;
            // 
            // AssignScoreTB
            // 
            this.AssignScoreTB.AccessibleDescription = "";
            this.AssignScoreTB.Location = new System.Drawing.Point(276, 63);
            this.AssignScoreTB.Name = "AssignScoreTB";
            this.AssignScoreTB.Size = new System.Drawing.Size(112, 20);
            this.AssignScoreTB.TabIndex = 7;
            this.AssignScoreTB.Tag = "";
            // 
            // AssignScoreLBL
            // 
            this.AssignScoreLBL.AutoSize = true;
            this.AssignScoreLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignScoreLBL.Location = new System.Drawing.Point(64, 63);
            this.AssignScoreLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AssignScoreLBL.Name = "AssignScoreLBL";
            this.AssignScoreLBL.Size = new System.Drawing.Size(195, 18);
            this.AssignScoreLBL.TabIndex = 6;
            this.AssignScoreLBL.Text = "Enter Assignment Score:";
            // 
            // SaveScoreBTN
            // 
            this.SaveScoreBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveScoreBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveScoreBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveScoreBTN.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveScoreBTN.ForeColor = System.Drawing.Color.Black;
            this.SaveScoreBTN.Location = new System.Drawing.Point(413, 42);
            this.SaveScoreBTN.Name = "SaveScoreBTN";
            this.SaveScoreBTN.Size = new System.Drawing.Size(115, 29);
            this.SaveScoreBTN.TabIndex = 5;
            this.SaveScoreBTN.Text = "Save Score";
            this.SaveScoreBTN.UseVisualStyleBackColor = false;
            this.SaveScoreBTN.Click += new System.EventHandler(this.SaveScoreBTN_Click);
            // 
            // AssignNumTB
            // 
            this.AssignNumTB.AccessibleDescription = "";
            this.AssignNumTB.Location = new System.Drawing.Point(276, 27);
            this.AssignNumTB.Name = "AssignNumTB";
            this.AssignNumTB.Size = new System.Drawing.Size(112, 20);
            this.AssignNumTB.TabIndex = 5;
            this.AssignNumTB.Tag = "";
            // 
            // AssignNumLBL
            // 
            this.AssignNumLBL.AutoSize = true;
            this.AssignNumLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignNumLBL.Location = new System.Drawing.Point(7, 26);
            this.AssignNumLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AssignNumLBL.Name = "AssignNumLBL";
            this.AssignNumLBL.Size = new System.Drawing.Size(252, 18);
            this.AssignNumLBL.TabIndex = 5;
            this.AssignNumLBL.Text = "Enter Assignment Number (1-X):";
            // 
            // DisplayScoreBTN
            // 
            this.DisplayScoreBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.DisplayScoreBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.DisplayScoreBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DisplayScoreBTN.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayScoreBTN.ForeColor = System.Drawing.Color.Black;
            this.DisplayScoreBTN.Location = new System.Drawing.Point(36, 359);
            this.DisplayScoreBTN.Name = "DisplayScoreBTN";
            this.DisplayScoreBTN.Size = new System.Drawing.Size(139, 29);
            this.DisplayScoreBTN.TabIndex = 8;
            this.DisplayScoreBTN.Text = "Display Scores";
            this.DisplayScoreBTN.UseVisualStyleBackColor = false;
            this.DisplayScoreBTN.Click += new System.EventHandler(this.DisplayScoreBTN_Click);
            // 
            // ScoreTB
            // 
            this.ScoreTB.Font = new System.Drawing.Font("Cascadia Code SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreTB.Location = new System.Drawing.Point(16, 394);
            this.ScoreTB.Multiline = true;
            this.ScoreTB.Name = "ScoreTB";
            this.ScoreTB.ReadOnly = true;
            this.ScoreTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ScoreTB.Size = new System.Drawing.Size(547, 135);
            this.ScoreTB.TabIndex = 10;
            this.ScoreTB.WordWrap = false;
            // 
            // OutputToFileBTN
            // 
            this.OutputToFileBTN.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.OutputToFileBTN.Enabled = false;
            this.OutputToFileBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.OutputToFileBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputToFileBTN.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputToFileBTN.ForeColor = System.Drawing.Color.Black;
            this.OutputToFileBTN.Location = new System.Drawing.Point(230, 359);
            this.OutputToFileBTN.Name = "OutputToFileBTN";
            this.OutputToFileBTN.Size = new System.Drawing.Size(139, 29);
            this.OutputToFileBTN.TabIndex = 11;
            this.OutputToFileBTN.Text = "Output to File";
            this.OutputToFileBTN.UseVisualStyleBackColor = false;
            this.OutputToFileBTN.Click += new System.EventHandler(this.OutputToFileBTN_Click);
            // 
            // fileNameTB
            // 
            this.fileNameTB.Location = new System.Drawing.Point(381, 365);
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(163, 20);
            this.fileNameTB.TabIndex = 6;
            // 
            // Error3LBL
            // 
            this.Error3LBL.AutoSize = true;
            this.Error3LBL.ForeColor = System.Drawing.Color.Red;
            this.Error3LBL.Location = new System.Drawing.Point(371, 349);
            this.Error3LBL.Name = "Error3LBL";
            this.Error3LBL.Size = new System.Drawing.Size(0, 13);
            this.Error3LBL.TabIndex = 8;
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(583, 541);
            this.Controls.Add(this.Error3LBL);
            this.Controls.Add(this.fileNameTB);
            this.Controls.Add(this.OutputToFileBTN);
            this.Controls.Add(this.ScoreTB);
            this.Controls.Add(this.DisplayScoreBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResetBTN);
            this.Controls.Add(this.StudentInfoGB);
            this.Controls.Add(this.NavigateGB);
            this.Controls.Add(this.CountsGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Scores";
            this.Text = "Student Score Management";
            this.CountsGB.ResumeLayout(false);
            this.CountsGB.PerformLayout();
            this.NavigateGB.ResumeLayout(false);
            this.StudentInfoGB.ResumeLayout(false);
            this.StudentInfoGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.GroupBox CountsGB;
        private System.Windows.Forms.GroupBox NavigateGB;
        private System.Windows.Forms.Button LStudentBTN;
        private System.Windows.Forms.Button NStudentBTN;
        private System.Windows.Forms.Button PStudentBTN;
        private System.Windows.Forms.Button FStudentBTN;
        private System.Windows.Forms.Label NumAssignLBL;
        private System.Windows.Forms.Label NumStudentLBL;
        private System.Windows.Forms.Button SubmitCntBTN;
        private System.Windows.Forms.TextBox NumAssignmentsTB;
        private System.Windows.Forms.TextBox NumStudentsTB;
        private System.Windows.Forms.GroupBox StudentInfoGB;
        private System.Windows.Forms.Label StudentNumLBL;
        private System.Windows.Forms.Button SaveNameBTN;
        private System.Windows.Forms.TextBox StudentNameTB;
        private System.Windows.Forms.Button ResetBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AssignScoreTB;
        private System.Windows.Forms.Label AssignScoreLBL;
        private System.Windows.Forms.Button SaveScoreBTN;
        private System.Windows.Forms.TextBox AssignNumTB;
        private System.Windows.Forms.Label AssignNumLBL;
        private System.Windows.Forms.Button DisplayScoreBTN;
        private EventHandler Form1_Load;
        private System.Windows.Forms.Label Error1LBL;
        private System.Windows.Forms.Label Error2LBL;
        private System.Windows.Forms.TextBox ScoreTB;
        private System.Windows.Forms.Button OutputToFileBTN;
        private System.Windows.Forms.TextBox fileNameTB;
        private System.Windows.Forms.Label Error3LBL;
    }
}

