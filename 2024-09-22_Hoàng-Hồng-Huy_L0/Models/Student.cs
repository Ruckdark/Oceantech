using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgmt.Models
{
    internal class Student : Person
    {
        public string StudentId { get; set; }
        public string University { get; set; }
        public int YearOfStartingUniversity { get; set; }
        public float GPA { set; get; }
        public AcademicPerformance academicPerformance
        {
            get
            {
                if (GPA < 3)
                    return AcademicPerformance.Poor;
                else if (GPA >= 3 && GPA < 5)
                    return AcademicPerformance.Weak;
                else if (GPA >= 5 && GPA < 6.5)
                    return AcademicPerformance.Average;
                else if (GPA >= 6.5 && GPA < 7.5)
                    return AcademicPerformance.Good;
                else if (GPA >= 7.5 && GPA < 9)
                    return AcademicPerformance.VeryGood;
                else
                    return AcademicPerformance.Excellent;
            }
        }



        public Student()
        {

        }
        public Student(string name, DateTime dateOfBirth, string address, float height, float weight, string studentId, string university, int yearOfStartingUniversity, float gPA) : base(name, dateOfBirth, address, height, weight)
        {

            StudentId = studentId;
            University = university;
            YearOfStartingUniversity = yearOfStartingUniversity;
            GPA = gPA;
        }
        public override string ToString()
        {
            return base.ToString() + $"Student Id: {StudentId} \nSchool Name: {University} \nYear start: {YearOfStartingUniversity} \nGPA: {GPA} \n";
        }
        public static Student CreateStudent()
        {
            Student student = null;
            try
            {
                student = new Student(
                Input.ReadName(),
                Input.ReadDateOfBirth(),
                Input.ReadAddress(),
                Input.ReadHeight(),
                Input.ReadWeight(),
                Input.ReadStudentId(),
                Input.ReadUniversity(),
                Input.ReadStartYear(),
                Input.ReadGPA()
            );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return student;
        }

        public enum AcademicPerformance
        {
            Poor,
            Weak,
            Average,
            Good,
            VeryGood,
            Excellent
        }
        public static Student FromFile(string line)
        {
            string[] data = line.Split(';');
            Student student = new Student(
                            data[0], // Name
                            DateTime.Parse(data[1]), // DateOfBirth
                            data[2], // Address
                            float.Parse(data[3]), // Height
                            float.Parse(data[4]), // Weight
                            data[5], // StudentId
                            data[6], // University
                            int.Parse(data[7]), // YearOfStartingUniversity
                            float.Parse(data[8]) // GPA
                        );
            return student;
        }

    }
}
