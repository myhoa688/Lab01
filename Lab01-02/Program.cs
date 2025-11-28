using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

           
            List<Student> studentList = new List<Student>
{
    new Student("111111", "Nguyễn Văn Anh", 9.5f, "CNTT"),            // Xuất sắc
    new Student("222222", "Trần Thị Bích", 8.0f, "Kinh Tế"),          // Giỏi
    new Student("333333", "Lê Văn Châu", 4.5f, "CNTT"),               // Yếu
    new Student("444444", "Phạm Thị Diễm", 6.5f, "Ngôn Ngữ Anh"),     // TB
    new Student("555555", "Hoàng Văn Em", 7.5f, "CNTT"),              // Khá
    new Student("666666", "Ngô Thị F", 2.0f, "Kinh Tế"),              // Kém
    new Student("777777", "Đặng Văn G", 10.0f, "CNTT"),               // Thủ khoa
    new Student("888888", "Bùi Thị Hà", 5.0f, "Ngôn Ngữ Anh")         // TB
};

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n================ MENU QUẢN LÝ SINH VIÊN  ================");
                Console.WriteLine("1. Thêm sinh viên (Nhập tay thêm)");
                Console.WriteLine("2. Hiển thị toàn bộ danh sách");
                Console.WriteLine("3. Xuất danh sách SV theo Khoa (Nhập tên khoa)");
                Console.WriteLine("4. Xuất danh sách SV có ĐTB >= 5");
                Console.WriteLine("5. Sắp xếp danh sách theo ĐTB tăng dần");
                Console.WriteLine("6. SV có ĐTB >= 5 và thuộc Khoa (Nhập tên khoa)");
                Console.WriteLine("7. SV có điểm cao nhất theo Khoa (Nhập tên khoa)");
                Console.WriteLine("8. Thống kê số lượng từng xếp loại");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("=======================================================================");
                Console.Write("Chọn chức năng (0-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        Console.WriteLine("\n--- DANH SÁCH TOÀN BỘ SINH VIÊN ---");
                        DisplayTable(studentList);
                        break;
                    case "3":
                        Console.Write("Nhập tên Khoa cần tìm (VD: CNTT): ");
                        string f3 = Console.ReadLine();
                        var list3 = studentList.Where(s => s.Faculty.Equals(f3, StringComparison.OrdinalIgnoreCase)).ToList();
                        DisplayTable(list3);
                        break;
                    case "4":
                        var list4 = studentList.Where(s => s.AverageScore >= 5).ToList();
                        Console.WriteLine("\n--- Danh sách SV có điểm >= 5 ---");
                        DisplayTable(list4);
                        break;
                    case "5":
                        var list5 = studentList.OrderBy(s => s.AverageScore).ToList();
                        Console.WriteLine("\n--- Danh sách đã sắp xếp tăng dần theo điểm ---");
                        DisplayTable(list5);
                        break;
                    case "6":
                        Console.Write("Nhập tên Khoa cần tìm: ");
                        string f6 = Console.ReadLine();
                        var list6 = studentList.Where(s => s.AverageScore >= 5 && s.Faculty.Equals(f6, StringComparison.OrdinalIgnoreCase)).ToList();
                        DisplayTable(list6);
                        break;
                    case "7":
                        Console.Write("Nhập tên Khoa để tìm thủ khoa: ");
                        string f7 = Console.ReadLine();
                        DisplayTopStudentByFaculty(studentList, f7);
                        break;
                    case "8":
                        ShowStatistics(studentList);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        // --- HÀM HỖ TRỢ HIỂN THỊ BẢNG ---
        static void DisplayTable(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\n[Thông báo] Không tìm thấy kết quả nào!");
                return;
            }

            // Header bảng
            Console.WriteLine("\n+" + new string('-', 12) + "+" + new string('-', 22) + "+" + new string('-', 17) + "+" + new string('-', 7) + "+");
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-5} |", "MSSV", "Họ Tên", "Khoa", "ĐTB");
            Console.WriteLine("+" + new string('-', 12) + "+" + new string('-', 22) + "+" + new string('-', 17) + "+" + new string('-', 7) + "+");

            // Nội dung
            foreach (var s in list)
            {
                s.Show();
            }

            // Footer bảng
            Console.WriteLine("+" + new string('-', 12) + "+" + new string('-', 22) + "+" + new string('-', 17) + "+" + new string('-', 7) + "+");
        }

        // --- CÁC HÀM XỬ LÝ KHÁC ---
        static void AddStudent(List<Student> list)
        {
            Student s = new Student();
            try { s.Input(); list.Add(s); Console.WriteLine("Thêm thành công!"); }
            catch { Console.WriteLine("Lỗi nhập liệu!"); }
        }

        static void DisplayTopStudentByFaculty(List<Student> list, string faculty)
        {
            var facList = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (facList.Count == 0)
            {
                Console.WriteLine($"Không có sinh viên khoa '{faculty}'.");
                return;
            }
            float maxScore = facList.Max(s => s.AverageScore);
            var topStudents = facList.Where(s => s.AverageScore == maxScore).ToList();
            Console.WriteLine($"\n--- Thủ khoa khoa {faculty} (Điểm: {maxScore}) ---");
            DisplayTable(topStudents);
        }

        static void ShowStatistics(List<Student> list)
        {
            Console.WriteLine("\n=== Thống kê xếp loại ===");
            var stats = list.GroupBy(s =>
            {
                if (s.AverageScore >= 9) return "Xuất sắc";
                if (s.AverageScore >= 8) return "Giỏi";
                if (s.AverageScore >= 7) return "Khá";
                if (s.AverageScore >= 5) return "Trung bình";
                if (s.AverageScore >= 4) return "Yếu";
                return "Kém";
            }).Select(g => new { Loai = g.Key, SoLuong = g.Count() });

            foreach (var item in stats) Console.WriteLine($"- {item.Loai}: {item.SoLuong} sinh viên");
        }
    }
}















