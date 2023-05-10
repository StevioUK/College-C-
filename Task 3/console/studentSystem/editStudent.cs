using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentSystem
{
    public partial class editStudent : Form
    {
        private string id { get; } // ID of the student to edit
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";
        MySqlExecutor executor = new MySqlExecutor(connectionString); // Instance of MySqlExecutor to execute MySQL queries
        createMessageBox message = new createMessageBox(); // Instance of createMessageBox to display message boxes

        public editStudent(string id)
        {
            InitializeComponent();
            this.id = id;
            setup(id); // Call the setup method to populate the form with existing student information
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This event handler is empty and does not have any functionality.
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            // This event handler is empty and does not have any functionality.
        }

        private void setup(string id)
        {
            // List of courses to populate the coursePick ComboBox
            List<string> courseList = new List<string>(new string[] { "Marketing", "Creative", "Occupational", "Science", "Youth", "Engineering", "Electrical", "Technology", "and", "Design", "Communication", "Classics", "of", "Environmental", "Management", "Biological", "Media", "Sciences", "Criminology", "Physiotherapy", "Social", "History", "Forestry", "Law", "Mathematics", "Architecture", "Food", "Computer", "Psychology", "Medicine", "Accounting", "Geography", "Robotics", "Agriculture", "Medical", "Materials", "Building", "Forensic", "Nursing", "Manufacturing", "Education", "Studies", "Therapy", "Philosophy", "Art", "Work", "Physiology", "Health", "Recreation", "General", "Pharmacology", "Chemistry", "Care", "Finance", "Pharmacy", "Hospitality", "Archaeology", "Drama", "Anatomy", "English", "Land", "Veterinary", "Property", "Politics", "Linguistics", "Film", "Making", "Economics", "Electronic", "Policy", "Aeronautical", "Writing", "Chemical", "Civil", "Leisure", "Counselling", "Anthropology", "Information", "Geology", "Mechanical", "Sociology", "Ancient", "Complementary", "Tourism", "Astronomy", "Business", "Cinematics", "Physics", "Dance", "Music", "Dentistry", "Sports", "Fashion" });
            coursePick.DataSource = courseList;

            // Retrieve the name, date of birth, and course of the student with the given ID from the database
            DataTable nameBoxResult = executor.ExecuteQuery(String.Format("SELECT name FROM students WHERE id = '{0}'", id));
            DataTable dobResult = executor.ExecuteQuery(String.Format("SELECT dob FROM students WHERE id = '{0}'", id));
            DataTable courseResult = executor.ExecuteQuery(String.Format("SELECT course FROM students WHERE id = '{0}'", id));
            // Check if the query results are not null
            if (nameBoxResult != null && dobResult != null && courseResult != null)
            {
                // Set the text of nameBox, dobBox, and coursePick to the corresponding values from the query results
                nameBox.Text = nameBoxResult.Rows[0][0].ToString();
                dobBox.Text = dobResult.Rows[0][0].ToString();
                coursePick.Text = courseResult.Rows[0][0].ToString();
            }
        }

        private void submitChages_Click(object sender, EventArgs e)
        {
            // Update the student information in the database with the values entered in the form
            executor.ExecuteNonQuery(String.Format("UPDATE students SET name = '{0}', course = '{1}', dob = '{2}' WHERE id = {3};", nameBox.Text, coursePick.Text, dobBox.Text, id));

            // Display a success message box
            message.messageBox("Successfully updated the information", "Success");

            // Close the form
            this.Close();
        }
    }
}
