// See https://aka.ms/new-console-template for more information

using System;

// Abstraction in interfaces
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
    List<string> GetAddresses();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
    void EnrollInCourse(Course course, char grade);
}

public interface IInstructorService : IPersonService
{
    bool IsHeadOfDepartment();
}

public interface ICourseService
{
    void EnrollStudent(Student student, char grade);
}

public interface IDepartmentService
{
    void AssignHead(Instructor instructor);
}

// Base Person class with Encapsulation
public abstract class Person : IPersonService
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    private decimal _salary;
    private List<string> Addresses = new List<string>();

    public Person(string name, DateTime dob, decimal salary)
    {
        Name = name;
        DateOfBirth = dob;
        Salary = salary;
    }

    public int CalculateAge() => DateTime.Now.Year - DateOfBirth.Year;

    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Salary cannot be negative");
            }
            _salary = value;
        }
    }
    
    public List<string> GetAddresses() => Addresses;
    public void AddAddress(string address) => Addresses.Add(address);

    public abstract decimal CalculateSalary();
}

// Inheritance and Polymorphism did with Calculate salary, Exp, and isHead methods
public class Instructor : Person, IInstructorService
{
    public DateTime JoinDate { get; set; }
    public Department Department { get; set; }
    public bool IsDepartmentHead { get; set; }
    public Instructor(string name, DateTime dob, decimal salary, DateTime joinDate)
        : base(name, dob, salary)
    {
        JoinDate = joinDate;
    }

    public int GetYearsOfExperience() => DateTime.Now.Year - JoinDate.Year;
    public override decimal CalculateSalary() => Salary + (GetYearsOfExperience() * 1000);
    public bool IsHeadOfDepartment() => IsDepartmentHead;
}

public class Student : Person, IStudentService
{
    private Dictionary<Course, char> CourseGrades = new();
    public Student(string name, DateTime dob) : base(name, dob, 0) { }
    
    // no salary for the student so set to 0
    public override decimal CalculateSalary() => 0;

    public void EnrollInCourse(Course course, char grade)
    {
        CourseGrades[course] = grade;
    }
    public double CalculateGPA()
    {
        if (!CourseGrades.Any()) return 0.0;
        Dictionary<char, double> GradePoints = new() { { 'A', 4.0 }, { 'B', 3.0 }, { 'C', 2.0 }, { 'D', 1.0 }, {'E', 0.5}, { 'F', 0.0 } };
        
        return CourseGrades.Average(c => GradePoints[c.Value]);
    }
}

public class Course : ICourseService
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; private set; } = new();
    public Dictionary<Student, char> StudentGrades = new();
    public Course(string name) => CourseName = name;

    public void EnrollStudent(Student student, char grade)
    {
        EnrolledStudents.Add(student);
        StudentGrades[student] = grade;
    }
}

public class Department : IDepartmentService
{
    public string DepartmentName { get; set; }
    public Instructor Head { get; private set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> OfferedCourses { get; set; } = new();

    public void AssignHead(Instructor instructor)
    {
        Head = instructor;
        instructor.IsDepartmentHead = true;
    }
}

class Program
{
    static void Main()
    {
        Instructor instructor = new("Saideep", new DateTime(1950, 5, 15), 50000, new DateTime(2010, 6, 1));
        Student student1 = new("Rakesh", new DateTime(1999, 8, 10));
        Student student2 = new("DJ", new DateTime(2003, 6, 10));
        Course course = new("Computer Science");
        Department department = new() { DepartmentName = "CS", Budget = 1000000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) };
        department.AssignHead(instructor);
        course.EnrollStudent(student1, 'A');
        student1.EnrollInCourse(course, 'A');
        course.EnrollStudent(student2, 'B');
        student2.EnrollInCourse(course, 'B');
        Console.WriteLine($"Instructor: {instructor.Name}, Sal: {instructor.CalculateSalary()}, Head: {instructor.IsHeadOfDepartment()}");
        Console.WriteLine($"Student: {student1.Name}, Gpa: {student1.CalculateGPA()}");
        Console.WriteLine($"Student: {student2.Name}, Gpa: {student2.CalculateGPA()}");
        Console.WriteLine($"Department Name: {department.DepartmentName}, Budget: {department.Budget}, Start: {department.StartDate}, End: {department.EndDate}");
        
    }
}
