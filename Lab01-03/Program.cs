using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();

            students.Add(new Student("SV101", "Nguyễn Văn A", 8.5f, "CNTT"));
            students.Add(new Student("SV102", "Trần Thị B", 6.8f, "Kinh tế"));
            students.Add(new Student("SV103", "Lê Văn C", 9.2f, "CNTT"));
            students.Add(new Student("SV104", "Phạm Thị D", 4.5f, "Ngoại ngữ"));
            students.Add(new Student("SV105", "Hoàng Minh E", 7.0f, "CNTT"));

            teachers.Add(new Teacher("GV201", "Thầy Nguyễn Văn X", "Quận 9, TP.HCM"));
            teachers.Add(new Teacher("GV202", "Cô Trần Thị Y", "Quận 1, TP.HCM"));
            teachers.Add(new Teacher("GV203", "Thầy Lê Văn Z", "Quận 9, TP.HCM"));

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU QUẢN LÝ NHÂN SỰ ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Hiển thị danh sách sinh viên");
                Console.WriteLine("4. Hiển thị danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Sinh viên theo khoa nhập từ bàn phím");
                Console.WriteLine("7. Giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. Sinh viên CNTT có điểm TB cao nhất");
                Console.WriteLine("9. Thống kê xếp loại sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Student s = new Student();
                        s.Input();
                        students.Add(s);
                        break;

                    case "2":
                        Teacher t = new Teacher();
                        t.Input();
                        teachers.Add(t);
                        break;

                    case "3":
                        Console.WriteLine("\n{0,-10} | {1,-25} | {2,-12} | {3,-5}", "MSSV", "Họ tên", "Khoa", "ĐTB");
                        Console.WriteLine(new string('-', 60));
                        foreach (var sv in students) sv.Output();
                        break;

                    case "4":
                        Console.WriteLine("\n{0,-10} | {1,-25} | {2,-30}", "Mã GV", "Họ tên", "Địa chỉ");
                        Console.WriteLine(new string('-', 70));
                        foreach (var gv in teachers) gv.Output();
                        break;

                    case "5":
                        Console.WriteLine($"\nTổng số sinh viên: {students.Count}");
                        Console.WriteLine($"Tổng số giáo viên: {teachers.Count}");
                        break;

                    case "6":
                        Console.Write("Nhập tên khoa cần lọc: ");
                        string faculty = Console.ReadLine();
                        var filtered = students.Where(sv =>
                            sv.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

                        Console.WriteLine("\n{0,-10} | {1,-25} | {2,-12} | {3,-5}", "MSSV", "Họ tên", "Khoa", "ĐTB");
                        Console.WriteLine(new string('-', 60));
                        foreach (var sv in filtered) sv.Output();
                        break;

                    case "7":
                        var q9Teachers = teachers.Where(gv =>
                            gv.Address.IndexOf("Quận 9", StringComparison.OrdinalIgnoreCase) >= 0
                        );

                        Console.WriteLine("\n{0,-10} | {1,-25} | {2,-30}", "Mã GV", "Họ tên", "Địa chỉ");
                        Console.WriteLine(new string('-', 70));

                        foreach (var gv in q9Teachers) gv.Output();
                        break;

                    case "8":
                        var maxScore = students
                            .Where(sv => sv.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase))
                            .Max(sv => sv.AverageScore);

                        var topCNTT = students.Where(sv =>
                            sv.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase)
                            && sv.AverageScore == maxScore
                        );

                        Console.WriteLine("\n{0,-10} | {1,-25} | {2,-12} | {3,-5}", "MSSV", "Họ tên", "Khoa", "ĐTB");
                        Console.WriteLine(new string('-', 60));

                        foreach (var sv in topCNTT) sv.Output();
                        break;

                    case "9":
                        var stats = students
                            .GroupBy(sv => GetClassification(sv.AverageScore))
                            .Select(g => new { XepLoai = g.Key, SoLuong = g.Count() });

                        Console.WriteLine("\n--- Thống kê xếp loại sinh viên ---");
                        foreach (var item in stats)
                            Console.WriteLine($"Xếp loại: {item.XepLoai} - Số lượng: {item.SoLuong}");
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Đã thoát chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        static string GetClassification(float score)
        {
            if (score >= 9.0f) return "Xuất sắc";
            else if (score >= 8.0f) return "Giỏi";
            else if (score >= 7.0f) return "Khá";
            else if (score >= 5.0f) return "Trung bình";
            else if (score >= 4.0f) return "Yếu";
            else return "Kém";
        }
    }
}
