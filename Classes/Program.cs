// See https://aka.ms/new-console-template for more information

using System;
using System.Security.Cryptography;

namespace Classes
{
    //Abstraction - cannot be instantiated directly
    // and methods are implemented by the derived class
    public abstract class Person
    {
        private int age;
        private string name;
        
        //Encapsulation
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Abstraction
        public virtual void CalculateSalary() { }
        
        public abstract void DisplayDetails();
        
    }
    
    // Inheritance
    public class Student : Person
    {
        private double gpAverage;

        public double Gpa
        {
            get { return gpAverage; }
            set { gpAverage = value; }
        }

        public Student(string name, int age, double gpa): base(name, age)
        {
            gpAverage = gpa;
        }
        
        public override void DisplayDetails()
        {
            Console.WriteLine($"Student Name: {Name}, Age: {Age}, GPA: {Gpa}");
        }
        
        
        public override void CalculateSalary()
        {
            Console.WriteLine("Students do not have a salary.");
        }
        
    }

    // Inheritance
    public class Instructor : Person
    {
        public double baseSalary;

        public double BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }

        public Instructor(string name, int age, double salary) : base(name, age)
        {
            baseSalary = salary;
        }
        
        public override void DisplayDetails()
        {
            Console.WriteLine($"Instructor Name: {Name}, Age: {Age}, Salary: {BaseSalary}");
        }
        
        // Runtime Polymorphism with overriding
        public override void CalculateSalary()
        { 
            double salary = baseSalary + (BaseSalary*0.2);
            Console.WriteLine($"Salary + Bonus: {salary}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person student = new Student("Rakesh", 25, 3.8);
            student.DisplayDetails();
            student.CalculateSalary();
            Console.WriteLine(" ");
            Person instructor = new Instructor("Rakesh", 25, 50000);
            instructor.DisplayDetails();
            instructor.CalculateSalary();
        }
    }
}