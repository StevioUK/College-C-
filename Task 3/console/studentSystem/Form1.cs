using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace studentSystem
{
    public partial class Form1 : Form
    {
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";
        MySqlExecutor executor = new MySqlExecutor(connectionString);
        createMessageBox messageBox = new createMessageBox();
        private List<ListItemData> studentListItems = new List<ListItemData>();

        public Form1()
        {
            InitializeComponent();
            populateListBox(); // Populate the ListBox with student information
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); // Show Form2 as a dialog
        }

        private void studentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentInformationListBox.Visible = true;
            deleteStudentButton.Visible = true;
            editStudentButton.Visible = true;
            studentInformationListBox.SelectionMode = SelectionMode.None;
            studentInformationListBox.Items.Clear();

            int selectedIndex = studentListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < studentListItems.Count)
            {
                ListItemData selectedItem = studentListItems[selectedIndex];

                studentInformationListBox.Items.Add("Personal Information");
                studentInformationListBox.Items.Add(string.Format("ID: {0}", selectedItem.ID));
                studentInformationListBox.Items.Add(string.Format("Name: {0}", selectedItem.Name));
                studentInformationListBox.Items.Add(string.Format("Date of Birth: {0}", selectedItem.dob));
                studentInformationListBox.Items.Add("");
                studentInformationListBox.Items.Add("Course Information");
                studentInformationListBox.Items.Add(string.Format("Course: {0}", selectedItem.course));
            }
        }

        private void studentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable studentInfoQuery = executor.ExecuteQuery(String.Format("SELECT ID, NAME, dob, course FROM students WHERE id LIKE '{0}' OR name LIKE '{0}' OR dob LIKE '{0}' OR course LIKE '{0}';", studentNameTextBox.Text));
            studentListBox.Items.Clear();
            studentListItems.Clear();
            if (studentInfoQuery.Rows.Count == 0)
            {
                studentListBox.Items.Add("No Value Found");
            } else { 
                foreach (DataRow info in studentInfoQuery.Rows)
                {
                    string[] studentInfo = new string[4];
                    int indexer = 0;
                    foreach (DataColumn dataColumn in studentInfoQuery.Columns)
                    {
                        studentInfo[indexer] = info[dataColumn].ToString();
                        indexer++;
                    }
                    ListItemData lid = new ListItemData(studentInfo[0].ToString(), studentInfo[1], studentInfo[2], studentInfo[3]);
                    studentListItems.Add(lid);
                    string itemText = String.Format("Name: {0}, DOB: {1}, Course: {2}", lid.Name, lid.dob, lid.course);
                    studentListBox.Items.Add(itemText);
                }
            }
        }

        // This method populates the ListBox with student information
        private void populateListBox()
        {
            DataTable studentInfoQuery = executor.ExecuteQuery(String.Format("SELECT ID, NAME, dob, course FROM students;"));
            studentListBox.Items.Clear();
            studentListItems.Clear();

            // Iterate through each row of the DataTable
            foreach (DataRow info in studentInfoQuery.Rows)
            {
                string[] studentInfo = new string[4];
                int indexer = 0;

                // Iterate through each column of the DataTable
                foreach (DataColumn dataColumn in studentInfoQuery.Columns)
                {
                    studentInfo[indexer] = info[dataColumn].ToString();
                    indexer++;
                }

                // Create a ListItemData object with the student information
                ListItemData lid = new ListItemData(studentInfo[0].ToString(), studentInfo[1], studentInfo[2], studentInfo[3]);

                // Add the ListItemData object to the list of studentListItems
                studentListItems.Add(lid);

                // Create a formatted string with the student information and add it to the ListBox
                string itemText = String.Format("Name: {0}, DOB: {1}, Course: {2}", lid.Name, lid.dob, lid.course);
                studentListBox.Items.Add(itemText);
            }

            // If no items were added to the ListBox, display a message indicating no value found
            if (studentListBox.Items.Count == 0)
            {
                studentListBox.Items.Add("No Value Found");
            }
        }

        // This method is called when the selected index of studentInformationListBox changes
        private void studentInformationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // This method is called when the refreshStudent button is clicked
        private void refreshStudent_Click(object sender, EventArgs e)
        {
            populateListBox();
        }

        // This method is called when the deleteStudentButton is clicked
        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = studentListBox.SelectedIndex;
            ListItemData selectedItem = studentListItems[selectedIndex];

            // Execute a DELETE query to remove the selected student from the database
            executor.ExecuteNonQuery(String.Format("DELETE FROM students WHERE id={0}", selectedItem.ID));


            // Show a message box indicating successful deletion
            messageBox.messageBox("Successfully deleted", "Success");

            // Delete the entry from the box
            studentListBox.Items.RemoveAt(selectedIndex);
        }

        //This method is called when the editStudentButton is clicked
        private void editStudentButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = studentListBox.SelectedIndex;
            ListItemData selectedItem = studentListItems[selectedIndex];

            //Create a new instance of the editStudent form with the selected students and show it
            editStudent editStu = new editStudent(selectedItem.ID);
            editStu.Show();
        }

        // This class provides a method for displaying a message box
    }
    public class createMessageBox
    {
        public void messageBox(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }
    }

    // This class represents the data for a single item in the ListBox
    public class ListItemData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string dob { get; set; }
        public string course { get; set; }

        // Constructor to initialize the properties of the ListItemData
        public ListItemData(string ID, string name, string dob, string course)
        {
            this.Name = name;
            this.dob = dob;
            this.course = course;
            this.ID = ID;
        }
    }

    // This class provides methods for executing MySQL queries and retrieving results
    public class MySqlExecutor
    {
        private readonly string connectionString;

        // Constructor to set the connection string for the MySQL executor
        public MySqlExecutor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Executes a SELECT query and returns a DataTable containing the results
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Executes a non-query SQL statement (e.g., INSERT, UPDATE, DELETE) and returns the number of affected rows
        public int ExecuteNonQuery(string query)
        {
            int affectedRows = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    affectedRows = command.ExecuteNonQuery();
                }
            }

            return affectedRows;
        }
    }
}
