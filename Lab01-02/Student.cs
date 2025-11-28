using System;

namespace Lab01_02
{
    public class Student
    {
        // 1. Properties (Thuộc tính)
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        // 2. Constructors
        public Student() { }

        public Student(string id, string name, float score, string faculty)
        {
            StudentID = id;
            FullName = name;
            AverageScore = score;
            Faculty = faculty;
        }

        // 3. Methods
        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            StudentID = Console.ReadLine();

            Console.Write("Nhập Họ tên: ");
            FullName = Console.ReadLine();

            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();

            Console.Write("Nhập Điểm TB: ");
            // Ép kiểu float, nếu nhập sai sẽ báo lỗi ở Program.cs
            AverageScore = float.Parse(Console.ReadLine());
        }

        // Hàm hiển thị định dạng bảng (Yêu cầu thêm)
        public void Show()
        {
            // Sử dụng Composite Formatting để căn lề
            // {0,-10}: Tham số 0 (ID), dành 10 chỗ, căn trái
            // {3, -5}: Tham số 3 (Điểm), dành 5 chỗ, căn trái
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-5} |",
                this.StudentID, this.FullName, this.Faculty, this.AverageScore);
        }
    }
}