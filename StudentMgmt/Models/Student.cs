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
        public string StudentId {  get; set; }
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
        public Student(string name, DateTime dateOfBirth, string address, float height, float weight, string studentId, string university, int yearOfStartingUniversity, float gPA) : base (name, dateOfBirth, address, height, weight)
        {
            if (string.IsNullOrEmpty(studentId) || studentId.Length < 10)
                throw new ArgumentException("Mã sinh viên phải là chuỗi 10 ký tự");
            if (string.IsNullOrEmpty(university) || university.Length >= 200)
                throw new ArgumentException("Tên trường quá dài");
            if (yearOfStartingUniversity < 1900 || yearOfStartingUniversity > DateTime.Now.Year)
                throw new ArgumentException("Năm bắt đầu học không hợp lệ");
            if (GPA < 0.0f || GPA > 10.0f)
                throw new ArgumentException("Điểm trung bình phải từ 0.0 đến 10.0");
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
            Student s = null;
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter date of birth (dd/MM/yyyy): ");
                DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Enter address: ");
                string address = Console.ReadLine();

                Console.Write("Enter height (cm): ");
                float height = float.Parse(Console.ReadLine());

                Console.Write("Enter weight (kg): ");
                float weight = float.Parse(Console.ReadLine());

                Console.Write("Enter student id (10 ký tự): ");
                string studentId = Console.ReadLine();

                Console.Write("University: ");
                string university = Console.ReadLine();

                Console.Write("Enter year of study start: ");
                int startYear = int.Parse(Console.ReadLine());

                Console.Write("Enter GPA: ");
                float gpa = float.Parse(Console.ReadLine());

                

                s = new Student(name, dateOfBirth, address, height, weight, studentId, university, startYear, gpa);
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Data format error.");
            }
            return s;
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
