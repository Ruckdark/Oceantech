using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgmt
{
    internal static class Input
    {
        public static string ReadName()
        {
            string name;
            string nameInput;
            do
            {
                Console.Write("Nhập tên: ");
                nameInput = Console.ReadLine();
            } while (!Validation.IsValidName(nameInput, out name));
            return name;
        }

        public static DateTime ReadDateOfBirth()
        {
            DateTime dob;
            string dobInput;
            do
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                dobInput = Console.ReadLine();
            } while (!Validation.IsValidDateOfBirth(dobInput, out dob));
            return dob;
        }

        public static string ReadAddress()
        {
            string address;
            string addressInput;
            do
            {
                Console.Write("Nhập địa chỉ: ");
                addressInput = Console.ReadLine();
            } while (!Validation.IsValidAddress(addressInput, out address));
            return address;
        }

        public static float ReadHeight()
        {
            float height;
            string heightInput;
            do
            {
                Console.Write("Nhập chiều cao (cm): ");
                heightInput = Console.ReadLine();
            } while (!Validation.IsValidHeight(heightInput, out height));
            return height;
        }

        public static float ReadWeight()
        {
            float weight;
            string weightInput;
            do
            {
                Console.Write("Nhập cân nặng (kg): ");
                weightInput = Console.ReadLine();
            } while (!Validation.IsValidWeight(weightInput, out weight));
            return weight;
        }

        public static float ReadGPA()
        {
            float gpa;
            string gpaInput;
            do
            {
                Console.Write("Nhập GPA: ");
                gpaInput = Console.ReadLine();
            } while (!Validation.IsValidGPA(gpaInput, out gpa));
            return gpa;
        }
        public static string ReadStudentId()
        {
            string studentId;
            do
            {
                Console.Write("Nhập ID sinh viên (10 ký tự): ");
                studentId = Console.ReadLine();
            } while (!Validation.IsValidStudentId(studentId, out _));

            return studentId;
        }

        public static string ReadUniversity()
        {
            string university;
            do
            {
                Console.Write("Nhập tên trường đại học (dưới 200 ký tự): ");
                university = Console.ReadLine();
            } while (!Validation.IsValidUniversity(university, out _));

            return university;
        }

        public static int ReadStartYear()
        {
            string input;
            int startYear;
            do
            {
                Console.Write("Nhập năm bắt đầu học đại học (từ 1900): ");
                input = Console.ReadLine();
            } while (!Validation.IsValidStartYear(input, out startYear));

            return startYear;
        }
    }
}
