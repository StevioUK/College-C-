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

namespace CPSv3
{
        class databaseConnection 
        {
            private MySqlConnection conn;
            private string connString;

            public databaseConnection(string serverIP, string user, string password, string database)
            {
                connString = string.Format("server={0};uid={1};pwd={2};database={3}", serverIP, user, password, database);
                conn = new MySqlConnection(connString);
                conn.Open();
            }

            public List<string[]> executeQuery(string query)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string[]> result = new List<string[]>();
                while (reader.Read())
                {
                    string[] row = new string[2];
                    row[0] = reader["ID"].ToString();
                    row[1] = reader["Name"].ToString();
                    result.Add(row);
                }
                reader.Close();
                return result;
            }
        }


















    public partial class Form1 : Form
    {
        databaseConnection databaseConnection = new databaseConnection("localhost", "user", "cps2023", "cps");

        public Form1()
        {
            InitializeComponent();
        }
        public void addListBox(object Name, object DOB)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(databaseConnection.executeQuery("SELECT * FROM cps_namelist WHERE name='Jake Shaw'")[0][1].ToString());
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


    }
}
