using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tas3_but_in_console
{
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
        public student(string name, string dob, string id, string course) : base(name, dob)
        {
            this.course = course;
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
            if(entryMark == "Fail" || entryMark == "Pass" || entryMark == "Merit" || entryMark == "Distinction")
            {
                this.entryMark = entryMark;
            } else
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

    class Tas3_but_in_console
    {
        public static void Main()
        {
            student student = new student("James", "23/02/2005","11", "CS");
            GCSE gcse = new GCSE();
            gcse.createCourse("CS", "CS1001", "7");
            Console.WriteLine(student.dob);
            Console.WriteLine(gcse.entryMark);
            Console.ReadKey();
        }
    }
}
