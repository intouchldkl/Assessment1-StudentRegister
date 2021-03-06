﻿using System;
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

        public Student(string StudentName, DateTime DOB, bool Gender)
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

        public void AddAttendence(DateTime Date, string AttendenceStatus)
        {



            if (AttendenceStatus == "P")
            {
                TotalPresence++;
                attendances[attendanceCount] = new Attendance(Date, AttendenceStatus);
                attendanceCount++;
            }
            else if (AttendenceStatus == "A")
            {
                TotalAbsence++;
                attendances[attendanceCount] = new Attendance(Date, AttendenceStatus);
                attendanceCount++;
            }
            else if (AttendenceStatus == "L")
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
            for (int i = 0; i < attendances.Length; i++)
            {
                if (attendances[i] == null)
                {
                    return attendanceOnDate;
                }

                if (attendances[i].getDate().ToString("dd/MM/yyyy") == Date.ToString("dd/MM/yyyy"))
                {
                    attendanceOnDate = attendances[i].GetAttendanceStatus();
                }
            }
            return attendanceOnDate;
        }
        public void setStudentAttendanceOnDate(DateTime Date)
        {
            Console.WriteLine("Type in the new attendace");
            string newAttendance = Console.ReadLine();
            for (int i = 0; i < attendances.Length; i++)
            {
                if (attendances[i] == null)
                {
                    break;
                }

                if (attendances[i].getDate().ToString("dd/MM/yyyy") == Date.ToString("dd/MM/yyyy"))
                {
                    if(attendances[i].GetAttendanceStatus() == "P")
                    {
                        TotalPresence = TotalPresence - 1;
                    }
                    else if(attendances[i].GetAttendanceStatus() == "A")
                    {
                        TotalAbsence = TotalAbsence - 1;
                    }
                    else
                    {
                        TotalLate = TotalLate - 1;
                        TotalMinLate = TotalMinLate - attendances[i].GetMinutesLate();
                    }
                    attendances[i].setAttendanceStatus(newAttendance);
                    
                    if(newAttendance == "P")
                    {
                        TotalPresence++;
                    }
                    else if(newAttendance == "A")
                    {
                        TotalAbsence++;
                    }
                    else if(newAttendance == "L")
                    {
                        Console.WriteLine("Please enter minute late");
                        string newMinLate = Console.ReadLine();
                        int newminlate;
                        int.TryParse(newMinLate, out newminlate);
                        if(int.TryParse(newMinLate, out newminlate) == false)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        TotalLate++;
                        TotalMinLate = TotalMinLate + newminlate;
                    }
                }
            }
        }
        public string getStudentName()
        {
            return StudentName;
        }
        public string getStudentDOB()
        {
            
            return DOB.ToString("dd/MM/yyyy");
        }
        public string getStudentGender()
        {
            if (Gender == true)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        public int getMinLateOnDate(DateTime date)
        {
            for(int i = 0;i < attendanceCount;i++)
            {
                if(attendances[i] == null)
                {
                    break;
                }
                if(date.ToString("dd/MM/yyyy") == attendances[i].getDate().ToString("dd/MM/yyyy"))
                {
                    return attendances[i].GetMinutesLate();
                }
            }
            return 0;
        }
        public int getAttendanceCount()
        {
            return attendanceCount;
        }
        
         

    }
}
