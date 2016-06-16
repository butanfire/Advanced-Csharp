namespace Problem_1.Class_Student.Models
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string specialtyName, int facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecialtyName { get; private set; }

        public int FacultyNumber { get; private set; }

    }
}
