
namespace studentSystem
{
    partial class editStudent
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
            this.coursePick = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dobBox = new System.Windows.Forms.TextBox();
            this.submitChages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // coursePick
            // 
            this.coursePick.FormattingEnabled = true;
            this.coursePick.Location = new System.Drawing.Point(12, 97);
            this.coursePick.Name = "coursePick";
            this.coursePick.Size = new System.Drawing.Size(219, 21);
            this.coursePick.TabIndex = 0;
            this.coursePick.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(219, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dobBox
            // 
            this.dobBox.Location = new System.Drawing.Point(12, 52);
            this.dobBox.Name = "dobBox";
            this.dobBox.Size = new System.Drawing.Size(219, 20);
            this.dobBox.TabIndex = 2;
            // 
            // submitChages
            // 
            this.submitChages.Location = new System.Drawing.Point(12, 133);
            this.submitChages.Name = "submitChages";
            this.submitChages.Size = new System.Drawing.Size(219, 37);
            this.submitChages.TabIndex = 3;
            this.submitChages.Text = "Submit";
            this.submitChages.UseVisualStyleBackColor = true;
            // 
            // editStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 182);
            this.Controls.Add(this.submitChages);
            this.Controls.Add(this.dobBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.coursePick);
            this.Name = "editStudent";
            this.Text = "editStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox coursePick;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dobBox;
        private System.Windows.Forms.Button submitChages;
    }
}