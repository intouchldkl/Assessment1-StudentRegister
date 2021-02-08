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

        public Student(string StudentName,DateTime DOB,bool Gender)
        {
            this.StudentName = StudentName;
            this.DOB = DOB;
            this.Gender = Gender;
          attendances = new Attendance[180];
        }
        public void AddAttendence()
        {
            Attendances[0] = new Attendance(DateTime.Now, "L");
        }
    }
}
