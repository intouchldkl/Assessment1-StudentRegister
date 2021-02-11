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
                if(students[i] == null)
                {
                    break;
                }
                
                if (students[i].getStudentAttendanceOnDate(date) == "P" || students[i].getStudentAttendanceOnDate(date) == "A")
                {
                    Console.WriteLine(students[i].getStudentName() + " " + students[i].getStudentAttendanceOnDate(date));
                }
                else if (students[i].getStudentAttendanceOnDate(date) == "L")
                {
                    Console.WriteLine(students[i].getStudentName() + " " + students[i].getStudentAttendanceOnDate(date) + " " + students[i].getMinLateOnDate(date) + " minute late");
                }
            }
        }

        public Student getStudent(int i)
        {
            if(i < TotalStudent)
            {
                return students[i];
            }
            else
            {
                return null;
            }
        }

        public string getMostLateStudent()
        {
            int mostLateMin = 0;
            string mostLateStudent = "No student came late";
            for(int i = 0;i < TotalStudent;i++)
            {
                if(students[i] == null)
                {
                    break;
                }
                if(students[i].getTotalMinLate() > mostLateMin)
                {
                    mostLateStudent = students[i].getStudentName();
                }

            }
            return mostLateStudent;
        }

        public string getMostPresentStudent()
        {
            int mostPresence = 0;
            string mostPresentStudent = "No student was absent";
            for (int i = 0; i < TotalStudent; i++)
            {
                if (students[i] == null)
                {
                    break;
                }
                if (students[i].getTotalPresence() > mostPresence)
                {
                   mostPresentStudent = students[i].getStudentName();
                }

            }
            return mostPresentStudent;

        }
        public string getMostAbsentStudent()
        {
            int mostAbsence = 0;
            string mostAbsentStudent = students[0].getStudentName();
            for (int i = 0; i < TotalStudent; i++)
            {
                if (students[i] == null)
                {
                    break;
                }
                if (students[i].getTotalAbsence() > mostAbsence)
                {
                    mostAbsentStudent = students[i].getStudentName();
                }

            }
            return mostAbsentStudent;

        }
        public string getStudentWithPerfectAttendence()
        {
            string perfectStudent = "No student has perfect attendance";
            for(int i = 0;i < TotalStudent;i++)
            {
                if(students[i] == null)
                {
                    break;
                }
                if(students[i].getTotalPresence() == students[i].getAttendanceCount())
                {
                    perfectStudent = students[i].getStudentName() + " has perfect attendance";
                }
            }
            return perfectStudent;
        }
    }
}
