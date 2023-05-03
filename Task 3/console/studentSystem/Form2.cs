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
    public partial class Form2 : Form
    {
        static string connectionString = "server=localhost;database=studentSystem;uid=user;password=test123;";
        MySqlExecutor sqlExecutor = new MySqlExecutor(connectionString);
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student stu = new student(textBox1.Text, textBox2.Text, textBox3.Text);
            string insertQuery = String.Format("INSERT INTO students (name,dob,course) VALUES ({0}, {1}, {2});", stu.name, stu.dob,stu.course);//No " in the values field meaning I am passing through number values instead of strings, fix when Idont feel like crimzon and want to slice my wrists :)
            int affectedRows = sqlExecutor.ExecuteNonQuery(insertQuery);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
