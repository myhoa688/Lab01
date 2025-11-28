using System;

namespace Lab01_03
{
    public class Student : Person
    {
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student() { }

        public Student(string id, string fullname, float averageScore, string faculty)
            : base(id, fullname)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            AverageScore = float.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine(" | {0,-10} | {1,-5}", Faculty, AverageScore);
        }
    }
}
