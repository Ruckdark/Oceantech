using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static StudentMgmt.Models.Student;
using StudentMgmt.Models;

namespace StudentMgmt
{
    internal class Program
    {
        private static List<Student> students = new List<Student>();
        private static int studentCount = 0;

        public static void AddStudentList(Student student)
        {           
            //students[studentCount] = student;
            students.Add(student);
            studentCount++;

            //Console.WriteLine("Succeeded:");
            // Console.WriteLine(student.ToString());
            
            //else
            //{
            //    Console.WriteLine("Danh sách sinh viên đã đầy.");
            //}
        }
        public static void DisplayAllStudents()
        {
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine(students[i].ToString());
                Console.WriteLine("-------------------");
            }
        }
        public static void TestAddStudent()
        {
            
            try
            {
                // Tạo một số sinh viên và thêm vào mảng
                Student student1 = new Student(
                    "Nguyễn Văn A",
                    new DateTime(2000, 5, 20),
                    "Hà Nội, Việt Nam",
                    170.0f,
                    65.0f,
                    "SV12345678",
                    "Đại học Bách Khoa",
                    2018,
                    8.5f
                );

                Student student2 = new Student(
                    "Trần Thị B",
                    new DateTime(2001, 8, 15),
                    "Hà Nội, Việt Nam",
                    160.0f,
                    50.0f,
                    "SV87654321",
                    "Đại học Kinh tế Quốc dân",
                    2019,
                    9.0f
                );
                Student student3 = new Student(
                    "Phạm Văn C",
                    new DateTime(1999, 3, 12),
                    "Đà Nẵng, Việt Nam",
                    175.0f,
                    70.0f,
                    "SV34567890",
                    "Đại học Đà Nẵng",
                    2017,
                    7.5f
                );

                Student student4 = new Student(
                    "Lê Thị D",
                    new DateTime(2002, 11, 30),
                    "Cần Thơ, Việt Nam",
                    162.0f,
                    55.0f,
                    "SV09876543",
                    "Đại học Cần Thơ",
                    2020,
                    6.8f
                );

                Student student5 = new Student(
                    "Ngô Văn E",
                    new DateTime(2000, 4, 1),
                    "Hải Phòng, Việt Nam",
                    168.0f,
                    62.0f,
                    "SV56789012",
                    "Đại học Hàng Hải",
                    2018,
                    5.4f
                );

                Student student6 = new Student(
                    "Vũ Thị F",
                    new DateTime(2001, 9, 9),
                    "Huế, Việt Nam",
                    158.0f,
                    48.0f,
                    "SV67890123",
                    "Đại học Huế",
                    2019,
                    9.3f
                );

                Student student7 = new Student(
                    "Nguyễn Văn G",
                    new DateTime(1998, 7, 23),
                    "TP. Hồ Chí Minh, Việt Nam",
                    180.0f,
                    75.0f,
                    "SV78901234",
                    "Đại học Khoa học Tự nhiên",
                    2016,
                    7.0f
                );

                Student student8 = new Student(
                    "Trần Thị H",
                    new DateTime(2003, 12, 19),
                    "Hà Nội, Việt Nam",
                    155.0f,
                    45.0f,
                    "SV89012345",
                    "Đại học Ngoại Thương",
                    2021,
                    9.1f
                );

                // Thêm sinh viên vào mảng
                AddStudentList(student1);
                AddStudentList(student2);
                AddStudentList(student3);
                AddStudentList(student4);
                AddStudentList(student5);
                AddStudentList(student6);
                AddStudentList(student7);
                AddStudentList(student8);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static Student FindStudentById(string id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }
        public static void UpdateStudentById(string id)
        {
            Student student = FindStudentById(id);
            if (student != null)
            {
                Console.WriteLine("Cập nhật thông tin cho sinh viên ID: " + id);
                Console.Write("Nhập tên mới: ");
                student.FullName = Console.ReadLine();

                Console.Write("Nhập ngày sinh mới (dd/MM/yyyy): ");
                student.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Nhập địa chỉ mới: ");
                student.Address = Console.ReadLine();

                Console.Write("Nhập chiều cao mới (cm): ");
                student.Height = float.Parse(Console.ReadLine());

                Console.Write("Nhập cân nặng mới (kg): ");
                student.Weight = float.Parse(Console.ReadLine());

                Console.Write("Nhập trường đại học mới: ");
                student.University = Console.ReadLine();

                Console.Write("Nhập năm bắt đầu mới: ");
                student.YearOfStartingUniversity = int.Parse(Console.ReadLine());

                Console.Write("Nhập GPA mới: ");
                student.GPA = float.Parse(Console.ReadLine());

                Console.WriteLine("Cập nhật thành công.");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
        public static void DeleteStudentById(string id)
        {

            Student student = FindStudentById(id);
            if (student != null)
            {
                // Di chuyển các phần tử phía sau về trước một vị trí
                for (int i = student.Id; i < studentCount - 1; i++)
                {
                    students[i] = students[i + 1];
                }

                // Giảm số lượng sinh viên và đặt phần tử cuối cùng thành null
                studentCount--;
                students[studentCount] = null;

                Console.WriteLine($"Đã xóa sinh viên có ID {id}.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
            }
        }
        public static void DisplayAcademicPerformancePercentage()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("Không có sinh viên trong danh sách.");
                return;
            }

            // Tính toán số lượng sinh viên cho mỗi loại học lực
            var performanceGroups = students
                .Where(s => s != null) // Lọc bỏ các phần tử null
                .GroupBy(s => s.academicPerformance)
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    Performance = g.Key,
                    Count = g.Count(),
                    Percentage = (g.Count() * 100.0) / studentCount
                })
                .ToList();

            // Hiển thị kết quả
            Console.WriteLine("Phần trăm học lực của sinh viên:");
            foreach (var group in performanceGroups)
            {
                Console.WriteLine($"{group.Performance}: {group.Percentage:F2}% ({group.Count} sinh viên)");
            }
            Console.WriteLine("--------------------");
        }
        public static void DisplayGpaPercentage()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("Không có sinh viên trong danh sách.");
                return;
            }

            // Tạo Dictionary để lưu số lượng sinh viên với GPA cụ thể
            Dictionary<float, int> gpaCounts = new Dictionary<float, int>();

            // Duyệt qua danh sách sinh viên để đếm số lượng GPA
            for (int i = 0; i < studentCount; i++)
            {
                float gpa = students[i].GPA;

                if (gpaCounts.ContainsKey(gpa))
                {
                    gpaCounts[gpa]++;
                }
                else
                {
                    gpaCounts[gpa] = 1;
                }
            }

            // Hiển thị kết quả
            Console.WriteLine("Phần trăm điểm trung bình của sinh viên:");
            foreach (var gpa in gpaCounts)
            {
                float percentage = (gpa.Value * 100.0f) / studentCount;
                Console.WriteLine($"{gpa.Key}: {percentage:F2}% ({gpa.Value} sinh viên)");
            }
        }
        public static AcademicPerformance InputAcademicPerformance()
        {
            Console.Write("Nhập học lực cần tìm (Kem, Yeu, TrungBinh, Kha, Gioi, XuatSac): ");
            string input = Console.ReadLine();
           
            // Chuyển chuỗi nhập vào thành kiểu enum AcademicPerformance
            switch (input.ToLower())
            {
                case "kem":
                    return AcademicPerformance.Poor;
                case "yeu":
                    return AcademicPerformance.Weak;
                case "trungbinh":
                    return AcademicPerformance.Average;
                case "kha":
                    return AcademicPerformance.Good;
                case "gioi":
                    return AcademicPerformance.VeryGood;
                case "xuatsac":
                    return AcademicPerformance.Excellent;
                default:
                    Console.WriteLine("Học lực không hợp lệ. Vui lòng thử lại.");
                    return InputAcademicPerformance();  // Gọi lại hàm nếu nhập sai
            }
        }
        public static void DisplayStudentsByAcademicPerformance(AcademicPerformance performance)
        {
            bool found = false;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].academicPerformance == performance)
                {
                    Console.WriteLine(students[i].ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Không có sinh viên nào có học lực tương ứng.");
            }
        }
        public static void SaveStudentsToFile(string filePath)
        {
            HashSet<string> existingIds = new HashSet<string>();
            if (File.Exists(filePath))
            {
                string[] existingLines = File.ReadAllLines(filePath);
                foreach (string line in existingLines)
                {
                    Student student = Student.FromFile(line);
                    existingIds.Add(student.StudentId);
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < studentCount; i++)
                {
                    Student student = students[i];
                    writer.WriteLine($"{student.FullName};{student.DateOfBirth};{student.Address};{student.Height};{student.Weight};{student.StudentId};{student.University};{student.YearOfStartingUniversity};{student.GPA}");
                }
            }
            Console.WriteLine("Lưu danh sách sinh viên vào file thành công.");
        }
        public static void LoadStudentsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');

                        // Tạo sinh viên từ dữ liệu đọc từ file
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

                        // Thêm sinh viên vào danh sách
                        AddStudentList(student);
                    }
                }
                Console.WriteLine("Đọc danh sách sinh viên từ file thành công.");
            }
            else
            {
                Console.WriteLine("File không tồn tại. Bắt đầu với danh sách trống.");
            }

        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = "students.txt";
        

            //TestAddStudent();
            //SaveStudentsToFile(filePath);

            LoadStudentsFromFile(filePath);           


            do
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\n--- Hệ Thống Quản Lý Sinh Viên ---");
                Console.WriteLine("1. Thêm Sinh Viên");
                Console.WriteLine("2. Xem Sinh Viên Theo ID");
                Console.WriteLine("3. Cập Nhật Sinh Viên Theo ID");
                Console.WriteLine("4. Xóa Sinh Viên Theo ID");
                Console.WriteLine("5. Hiển Thị Tất Cả Sinh Viên");
                Console.WriteLine("6. Hiển Thị Thống Kê Học Lực");
                Console.WriteLine("7. Hiển Thị Thống Kê Điểm Trung Bình");
                Console.WriteLine("8. Tìm Kiếm Sinh Viên Theo Học Lực");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn một tùy chọn: ");

                string choice = Console.ReadLine();
                string id;
                switch (choice)
                {
                    case "1":
                        AddStudentList(Student.CreateStudent());
                        break;
                    case "2":
                        Console.Write("Nhập id: ");
                        id = Console.ReadLine();
                        Student temp = FindStudentById(id);
                        if (temp != null)
                            temp.ToString();
                        else
                            Console.WriteLine("Không tìm thấy sinh viên");
                        break;
                    case "3":
                        Console.Write("Nhập id: ");
                        id = Console.ReadLine();
                        UpdateStudentById(id);
                        break;
                    case "4":
                        Console.Write("Nhập id: ");
                        id = Console.ReadLine();
                        DeleteStudentById(id);
                        break;
                    case "5":
                        DisplayAllStudents();
                        break;
                    case "6":
                        DisplayAcademicPerformancePercentage();
                        break;
                    case "7":
                        DisplayGpaPercentage();
                        break;
                    case "8":
                        DisplayStudentsByAcademicPerformance(InputAcademicPerformance());
                        break;
                    case "0":
                        SaveStudentsToFile(filePath);
                        return;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng thử lại");
                        break;
                }
            } while (true);
        }

    }


}
