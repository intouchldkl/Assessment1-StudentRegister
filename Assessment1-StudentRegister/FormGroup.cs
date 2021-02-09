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
        public void TakeRegister()
        {

        }

    }
}
