
namespace StudentSystem
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
            this.studentCreateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.studentNameText = new System.Windows.Forms.TextBox();
            this.studentDOBText = new System.Windows.Forms.TextBox();
            this.studentCourseText = new System.Windows.Forms.TextBox();
            this.studentIDText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentCreateButton
            // 
            this.studentCreateButton.Location = new System.Drawing.Point(12, 201);
            this.studentCreateButton.Name = "studentCreateButton";
            this.studentCreateButton.Size = new System.Drawing.Size(165, 40);
            this.studentCreateButton.TabIndex = 0;
            this.studentCreateButton.Text = "Create new student";
            this.studentCreateButton.UseVisualStyleBackColor = true;
            this.studentCreateButton.Click += new System.EventHandler(this.studentCreateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Details";
            // 
            // studentNameText
            // 
            this.studentNameText.Location = new System.Drawing.Point(12, 43);
            this.studentNameText.Name = "studentNameText";
            this.studentNameText.Size = new System.Drawing.Size(165, 20);
            this.studentNameText.TabIndex = 2;
            this.studentNameText.TextChanged += new System.EventHandler(this.studentNameText_TextChanged);
            // 
            // studentDOBText
            // 
            this.studentDOBText.Location = new System.Drawing.Point(12, 85);
            this.studentDOBText.Name = "studentDOBText";
            this.studentDOBText.Size = new System.Drawing.Size(165, 20);
            this.studentDOBText.TabIndex = 3;
            this.studentDOBText.TextChanged += new System.EventHandler(this.studentDOBText_TextChanged);
            // 
            // studentCourseText
            // 
            this.studentCourseText.Location = new System.Drawing.Point(12, 129);
            this.studentCourseText.Name = "studentCourseText";
            this.studentCourseText.Size = new System.Drawing.Size(165, 20);
            this.studentCourseText.TabIndex = 4;
            this.studentCourseText.TextChanged += new System.EventHandler(this.studentCourseText_TextChanged);
            // 
            // studentIDText
            // 
            this.studentIDText.Location = new System.Drawing.Point(12, 175);
            this.studentIDText.Name = "studentIDText";
            this.studentIDText.Size = new System.Drawing.Size(165, 20);
            this.studentIDText.TabIndex = 5;
            this.studentIDText.TextChanged += new System.EventHandler(this.studentIDText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Student Full Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Student Date of birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Student Course";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Student Grade";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentIDText);
            this.Controls.Add(this.studentCourseText);
            this.Controls.Add(this.studentDOBText);
            this.Controls.Add(this.studentNameText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentCreateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button studentCreateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox studentNameText;
        private System.Windows.Forms.TextBox studentDOBText;
        private System.Windows.Forms.TextBox studentCourseText;
        private System.Windows.Forms.TextBox studentIDText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

