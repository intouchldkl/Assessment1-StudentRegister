using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment1_StudentRegister
{
    class FormGroup
    {
        private string FormName;
        private string FormTeacherName;
        private Student[] students;
        private int TotalStudent;

        public FormGroup(string FormName,string FormTeacherName)
        {
            this.FormName = FormName;
            this.FormTeacherName = FormTeacherName;
            students = new Student[20];
            TotalStudent = 0;
        }

        public void AddStudent(string StudentName,DateTime DOB,bool Gender)
        {
            students[TotalStudent] = new Student(StudentName, DOB, Gender);
            TotalStudent++;

        }
        public void TakeRegister(DateTime date)
        {
            Console.WriteLine("{0,3}{1,25} {2,30}", "Type P for Present", "Type A for Absent", "Type L for Late");
            string studentAttendence;
            for(int i = 0;i < TotalStudent;i++)
            {
                
                Console.WriteLine("Is " + students[i].getStudentName() +" present,absent or late?");
                studentAttendence = Console.ReadLine();
                students[i].AddAttendence(date, studentAttendence);


            }
        }
        public void printRegister(DateTime date)
        {
            for (int i = 0; i < TotalStudent; i++)
            {
                if (students[i].getStudentAttendanceOnDate(date) == "P" || students[i].getStudentAttendanceOnDate(date) == "A")
                {
                    Console.WriteLine(students[i].getStudentName() + " " + students[i].getStudentAttendanceOnDate(date));
                }
                else if (students[i].getStudentAttendanceOnDate(date) == "L")
                {
                    Console.WriteLine(students[i].getStudentName() + " " + students[i].getStudentAttendanceOnDate(date) + " " + students[i].getMinLateOnDate(date));
                }
            }
        }

    }
}
