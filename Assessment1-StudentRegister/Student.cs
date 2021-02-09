using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment1_StudentRegister
{
    class Student
    {
        private string StudentName;
        private DateTime DOB;
        private bool Gender;
        private Attendance[] attendances;
        private int attendanceCount;
        private int TotalPresence;
        private int TotalAbsence;
        private int TotalLate;
        private int TotalMinLate;

        public Student(string StudentName,DateTime DOB,bool Gender)
        {
            this.StudentName = StudentName;
            this.DOB = DOB;
            this.Gender = Gender;
          attendances = new Attendance[180];
            attendanceCount = 0;
            TotalPresence = 0;
            TotalAbsence = 0;
            TotalLate = 0;
            TotalMinLate = 0;
        }
       
        public void AddAttendence(DateTime Date,string AttendenceStatus)
        { 
            
            
         
            if(AttendenceStatus == "P")
            {
                TotalPresence++;
                attendances[attendanceCount] = new Attendance(Date, AttendenceStatus);
                attendanceCount++;
            }
            else if(AttendenceStatus == "A")
            {
                TotalAbsence++;
                attendances[attendanceCount] = new Attendance(Date, AttendenceStatus);
                attendanceCount++;
            }
            else if(AttendenceStatus == "L")
            {
                TotalLate++;
                attendances[attendanceCount] = new Attendance(Date, AttendenceStatus);
                TotalMinLate = TotalMinLate + attendances[attendanceCount].GetMinutesLate();
                
                attendanceCount++;
            }
            else
            {
                Console.WriteLine("Ineligible Attendance status");
            }
          
        }
        public int getTotalPresence()
        {
            return TotalPresence;
        }
        public int getTotalAbsence()
        {
            return TotalAbsence;
        }
        public int getTotalLate()
        {
            return TotalLate;
        }
        public int getTotalMinLate()
        {
            return TotalMinLate;
        }
        public string getStudentAttendanceOnDate(DateTime Date)
        {
            string attendanceOnDate = "No data on that date";
            for(int i = 0;i < attendances.Length;i++)
            {
                if(attendances[i] == null)
                {
                    return attendanceOnDate;
                }
                
                if(attendances[i].getDate() == Date)
                {
                    attendanceOnDate = attendances[i].GetAttendanceStatus();
                }
            }
            return attendanceOnDate;
        }


    }
}
