using System;

namespace Lab01_03
{
    public class Person
    {
        private string id;
        private string fullname;

        public Person() { }

        public Person(string id, string fullname)
        {
            this.Id = id;
            this.Fullname = fullname;
        }

        public string Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }

        public virtual void Input()
        {
            Console.Write("Nhập mã: ");
            Id = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            Fullname = Console.ReadLine();
        }

        public virtual void Output()
        {
            Console.Write("{0,-10} | {1,-25}", Id, Fullname);
        }
    }
}
