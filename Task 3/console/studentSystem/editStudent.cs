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
        private string id { get; }
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";
        MySqlExecutor executor = new MySqlExecutor(connectionString);
        public editStudent(string id)
        {
            setup();
            InitializeComponent();
            this.id = id;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void setup()
        {
            string command = String.Format("SELECT name FROM students WHERE id = '{0}';", id);
            object result = executor.ExecuteQuery(command);
            if (result != null)
            {
                nameBox.Text = result.ToString();
            }
        }
    }
}
