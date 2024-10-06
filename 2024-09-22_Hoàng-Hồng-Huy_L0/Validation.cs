using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgmt
{
    internal static class Validation
    {
        public static bool IsValidName(string s, out string name)
        {
            name = s.Trim();
            if (string.IsNullOrWhiteSpace(name) || name.Length >= 100)
            {
                Console.WriteLine("Tên không hợp lệ. Tên không được để trống và không được chứa ký tự đặc biệt.");
                return false;
            }
            return true;
        }

        public static bool IsValidDateOfBirth(string s, out DateTime dob)
        {
            dob = DateTime.MinValue;
            try
            {
                dob = DateTime.ParseExact(s.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (dob.Year < 1900)
                    throw new OverflowException();
                return true;
            }
            catch
            {
                Console.WriteLine("Ngày sinh không hợp lệ. Ngày sinh phải có định dạng dd/MM/yyyy và sau năm 1900.");
                return false;
            }
        }

        public static bool IsValidAddress(string s, out string address)
        {
            address = s.Trim();
            if (address.Length > 300)
            {
                Console.WriteLine("Địa chỉ không hợp lệ. Địa chỉ không được quá 300 ký tự và không được chứa ký tự đặc biệt.");
                return false;
            }
            return true;
        }

        public static bool IsValidHeight(string s, out float height)
        {
            height = 0;
            try
            {
                height = float.Parse(s.Trim());
                if (height < 50.0f || height > 300.0f)
                    throw new OverflowException();
                return true;
            }
            catch
            {
                Console.WriteLine("Chiều cao không hợp lệ. Chiều cao phải nằm trong khoảng từ 50.0 đến 300.0 cm.");
                return false;
            }
        }

        public static bool IsValidWeight(string s, out float weight)
        {
            weight = 0;
            try
            {
                weight = float.Parse(s.Trim());
                if (weight < 5.0f || weight > 1000.0f)
                    throw new OverflowException();
                return true;
            }
            catch
            {
                Console.WriteLine("Cân nặng không hợp lệ. Cân nặng phải nằm trong khoảng từ 5.0 đến 1000.0 kg.");
                return false;
            }
        }

        public static bool IsValidGPA(string s, out float gpa)
        {
            gpa = 0;
            try
            {
                gpa = float.Parse(s.Trim());
                if (gpa < 0.0f || gpa > 10.0f)
                    throw new OverflowException();
                return true;
            }
            catch
            {
                Console.WriteLine("GPA không hợp lệ. GPA phải nằm trong khoảng từ 0.0 đến 10.0.");
                return false;
            }
        }
        public static bool IsValidStudentId(string s, out string studentId)
        {
            studentId = s.Trim();
            if (string.IsNullOrEmpty(studentId) || studentId.Length != 10)
            {
                Console.WriteLine("ID sinh viên không hợp lệ.");
                return false;
            }
            return true;
        }

        public static bool IsValidUniversity(string s, out string university)
        {
            university = s.Trim();
            if (string.IsNullOrWhiteSpace(university) || university.Length > 200)
            {
                Console.WriteLine("Tên trường đại học không hợp lệ.");
                return false;
            }
            return true;
        }

        public static bool IsValidStartYear(string s, out int startYear)
        {
            startYear = 0;
            if (int.TryParse(s, out startYear) && startYear >= 1900)
            {
                return true;
            }
            Console.WriteLine("Năm bắt đầu không hợp lệ.");
            return false;
        }

    }
}
