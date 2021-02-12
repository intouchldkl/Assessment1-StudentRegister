using System;

namespace Assessment1_StudentRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            FormGroup Year12FB = new FormGroup("Year12FB", "Faye Blairs");
            Year12FB.AddStudent("Intouch", DateTime.Parse("06/07/2004"), true);
            Year12FB.AddStudent("Prem", DateTime.Parse("31/12/2004"), true);
            Year12FB.AddStudent("Emeline", DateTime.Parse("01/09/2004"), false);
            string date = "";
            while(date != "EXIT")
            {
                Console.WriteLine("{0,3} {1,50}","What is today's date?", "Type EXIT to leave the program");
                Console.WriteLine("dd/mm/yyyy hour:min in this format");
                

                date = Console.ReadLine();
                if(date == "EXIT")
                {
                    Console.WriteLine("Student with the most presence is " + Year12FB.getMostPresentStudent());
                    Console.WriteLine("Student with the most absence is " + Year12FB.getMostAbsentStudent());
                    Console.WriteLine("Student with the most late minute is " + Year12FB.getMostLateStudent());
                    Year12FB.getStudentWithPerfectAttendence();
                    break;
                }
                Year12FB.TakeRegister(Convert.ToDateTime(date));
                Year12FB.printRegister(Convert.ToDateTime(date));
            }

            
            
        }
    }
}
