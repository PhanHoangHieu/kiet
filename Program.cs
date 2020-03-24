using System;
using System.Collections;
using System.Collections.Generic;
namespace kiet
{
    class Program
    {
        static void Main(string[] args)
        {
            MangagerFunction manafun = new MangagerFunction();
            manafun.initMenu();
            manafun.add();
            manafun.showListPerson();
            Console.WriteLine("Max salary: {0}",manafun.highestSalary());
            Console.WriteLine("Total salary: {0}",manafun.totaltSalary());
        }
    }

    public abstract class Person
    {
        private int id;
        private string name;
        private string dateOfBirth;
        private string  address;

        public Person(){}
        public Person(int id, string name,string dateOfBirth,string address)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
        }

        public int ID
        {
            set{id=value;}
            get{return id;}
        }
        public string Name
        {
            set{name=value;}
            get{return name;}
        }
        public string DateOfBirth
        {
            set{dateOfBirth=value;}
            get{return dateOfBirth;}
        }
        public string Address
        {
            set{address=value;}
            get{return address;}
        }

        public void input() {
		    Console.WriteLine("Person id: ");
            this.id = int.Parse(Console.ReadLine());

            Console.WriteLine("Person name: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Person DateOfBirth: ");
            this.dateOfBirth = Console.ReadLine();

            Console.WriteLine("Person address: ");
            this.address = Console.ReadLine();
        }
        public abstract double getSalary();
        public abstract void  show();
    }

    public class Employee : Person 
    {
        private double salaryFactor;
        public Employee() {
		
	    }

        public double SalaryFactor
        {
            set { salaryFactor = value; }
            get { return salaryFactor; }
        }
        public new void input() {
		    base.input();
		    Console.WriteLine("Person SalaryFactor: ");
		    this.salaryFactor = int.Parse(Console.ReadLine());
	    }
        public override double getSalary()
        {
            return this.salaryFactor;// = mSalaryFactor;
        }
        public override void  show()
        {
            Console.WriteLine("----- INFORMATION OF A Person --------");
		    Console.WriteLine("ID: {0}" ,base.ID);
		    Console.WriteLine("NAME: {0}" ,base.Name);
		    Console.WriteLine("AGE: {0}" ,base.DateOfBirth);
		    Console.WriteLine("ADDRESS: {0}",base.Address);
		    Console.WriteLine("Salary : {0}",getSalary());
        }
    }

    public class Teacher : Person
    {
        private int hour;
        public int Hour
        {
            set { hour = value; }
            get { return hour; }
        }

        public Teacher() {
		// TODO Auto-generated constructor stub
	    }

	    public Teacher(int hour) {
		    this.hour = hour;
	    }

        public new void  input() {
		    base.input();
		    Console.WriteLine("Person mHour: ");
            this.hour = int.Parse(Console.ReadLine());

        }
	    public override double getSalary() {
		    return 0;
	    }
	    public override void show() {
		    Console.WriteLine("Hour: {0}",this.hour);
	    }
    }

    public class MangagerFunction
    {
        List<Employee> listEmployee = new List<Employee>();
	    Employee employee = new Employee();

        public MangagerFunction() {
		// TODO Auto-generated constructor stub
	    }

        public void initMenu() {
		    Console.WriteLine("OPTIONAL");
		    Console.WriteLine("\t\t=== Manager Person ===");
		    Console.WriteLine(" 1.Input employee or teacher ");
		    Console.WriteLine(" 2.Show payroll list. ");
		    Console.WriteLine(" 3.Show person has highest salary");
		    Console.WriteLine(" 4.Show total salary must paid");
		    Console.WriteLine(" 5.Exit");
	    }

        public void add() {
            for (int i = 0 ;i < 2; i++) // mhap vao 2 nguoi
            {
                Console.WriteLine("==========Nhap employee thu {0}============", i + 1);
                Employee employee = new Employee();
                employee.input();
                listEmployee.Add(employee);
            }
        }

	    public void showListPerson() {
		    for (int i = 0; i < listEmployee.Count; i++) {
			    Console.WriteLine("=== Information Person " + (i + 1) + " ===");
			    listEmployee[i].show();
		    }
	    }

	    public double highestSalary() { //suy nghi don gian thôi,
            double maxsalary = 0;
            for (int i = 0; i < listEmployee.Count; i++) {
			    if(listEmployee[i].getSalary() > maxsalary) maxsalary = listEmployee[i].getSalary();
            }
            return maxsalary;
        }

        public double totaltSalary() {
		    double total = 0;
		    for (int i = 0; i < listEmployee.Count; i++) {
                total += listEmployee[i].getSalary();
            }
            return total;
        }
    }
}
