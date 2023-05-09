using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentSystem
{
    public partial class Form2 : Form
    {
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";
        MySqlExecutor sqlExecutor = new MySqlExecutor(connectionString);
        createMessageBox messageBox = new createMessageBox();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool isValidDate = Regex.IsMatch(dobTextBox.Text, @"^\d{2}/\d{2}/\d{4}$");

            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(dobTextBox.Text) || string.IsNullOrEmpty(courseTextBox.Text))
            {
                messageBox.messageBox("You cannot leave any box empty!!", "Error");
            }
            else if (!isValidDate)
            {
                messageBox.messageBox("The date of birth box is not correct!", "Error");
            }
            else
            {
                student stu = new student(nameTextBox.Text, dobTextBox.Text, courseTextBox.Text);
                string insertQuery = String.Format("INSERT INTO students (name, dob, course) VALUES ('{0}', '{1}', '{2}')", stu.name, stu.dob, stu.course);// when Idont feel like crimzon and want to slice my wrists :)
                int affectedRows = sqlExecutor.ExecuteNonQuery(insertQuery);
                messageBox.messageBox("Successfully added a student to the database!", "Success");
                this.Close();
            }
        }
        
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void dobTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void courseTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        
    }

    class Person
    {
        public string name { get; }
        public string dob { get; }

        public Person(string name, string dob)
        {
            this.name = name;
            this.dob = dob;
        }
    }

    class student : Person
    {
        public string course { get; set; }
        public student(string name, string dob, string course) : base(name, dob)
        {
            this.course = course;
        }
    }
}
