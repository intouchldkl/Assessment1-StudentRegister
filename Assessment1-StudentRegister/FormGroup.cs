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
                
                Console.WriteLine(students[i].getStudentName());
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
                    mostLateMin = students[i].getTotalMinLate();
                }
                else if(students[i].getTotalMinLate() == mostLateMin)
                {
                    mostLateStudent = mostLateStudent + " and " + students[i].getStudentName();

                }
                if(mostLateMin == 0)
                {
                    mostLateStudent = "no one";
                }

            }
            return mostLateStudent;
        }

        public string getMostPresentStudent()
        {
            int mostPresence = 0;
            string mostPresentStudent = "No student was present";
            for (int i = 0; i < TotalStudent; i++)
            {
                if (students[i] == null)
                {
                    break;
                }
                if (students[i].getTotalPresence() > mostPresence)
                {
                   mostPresentStudent = students[i].getStudentName();
                    mostPresence = students[i].getTotalPresence();
                }
                else if(students[i].getTotalPresence() == mostPresence)
                {
                    mostPresentStudent = mostPresentStudent + " and " + students[i].getStudentName();

                }
                if(mostPresence == 0)
                {
                    mostPresentStudent = "no one";
                }

            }
            return mostPresentStudent;

        }
        public string getMostAbsentStudent()
        {
            int mostAbsence = 0;
            string mostAbsentStudent = "No student was absent";
            for (int i = 0; i < TotalStudent; i++)
            {
                if (students[i] == null)
                {
                    break;
                }
                if (students[i].getTotalAbsence() > mostAbsence)
                {
                    mostAbsentStudent = students[i].getStudentName();
                    mostAbsence = students[i].getTotalAbsence();
                }
                else if (students[i].getTotalAbsence() == mostAbsence)

                {
                    mostAbsentStudent = mostAbsentStudent + " and " + students[i].getStudentName();

                }
                if(mostAbsence == 0)
                {
                    mostAbsentStudent = "no one";
                }

            }
            return mostAbsentStudent;

        }
        public void getStudentWithPerfectAttendence()
        {
            string[] perfectStudents = new string[TotalStudent];
            int totalPerfectStudent = 0;
            for(int i = 0;i < TotalStudent;i++)
            {
                if(students[i] == null || students[i].getTotalPresence() == 0)
                {
                    break;
                }
             
                if (students[i].getTotalPresence() == students[i].getAttendanceCount())
                {
                    perfectStudents[totalPerfectStudent] = students[i].getStudentName() + " has perfect attendance";
                    totalPerfectStudent++;
                }
                
            }

            for(int i = 0;i < totalPerfectStudent;i++)
            {
                Console.WriteLine(perfectStudents[i]);
            }
          
        }

        public string getFormTeacherName()
        {
            return FormTeacherName;
        }
        public string getFormName()
        {
            return FormName;
        }
        public int getTotalStudent()
        {
            return TotalStudent;
        }
        public void deleteStudent(int i)
        {
            
            students[i] = null;
            
            for(int z = i;z < TotalStudent;z++)
            {
                students[z] = students[z+1];
                
            }
                TotalStudent = TotalStudent - 1;
        }
    }
}
