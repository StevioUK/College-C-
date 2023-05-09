﻿using System;
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
            studentInformationListBox.Items.Clear(); // Clear the list box

            if (studentListBox.SelectedIndex != -1)
            {
                ListItemData selectedStudent = (ListItemData)studentListItems[studentListBox.SelectedIndex];

                studentInformationListBox.Items.Add("Personal Information");
                studentInformationListBox.Items.Add(String.Format("Name: {0}", selectedStudent.Name));
                studentInformationListBox.Items.Add(String.Format("Date of Birth: {0}", selectedStudent.dob));
                studentInformationListBox.Items.Add("");
                studentInformationListBox.Items.Add("Course Information");
                studentInformationListBox.Items.Add(String.Format("Course: {0}", selectedStudent.course));
            }

            // Show the list box and buttons
            studentInformationListBox.Visible = true;
            deleteStudentButton.Visible = true;
            editStudentButton.Visible = true;
            studentInformationListBox.SelectionMode = SelectionMode.None;
        }

        private List<object> populateListBox()
        {
            DataTable studentInfoQuery = executor.ExecuteQuery("SELECT NAME, dob, course FROM students;");
            int iterCounter = 0;
            List<object> idk = new List<object>();
            foreach (DataRow info in studentInfoQuery.Rows)
            {
                string[] studentInfo = new string[3];
                int indexer = 0;
                foreach (DataColumn dataColumn in studentInfoQuery.Columns)
                {
                    studentInfo[indexer] = info[dataColumn].ToString();
                    indexer++;
                }
                ListItemData lid = new ListItemData(studentInfo[0], studentInfo[1], studentInfo[2]);
                idk.Add(lid);
                string itemText = String.Format("Name: {0}, DOB: {1}, Course: {2}", lid.Name, lid.dob, lid.course);
                studentListBox.Items.Add(itemText);
                iterCounter++;
            }
            return idk;
        }

        private void studentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable studentInfoQuery = executor.ExecuteQuery(String.Format("SELECT NAME, dob, course FROM students WHERE name LIKE '%{0}%' OR dob LIKE '%{0}%' OR course LIKE '%{0}%';", studentNameTextBox.Text));
            studentListBox.Items.Clear();
            foreach (DataRow info in studentInfoQuery.Rows)
            {
                string studentInfo = "";
                foreach (DataColumn dataColumn in studentInfoQuery.Columns)
                {
                    studentInfo += info[dataColumn];
                    studentInfo += " ";
                }
                studentListBox.Items.Add(studentInfo);
            }
            if(studentListBox.Items.Count == 0)
            {
                studentListBox.Items.Add("No Value Found");
            }
        }

        private void studentInformationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class ListItemData
    {
        public string Name { get; set; }
        public string dob { get; set; }
        public string course { get; set; }
        public ListItemData(string name, string dob, string course)
        {
            this.Name = name;
            this.dob = dob;
            this.course = course;
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
