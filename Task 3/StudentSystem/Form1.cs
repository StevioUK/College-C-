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

namespace StudentSystem
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection(String.Format("server={0};uid={1};pwd={2};database={3}", "localhost", "user", "test123", "studentsystem"));
        public Form1()
        {
            InitializeComponent();
        }

        private void studentCreateButton_Click(object sender, EventArgs e)
        {
            student student = new student(studentNameText.Text, studentDOBText.Text, studentIDText.Text, studentCourseText.Text);
            Console.WriteLine(student.course);
            //command.ExecuteReader("s");
            string SQLCOMMAND = String.Format("INSERT INTO students VALUES ({0},{1},{2},{3});", student.name, student.dob, student.id, student.course);
            MySqlCommand cmd = new MySqlCommand(SQLCOMMAND, conn);
            cmd.ExecuteReader();
        }

        public void studentNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentDOBText_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentCourseText_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentIDText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    class Person
    {
        public string name { get; }
        public string dob { get; }
        public string id { get; }

        public Person(string name, string dob, string id)
        {
            this.name = name;
            this.dob = dob;
            this.id = id;
        }
    }

    class student : Person
    {
        public string course { get; set; }
        public student(string name, string dob, string id, string course) : base(name, dob, id)
        {
            this.course = course;
        }

        public void changeCourse(string newCourse)
        {
            this.course = newCourse;
        }
    }

    class course
    {
        protected virtual string title { get; set; }
        protected virtual string courseCode { get; set; }
        public virtual string entryMark { get; set; }
        public course()
        {
            this.title = title;
            this.courseCode = courseCode;
            this.entryMark = entryMark;
        }

        public virtual void createCourse(string title, string courseCode, string entryMark)
        {
            this.title = title;
            this.courseCode = courseCode;
            if (entryMark == "Fail" || entryMark == "Pass" || entryMark == "Merit" || entryMark == "Distinction")
            {
                this.entryMark = entryMark;
            }
            else
            {
                Console.WriteLine("Incorrect Mark");
            }
        }
    }

    class GCSE : course
    {
        public override string entryMark { get; set; }

        public GCSE()
        {
            this.entryMark = entryMark;
        }

        public override void createCourse(string title, string courseCode, string entryMark)
        {
            this.title = title;
            this.courseCode = courseCode;
            if (entryMark == "1" || entryMark == "2" || entryMark == "3" || entryMark == "4" || entryMark == "5" || entryMark == "6" || entryMark == "7" || entryMark == "8" || entryMark == "9")
            {
                this.entryMark = entryMark;
            }
            else
            {
                Console.WriteLine("Incorrect Mark");
            }
        }
    }


    class Tas3
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            student student = new student("James", "23/02/2005", "11", "CS");
            GCSE gcse = new GCSE();
            gcse.createCourse("CS", "CS1001", "7");
            Console.WriteLine(student.dob);
            Console.WriteLine(gcse.entryMark);
        }
    }
}
