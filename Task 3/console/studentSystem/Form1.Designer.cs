
namespace studentSystem
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.studentListBox = new System.Windows.Forms.ListBox();
            this.studentNameLookupLabel = new System.Windows.Forms.Label();
            this.studentNameTextBox = new System.Windows.Forms.TextBox();
            this.studentInformationListBox = new System.Windows.Forms.ListBox();
            this.editStudentButton = new System.Windows.Forms.Button();
            this.deleteStudentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create New Student";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // studentListBox
            // 
            this.studentListBox.FormattingEnabled = true;
            this.studentListBox.Location = new System.Drawing.Point(12, 55);
            this.studentListBox.Name = "studentListBox";
            this.studentListBox.Size = new System.Drawing.Size(167, 329);
            this.studentListBox.TabIndex = 1;
            this.studentListBox.SelectedIndexChanged += new System.EventHandler(this.studentListBox_SelectedIndexChanged);
            // 
            // studentNameLookupLabel
            // 
            this.studentNameLookupLabel.AutoSize = true;
            this.studentNameLookupLabel.Location = new System.Drawing.Point(41, 385);
            this.studentNameLookupLabel.Name = "studentNameLookupLabel";
            this.studentNameLookupLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.studentNameLookupLabel.Size = new System.Drawing.Size(103, 13);
            this.studentNameLookupLabel.TabIndex = 2;
            this.studentNameLookupLabel.Text = "Enter Student Name";
            // 
            // studentNameTextBox
            // 
            this.studentNameTextBox.Location = new System.Drawing.Point(12, 401);
            this.studentNameTextBox.Name = "studentNameTextBox";
            this.studentNameTextBox.Size = new System.Drawing.Size(167, 20);
            this.studentNameTextBox.TabIndex = 3;
            this.studentNameTextBox.TextChanged += new System.EventHandler(this.studentNameTextBox_TextChanged);
            // 
            // studentInformationListBox
            // 
            this.studentInformationListBox.FormattingEnabled = true;
            this.studentInformationListBox.Location = new System.Drawing.Point(185, 55);
            this.studentInformationListBox.Name = "studentInformationListBox";
            this.studentInformationListBox.Size = new System.Drawing.Size(180, 251);
            this.studentInformationListBox.TabIndex = 4;
            this.studentInformationListBox.SelectedIndexChanged += new System.EventHandler(this.studentInformationListBox_SelectedIndexChanged);
            this.studentInformationListBox.Visible = false;
            // 
            // editStudentButton
            // 
            this.editStudentButton.Location = new System.Drawing.Point(185, 309);
            this.editStudentButton.Name = "editStudentButton";
            this.editStudentButton.Size = new System.Drawing.Size(180, 35);
            this.editStudentButton.TabIndex = 5;
            this.editStudentButton.Text = "Edit Student";
            this.editStudentButton.UseVisualStyleBackColor = true;
            this.editStudentButton.Visible = false;
            // 
            // deleteStudentButton
            // 
            this.deleteStudentButton.Location = new System.Drawing.Point(185, 350);
            this.deleteStudentButton.Name = "deleteStudentButton";
            this.deleteStudentButton.Size = new System.Drawing.Size(180, 34);
            this.deleteStudentButton.TabIndex = 6;
            this.deleteStudentButton.Text = "Delete Student";
            this.deleteStudentButton.UseVisualStyleBackColor = true;
            this.deleteStudentButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteStudentButton);
            this.Controls.Add(this.editStudentButton);
            this.Controls.Add(this.studentInformationListBox);
            this.Controls.Add(this.studentNameTextBox);
            this.Controls.Add(this.studentNameLookupLabel);
            this.Controls.Add(this.studentListBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox studentListBox;
        private System.Windows.Forms.Label studentNameLookupLabel;
        private System.Windows.Forms.TextBox studentNameTextBox;
        private System.Windows.Forms.ListBox studentInformationListBox;
        private System.Windows.Forms.Button editStudentButton;
        private System.Windows.Forms.Button deleteStudentButton;
    }
}

