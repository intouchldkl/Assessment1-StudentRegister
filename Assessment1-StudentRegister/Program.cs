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
                if(Input == "EXIT")
                {
                    break;
                }

                if (int.TryParse(Input, out NumberInput))
                {
                    if (NumberInput == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("FORM REGISTER");
                        Console.WriteLine( "Enter the date");
                        Console.WriteLine("dd/mm/yyyy hour:min in this format");


                        date = Console.ReadLine();

                        DateTime.TryParse(date, out date1);
                        if(DateTime.TryParse(date, out date1) == false)
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
                    else if(NumberInput == 4)
                    {
                        Console.Clear();
                        studentStatisticMenu(Year12);
                        Console.WriteLine("Press any key to go back to main menu");
                        temp = Console.ReadLine();
                        Console.Clear();

                    }
                    else if(NumberInput == 5)
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
           
            Console.WriteLine(Year12.getFormName() + " INFORMATION MENU");
            Console.WriteLine("");
            Console.WriteLine("Form teacher: " + Year12.getFormTeacherName());
            Console.WriteLine("");
            Console.WriteLine("List of students: ");
            for(int i =0; i < Year12.getTotalStudent();i++)
            {
                Console.WriteLine(Year12.getStudent(i).getStudentName()+"\t" +" | " + Year12.getStudent(i).getStudentDOB() + "\t" + " | " +Year12.getStudent(i).getStudentGender());
            }
            Console.WriteLine("");
            Console.WriteLine("Student with the most presence is " + Year12.getMostPresentStudent());
            Console.WriteLine("Student with the most absence is " + Year12.getMostAbsentStudent());
            Console.WriteLine("Student with the most late minute is " + Year12.getMostLateStudent());
            Year12.getStudentWithPerfectAttendence();
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


                Console.WriteLine("{0,3} {1,50}","Type the name of the student to check for information","Type EXIT to go back to main menu");
                studentName = Console.ReadLine();
                if(studentName == "EXIT")
                {
                    break;
                }

                for(int i = 0; i < Year12.getTotalStudent();i++)
                {
                   
                    if(studentName == Year12.getStudent(i).getStudentName())
                    {
                        Console.WriteLine(Year12.getStudent(i).getStudentName() + "'s total presence is " + Year12.getStudent(i).getTotalPresence() + " day(s)");
                        Console.WriteLine(Year12.getStudent(i).getStudentName() + "'s total absence is " + Year12.getStudent(i).getTotalAbsence() + " day(s)");
                        Console.WriteLine(Year12.getStudent(i).getStudentName() + "'s total late days is " + Year12.getStudent(i).getTotalLate() + " day(s)");
                        Console.WriteLine(Year12.getStudent(i).getStudentName() + "'s total late minute is " + Year12.getStudent(i).getTotalMinLate() + " minute(s)");
                    }
                   
                }
            }
            
        }
        static public void CheckStudentAttendenceOnDateMenu(FormGroup Year12)
        {
            DateTime date1;
            Console.WriteLine("Type the name of the student you want to check");
            string studentName = Console.ReadLine();
            for(int i = 0;i < Year12.getTotalStudent();i++)
            {
                
                if(studentName == Year12.getStudent(i).getStudentName())
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

            if (username == "admin" || password == "admin123")
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
                    if(NumberInput == 1)
                    {
                        Console.Clear();
                        adminMenu(Year12);
                        Console.Clear();
                    }
                    else if(NumberInput == 2)
                    {
                        Console.Clear();
                        TeacherMenu(Year12);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                }
                        
            }
        }

    }

}

