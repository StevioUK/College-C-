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
            populateListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
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
                studentInformationListBox.Items.Add(string.Format("Name: {0}", selectedItem.Name));
                studentInformationListBox.Items.Add(string.Format("Date of Birth: {0}", selectedItem.dob));
                studentInformationListBox.Items.Add("");
                studentInformationListBox.Items.Add("Course Information");
                studentInformationListBox.Items.Add(string.Format("Course: {0}", selectedItem.course));
            }
        }

        private void studentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable studentInfoQuery = executor.ExecuteQuery(String.Format("SELECT NAME, dob, course FROM students WHERE name LIKE '{0}' OR dob LIKE '{0}' OR course LIKE '{0}';", studentNameTextBox.Text));
            studentListBox.Items.Clear();
            studentListItems.Clear();
            foreach (DataRow info in studentInfoQuery.Rows)
            {
                string[] studentInfo = new string[3];
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
            if (studentListBox.Items.Count == 0)
            {
                studentListBox.Items.Add("No Value Found");
            }
        }

        private void populateListBox()
        {
            DataTable studentInfoQuery = executor.ExecuteQuery(String.Format("SELECT ID, NAME, dob, course FROM students;"));
            studentListBox.Items.Clear();
            studentListItems.Clear();
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
            if (studentListBox.Items.Count == 0)
            {
                studentListBox.Items.Add("No Value Found");
            }
        }

        private void studentInformationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshStudent_Click(object sender, EventArgs e)
        {
            populateListBox();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = studentListBox.SelectedIndex;
            ListItemData selectedItem = studentListItems[selectedIndex];
            executor.ExecuteNonQuery(String.Format("DELETE FROM students WHERE id={0}", selectedItem.ID));
            messageBox.messageBox("Successfully deleted", "Success");
        }
    }

    public class createMessageBox {
        public void messageBox(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }
    }
    public class ListItemData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string dob { get; set; }
        public string course { get; set; }
        public ListItemData(string ID, string name, string dob, string course)
        {
            this.Name = name;
            this.dob = dob;
            this.course = course;
            this.ID = ID;
        }
    }

    public class MySqlExecutor
    {
        private readonly string connectionString;

        public MySqlExecutor(string connectionString)
        {
            this.connectionString = connectionString;
        }

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
