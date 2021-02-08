using System;

namespace Assessment1_StudentRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            Attendance Test = new Attendance(DateTime.Now, "L");
            Console.WriteLine(Test.GetMinutesLate());
            Console.WriteLine(Test.getDate());
        }
    }
}
