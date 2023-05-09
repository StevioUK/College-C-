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
        }

        private void populateListBox()
        {
            DataTable studentInfoQuery = executor.ExecuteQuery("SELECT NAME, dob, course FROM students;");
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
