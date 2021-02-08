using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment1_StudentRegister
{
    class Attendance
    {
       private DateTime Date;
        private string DOTW;
        private string AttendenceStatus;
        private int MinLate;

        public Attendance(DateTime Date, string AttendenceStatus)
        {
            if (AttendenceStatus != "L")
            {
                this.Date = Date;
                this.AttendenceStatus = AttendenceStatus;
                DOTW = Date.ToString("dddd");
                MinLate = 0;
            }
            else if(AttendenceStatus == "L")
            {
                this.Date = Date;
                this.AttendenceStatus = AttendenceStatus;
                DOTW = Date.ToString("dddd");
                Date = Date.AddHours(-8);
                MinLate = (Date.Hour * 60) + Date.Minute;
                Date.AddHours(8);
            }
        }
        public int GetMinutesLate()
        {
            return MinLate;
        }
        public DateTime getDate()
        {
            return Date;
        }
        public string GetAttendanceStatus()
        {
            return AttendenceStatus;

        }
    

    }
}
