using System;
using System.Collections.Generic;

namespace AssignmentTwo
{
    class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        private List<string> Address { get; set; }

        public Person(string n, int month, int day, int year, int s)
        {
            Name = n;
            BirthDate = new DateTime(year, month, day);
            Salary = s;
            Address = new List<string>();
        }

        public virtual void behave()
        {
            Console.WriteLine("Default behaviors");
        }
    }

    class Instructor : Person
    {
        public Department Department { get; set; }
        public DateTime JoinDate { get; set; }

        public Instructor(string n, int m, int d, int y, int s, Department dept, int jm, int jd, int jy) : base(n, m, d, y, s)
        {
            Department = dept;
            JoinDate = new DateTime(jy, jm, jd);
        }

        public override void behave()
        {
            Console.WriteLine("Teach");
        }
    }

    class Student : Person
    {
        public Dictionary<Course, char> Courses { get; set; }
        public Student(string n, int m, int d, int y, int s) : base(n, m, d, y, s)
        {
            Courses = new Dictionary<Course, char>();
        }

        public override void behave()
        {
            Console.WriteLine("Take classes");
        }
    }

    interface IPersonService
    {
        public int GetAge(Person p);
        public int CalcSalary(Person p);
    }

    class ManagePerson : IPersonService
    {
        public int GetAge(Person p)
        {
            return DateTime.Now.Year - p.BirthDate.Year;
        }
        public int CalcSalary(Person p)
        {
            return p.Salary * 12;
        }
    }

    interface IInstructorService : IPersonService
    { 

    }

    class ManageInstructor : IInstructorService
    {
        public int GetAge(Person p)
        {
            return DateTime.Now.Year - p.BirthDate.Year;
        }
        public int CalcSalary(Person p)
        {
            Instructor i = (Instructor)p;
            return (i.Salary * (100 + DateTime.Now.Year - i.JoinDate.Year) / 100) * 12;
        }
    }


    interface IStudentService : IPersonService
    {
        public void AddCourse(Student s, Course c, char grade);
        public decimal CalcGPA(Student s);
    }

    class ManageStudent : IStudentService
    {
        public int GetAge(Person p)
        {
            return DateTime.Now.Year - p.BirthDate.Year;
        }
        public int CalcSalary(Person p)
        {
            return p.Salary * 12;
        }
        public void AddCourse(Student s, Course c, char grade)
        {
            s.Courses.Add(c, grade);
        }
        public decimal CalcGPA(Student s)
        {
            int count = 0;
            decimal sum = 0;
            foreach (var g in s.Courses.Values)
            {
                ++count;
                sum += g switch
                {
                    'A' => 4.0m,
                    'B' => 3.0m,
                    'C' => 2.0m,
                    'D' => 1.0m,
                    _ => 0.0m
                };
            }
            return sum / count;
        }
    }



    class Course
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Course(string n)
        {
            Name = n;
            Students = new List<Student>();
        }
    }

    class Department
    {
        public string Name { get; set; }
        public Instructor Head { get; set; }
        public List<Course> Courses { get; set; }

        public Department(string n)
        {
            Name = n;
            Courses = new List<Course>();
        }
    }


    interface ICourseService
    {
        public List<Student> GetStudents(Course c);
        public void AddStudent(Course c, Student s);
    }

    class ManageCourse : ICourseService
    {
        public List<Student> GetStudents(Course c)
        {
            return c.Students;
        }

        public void AddStudent(Course c, Student s)
        {
            c.Students.Add(s);
        }
    }

    interface IDepartmentService
    {
        public void ChangeHead(Department d, Instructor i);
        public List<Course> GetCourses(Department d);
        public void AddCourses(Department d, Course c);
    }

    class ManageDepartment : IDepartmentService
    {
        public void ChangeHead(Department d, Instructor i)
        {
            d.Head = i;
        }
        public List<Course> GetCourses(Department d)
        {
            return d.Courses;
        }
        public void AddCourses(Department d, Course c)
        {
            d.Courses.Add(c);
        }
    }
}
