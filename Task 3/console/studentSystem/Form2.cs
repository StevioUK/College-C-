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
        // Connection string for connecting to the MySQL database
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";

        // Instance of MySqlExecutor to execute MySQL queries
        MySqlExecutor sqlExecutor = new MySqlExecutor(connectionString);

        // Instance of createMessageBox to display message boxes
        createMessageBox messageBox = new createMessageBox();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate the date format using regular expression
            bool isValidDate = Regex.IsMatch(dobTextBox.Text, @"^\d{2}/\d{2}/\d{4}$");

            // Check if any of the input fields are empty
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(dobTextBox.Text) || string.IsNullOrEmpty(courseTextBox.Text))
            {
                messageBox.messageBox("You cannot leave any box empty!!", "Error");
            }
            // Check if the date of birth is in a valid format
            else if (!isValidDate)
            {
                messageBox.messageBox("The date of birth box is not correct!", "Error");
            }
            else
            {
                // Create a new student object with the input values
                student stu = new student(nameTextBox.Text, dobTextBox.Text, courseTextBox.Text);

                // Construct the INSERT query to add the student to the database
                string insertQuery = String.Format("INSERT INTO students (name, dob, course) VALUES ('{0}', '{1}', '{2}')", stu.name, stu.dob, stu.course);

                // Execute the INSERT query
                int affectedRows = sqlExecutor.ExecuteNonQuery(insertQuery);

                // Display a success message box
                messageBox.messageBox("Command Successfully Sent and Executed!", "Success");

                // Close the form
                this.Close();
            }
        }
        
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            // This event handler is empty and does not have any functionality.
        }

        private void dobTextBox_TextChanged(object sender, EventArgs e)
        {
            // This event handler is empty and does not have any functionality.
        }

        private void courseTextBox_TextChanged(object sender, EventArgs e)
        {
            // This event handler is empty and does not have any functionality.
        }
    }

    // Represents a person with a name and date of birth
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

    // Represents a student, inheriting from Person class, with an additional course property
    class student : Person
    {
        public string course { get; set; }
        
        public student(string name, string dob, string course) : base(name, dob)
        {
            this.course = course;
        }
    }
}
