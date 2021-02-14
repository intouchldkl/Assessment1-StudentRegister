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
            Year12FB.AddStudent("Toy", DateTime.Parse("01/02/2004"), true);
            Year12FB.AddStudent("Ankit", DateTime.Parse("01/09/2004"), true);

            ///For admin login username:admin password:admin123
            MainMenu(Year12FB);
            


        }
        static public void TeacherMenu(FormGroup Year12)
        {

            string Input = " ";
            int NumberInput;

            string date = "";
            string temp;
            DateTime date1;
            while (Input != "EXIT")
            {
                Console.WriteLine(Year12.getFormName() + " MAIN MENU");
                Console.WriteLine("Press 1 to take register");
                Console.WriteLine("Press 2 to print out form register");
                Console.WriteLine("Press 3 to view year group information");
                Console.WriteLine("Press 4 to view student statistic");
                Console.WriteLine("Press 5 to check student attendence on date");
                Console.WriteLine("Type EXIT to main menu");


                Input = Console.ReadLine();
                if (Input == "EXIT")
                {
                    break;
                }

                if (int.TryParse(Input, out NumberInput))
                {
                    if (NumberInput == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("FORM REGISTER");
                        Console.WriteLine("Enter the date");
                        Console.WriteLine("dd/mm/yyyy hour:min in this format");


                        date = Console.ReadLine();

                        DateTime.TryParse(date, out date1);
                        if (DateTime.TryParse(date, out date1) == false)
                        {
                            Console.WriteLine("Invalid input");
                            break;

                        }
                        Year12.TakeRegister(date1);
                        Console.Clear();
                        Console.WriteLine("Registration successful!");
                    }
                    else if (NumberInput == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Type in the date of the register you want to print out");
                        Console.WriteLine("dd/mm/yyyy in this format");


                        date = Console.ReadLine();
                        DateTime.TryParse(date, out date1);
                        if (DateTime.TryParse(date, out date1) == false)
                        {
                            Console.WriteLine("Invalid input");
                            break;

                        }
                        Year12.printRegister(date1);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                    }
                    else if (NumberInput == 3)
                    {
                        Console.Clear();
                        YearGroupInfoMenu(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                    }
                    else if (NumberInput == 4)
                    {
                        Console.Clear();
                        studentStatisticMenu(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();

                    }
                    else if (NumberInput == 5)
                    {
                        Console.Clear();
                        CheckStudentAttendenceOnDateMenu(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                }
            }

        }
        static public void YearGroupInfoMenu(FormGroup Year12)
        {
            
           
            
            string Input = " ";
            int NumberInput;

            
            string temp;
            DateTime date1;
            while (Input != "EXIT")
            {
                Console.WriteLine(Year12.getFormName() + " INFORMATION MENU");
                Console.WriteLine("");
                Console.WriteLine("Form teacher: " + Year12.getFormTeacherName());
                Console.WriteLine("");
                Console.WriteLine("List of students: ");
                for (int i = 0; i < Year12.getTotalStudent(); i++)
                {
                    Console.WriteLine(Year12.getStudent(i).getStudentName() + "\t" + " | " + Year12.getStudent(i).getStudentDOB() + "\t" + " | " + Year12.getStudent(i).getStudentGender());
                }
                Console.WriteLine("");
                Console.WriteLine("Press 1 to view present days statistic");
                Console.WriteLine("Press 2 to view absent days statistic");
                Console.WriteLine("Press 3 to view late days statistic");
                Console.WriteLine("Press 4 to view student student(s) with perfect attendance");
 
                Console.WriteLine("Type EXIT to main menu");


                Input = Console.ReadLine();
                if (Input == "EXIT")
                {
                    break;
                }

                if (int.TryParse(Input, out NumberInput))
                {
                    if (NumberInput == 1)
                    {
                        Console.Clear();
                        createPresentDayChart(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                        
                    }
                    else if (NumberInput == 2)
                    {
                        Console.Clear();
                        createAbsentDayChart(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                    }
                    else if (NumberInput == 3)
                    {
                        Console.Clear();
                        createLateDayChart(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();
                    }
                    else if (NumberInput == 4)
                    {
                        Console.Clear();
                        Year12.getStudentWithPerfectAttendence();
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();

                    }
                    
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                }
            }
            
        }
        static public void studentStatisticMenu(FormGroup Year12)
        {
            Console.WriteLine(Year12.getFormName() + " STUDENT STATISTIC MENU");
            Console.WriteLine("");
            string studentName = " ";
            for (int i = 0; i < Year12.getTotalStudent(); i++)
            {
                Console.WriteLine(Year12.getStudent(i).getStudentName() + "\t" + " | " + Year12.getStudent(i).getStudentDOB() + "\t" + " | " + Year12.getStudent(i).getStudentGender());
            }
            while (studentName != "EXIT")
            {


                Console.WriteLine("{0,3} {1,50}", "Type the name of the student to check for information", "Type EXIT to go back to main menu");
                studentName = Console.ReadLine();
                if (studentName == "EXIT")
                {
                    break;
                }

                for (int i = 0; i < Year12.getTotalStudent(); i++)
                {

                    if (studentName == Year12.getStudent(i).getStudentName())
                    {
                        Console.Clear();
                        Console.WriteLine(Year12.getStudent(i).getStudentName() + "'S INFORMATION");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("{0,9} {1,4}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,5}{11,5}{12,5}{13,5}{14,5}{15,5}{16,5}{17,5}{18,5}{19,5}{20,5}"
                         , "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100");
                        string result = string.Join("#", new string[Year12.getStudent(i).getTotalPresence() + 1]);

                        Console.WriteLine("Present" + "\t" + result + "#");
                        string result1 = string.Join("#", new string[Year12.getStudent(i).getTotalAbsence() + 1]);

                        Console.WriteLine("Absent" + "\t" + result1 + "#");
                        string result2 = string.Join("#", new string[Year12.getStudent(i).getTotalLate() + 1]);

                        Console.WriteLine("Late" + "\t" + result2 + "#");
                       
                    }

                }
            }

        }
        static public void CheckStudentAttendenceOnDateMenu(FormGroup Year12)
        {
            DateTime date1;
            Console.WriteLine("Type the name of the student you want to check");
            string studentName = Console.ReadLine();
            for (int i = 0; i < Year12.getTotalStudent(); i++)
            {

                if (studentName == Year12.getStudent(i).getStudentName())
                {
                    string date;
                    Console.WriteLine("Type in the date you want to check");
                    Console.WriteLine("dd/mm/yyyy in this format");
                    date = Console.ReadLine();

                    DateTime.TryParse(date, out date1);
                    if (DateTime.TryParse(date, out date1) == false)
                    {
                        Console.WriteLine("Invalid input");
                        break;

                    }
                    Console.WriteLine(Year12.getStudent(i).getStudentAttendanceOnDate(date1));
                }

            }


        }

        static public void adminMenu(FormGroup Year12)
        {
            Console.WriteLine("ADMIN LOGIN PAGE");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {

                Console.Clear();
                string Input = "";
                int NumberInput = 0;
                while (Input != "EXIT")
                {


                    Console.WriteLine("ADMIN PAGE: ACCESS GRANTED");
                    Console.WriteLine("Press 1 to add student");
                    Console.WriteLine("Press 2 to delete student");
                    Console.WriteLine("Press 3 to modify student attendance");
                    Console.WriteLine("Type EXIT to go back");


                    Input = Console.ReadLine();


                    if (int.TryParse(Input, out NumberInput))
                    {
                        if (NumberInput == 1)
                        {
                            Console.Clear();
                            string name;
                            string DOB;
                            string gender;
                            DateTime DOB1;
                            bool boolGender;
                            Console.WriteLine("Please enter the student's name");
                            name = Console.ReadLine();
                            Console.WriteLine("Please enter their date of birth  dd/mm/yyyy");
                            DOB = Console.ReadLine();
                            DateTime.TryParse(DOB, out DOB1);
                            if (DateTime.TryParse(DOB, out DOB1) == false)
                            {
                                Console.WriteLine("Invalid input");
                                break;

                            }

                            Console.WriteLine("Please enter their gender   true for male|false for female");
                            gender = Console.ReadLine();
                            bool.TryParse(gender, out boolGender);
                            if (bool.TryParse(gender, out boolGender) == false)
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }


                            Year12.AddStudent(name, DOB1, boolGender);
                            Console.Clear();

                        }
                        else if (NumberInput == 2)
                        {

                            Console.Clear();
                            for (int i = 0; i < Year12.getTotalStudent(); i++)
                            {
                                Console.WriteLine(Year12.getStudent(i).getStudentName() + "\t" + " | " + Year12.getStudent(i).getStudentDOB() + "\t" + " | " + Year12.getStudent(i).getStudentGender());
                            }
                            Console.WriteLine("Please enter the name of the student you want to delete");
                            string deletedStudent = Console.ReadLine();
                            for (int i = 0; i < Year12.getTotalStudent(); i++)
                            {
                                if (deletedStudent == Year12.getStudent(i).getStudentName())
                                {
                                    Year12.deleteStudent(i);
                                    Console.Clear();
                                }
                            }
                        }
                        else if (NumberInput == 3)
                        {
                            Console.Clear();
                            DateTime date1;
                            Console.WriteLine("Type the name of the student you want to modify");
                            string studentName = Console.ReadLine();
                            for (int i = 0; i < Year12.getTotalStudent(); i++)
                            {

                                if (studentName == Year12.getStudent(i).getStudentName())
                                {
                                    string date;
                                    Console.WriteLine("Type in the date you want to modify");
                                    Console.WriteLine("dd/mm/yyyy in this format");
                                    date = Console.ReadLine();

                                    DateTime.TryParse(date, out date1);
                                    if (DateTime.TryParse(date, out date1) == false)
                                    {
                                        Console.WriteLine("Invalid input");
                                        break;

                                    }
                                    Year12.getStudent(i).setStudentAttendanceOnDate(date1);
                                    Console.Clear();
                                }

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                        }

                    }

                }
            }
        }
        static public void MainMenu(FormGroup Year12)
        {


            string Input = " ";
            int NumberInput;
            bool Valid = false;
            string date = "";
            string temp;
            DateTime date1;
            while (Valid == false)
            {
                Console.WriteLine("WELCOME TO INTOUCHSAMS");
                Console.WriteLine("Press 1 for admin access");
                Console.WriteLine("Press 2 for teacher access");


                Input = Console.ReadLine();

                if (int.TryParse(Input, out NumberInput))
                {
                    if (NumberInput == 1)
                    {
                        Console.Clear();
                        adminMenu(Year12);
                        Console.Clear();
                    }
                    else if (NumberInput == 2)
                    {
                        Console.Clear();
                        TeacherMenu(Year12);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                }


            }
        }
        static public void createPresentDayChart(FormGroup Year12)
        {
            string x = "#";
            Console.WriteLine("YEAR12FB PRESENT DAYS");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,9} {1,4}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,5}{11,5}{12,5}{13,5}{14,5}{15,5}{16,5}{17,5}{18,5}{19,5}{20,5}" 
             , "0","5","10","15","20","25","30","35","40","45","50","55","60","65","70","75","80","85","90","95","100");
            for(int i = 0;i < Year12.getTotalStudent();i++)
            {
                string result = string.Join(x, new string[Year12.getStudent(i).getTotalPresence()+1]  );

                Console.WriteLine(Year12.getStudent(i).getStudentName() +"\t" +  result+"#");
            }
        }
        static public void createAbsentDayChart(FormGroup Year12)
        {
            string x = "#";
            Console.WriteLine("YEAR12FB ABSENT DAYS");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,9} {1,4}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,5}{11,5}{12,5}{13,5}{14,5}{15,5}{16,5}{17,5}{18,5}{19,5}{20,5}"
             , "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100");
            for (int i = 0; i < Year12.getTotalStudent(); i++)
            {
                string result = string.Join(x, new string[Year12.getStudent(i).getTotalAbsence() + 1]);

                Console.WriteLine(Year12.getStudent(i).getStudentName() + "\t" + result+"#");
            }
        }
        static public void createLateDayChart(FormGroup Year12)
        {
            string x = "#";
            Console.WriteLine("YEAR12FB LATE DAYS");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,9} {1,4}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,5}{11,5}{12,5}{13,5}{14,5}{15,5}{16,5}{17,5}{18,5}{19,5}{20,5}"
             , "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100");
            for (int i = 0; i < Year12.getTotalStudent(); i++)
            {
                string result = string.Join(x, new string[Year12.getStudent(i).getTotalLate() + 1]);

                Console.WriteLine(Year12.getStudent(i).getStudentName() + "\t" + result+"#");
            }
        }

    }

}

