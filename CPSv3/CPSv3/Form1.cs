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
    class databaseConnection {
        static string serverIP = "localhost";
        static string user = "user";
        static string password = "cps2023";
        static string database = "cps";
        static string connString = String.Format(@"server={0}; uid={1}; pwd={2}; database={3}", serverIP, user, password, database);

        private MySqlConnection SQLConnection()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            return conn;
        }

        public void testConnection()
        {
            try
            {
                SQLConnection();
                Console.WriteLine("The database has been succesfully connected!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                System.Environment.Exit(0);
            }
        }
    }


















    public partial class Form1 : Form
    {
        databaseConnection dbCon = new databaseConnection();
        public Form1()
        {
            InitializeComponent();
            dbCon.testConnection();
        }

        public class PersonLookup
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseGetNames(String.Format("SELECT * FROM cps_namelist WHERE name='{0}'", textBox1.Text));
            if(databaseGetNames(String.Format("SELECT * FROM cps_namelist WHERE name='{0}'", textBox1.Text)).Count == 0)
            {
                MessageBox.Show("There are no entries found!");
            } else
            {
                Console.WriteLine(databaseGetNames(String.Format("SELECT * FROM cps_namelist WHERE name='{0}'", textBox1.Text)));
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonLookup person = new PersonLookup();
            //person.Name = Convert.ToString(reader["Name"]);
            //person.ID = Convert.ToInt16(reader["ID"]);
            listBox2.Items.Clear();
            listBox2.Items.Add("test");
            databaseGetNames(String.Format("SELECT * FROM cps_namelist WHERE ID='{0}'", textBox1.Text));
        }


        public List<string> databaseGetNames(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> readerList = new List<string>();
            int index = 0;
            while (reader.Read())
            {
                index++;
                readerList.Add(Convert.ToString(reader["ID"]));
                listBox1.Items.Add(String.Format("Name: {0}, DOB: {1}", reader["Name"], reader["DOB"]));
                Console.WriteLine(index);
            }
            return readerList;
        }


    }
}
