using System;

namespace Lab01_03
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() { }

        public Teacher(string id, string fullname, string address)
            : base(id, fullname)
        {
            this.Address = address;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine(" | {0,-30}", Address);
        }
    }
}
