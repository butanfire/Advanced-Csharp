namespace Problem_1.Class_Student.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public Student(string fname, string lname, int age, int facnumber, string phone, string mail, IList<int> marks, string groupNumber)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.FacultyNumber = facnumber;
            this.Phone = phone;
            this.Email = mail;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public Student(string fname, string lname, int age, int facnumber, string phone, string mail, IList<int> marks, string groupNumber, string groupName)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.FacultyNumber = facnumber;
            this.Phone = phone;
            this.Email = mail;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public int FacultyNumber { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public IList<int> Marks { get; private set; }

        public string GroupNumber { get; private set; }

        public string GroupName { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("First Name :" + this.FirstName);
            output.AppendLine("Last Name :" + this.LastName);
            output.AppendLine("Age :" + this.Age);
            output.AppendLine("Faculty Number :" + this.FacultyNumber);
            output.AppendLine("Phone :" + this.Phone);
            output.AppendLine("E-mail :" + this.Email);

            if (this.Marks.Count > 0)
            {
                output.AppendLine("Marks :");
                foreach (var item in this.Marks)
                {
                    output.Append(item);
                }
            }

            output.AppendLine("Group Number:" + this.GroupNumber);
            if (this.GroupName != string.Empty)
            {
                output.AppendLine("Group name : " + this.GroupName);
            }

            return output.ToString();
        }
    }
}
