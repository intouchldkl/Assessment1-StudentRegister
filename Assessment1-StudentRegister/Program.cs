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

            Year12FB.TakeRegister(DateTime.Now);

            Year12FB.printRegister(DateTime.Now);
            
        }
    }
}
