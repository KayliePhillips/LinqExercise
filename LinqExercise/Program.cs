using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE: Print the Sum of numbers
            Console.WriteLine("-----The sum of the numbers---------");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine();
            

            //DONE: Print the Average of numbers
            Console.WriteLine("-----The average of the numbers---------");
            Console.WriteLine(numbers.Average());
            Console.WriteLine();


            //DONE: Order numbers in ascending order and print to the console
            Console.WriteLine("-----Ascending Order---------");
            
            //This is the longer way to write the same line as below. Left both for reference.  

            //var ascendingorder = numbers.OrderBy(x => x);
            //foreach (var item in ascendingorder)
            //{
            //    Console.Write($" {item} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            numbers.OrderBy(x => x).ToList().ForEach(x => Console.Write($" {x} "));
            Console.WriteLine();
            Console.WriteLine();

            //DONE: Order numbers in descending order and print to the console
            Console.WriteLine("-----Descending Order---------");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($" {x}"));
            Console.WriteLine();
            Console.WriteLine();


            //DONE: Print to the console only the numbers greater than 6
            Console.WriteLine("-----Numbers Greater than 6---------");
            numbers.Where(x => x > 6)
                   .ToList()
                   .ForEach(x => Console.Write($" {x} "));
            Console.WriteLine();
            Console.WriteLine();



            //DONE: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("-----First 4 Numbers in Ascending Order---------");
            numbers.OrderBy(x => x)
                   .Take(4)
                   .ToList()
                   .ForEach(x => Console.Write($" {x} "));
            Console.WriteLine();
            Console.WriteLine();


            //DONE: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("-----List in descending order with index 4 changed to my age---------");
            //Practice with the foureach loop written out.  
            //numbers[4] = 35;  
            numbers.SetValue(35, 4);
            var ageChange = numbers.OrderByDescending(x => x);
            
            foreach (var item in ageChange)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("--------------------------------- Employees Section ---------------------");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE: Print all the employees' FullName properties to the console only if their
            //FirstName starts with a C OR an S and order this in acsending order by FirstName.
            Console.WriteLine($"These are the employees with first names that start with the letter 'c' or 's':");
            var firstWithCorS = employees.Where(x => x.FirstName.StartsWith('C') || 
                                                x.FirstName.StartsWith('S'))
                                                .OrderBy(x => x.FirstName);

            foreach (var item in firstWithCorS)
            {
                Console.WriteLine($"{item.FullName} ");
                
            }
            Console.WriteLine();
            Console.WriteLine();

            //DONE: Print all the employees' FullName and Age who are over the age 26 to the console
            //and order this by Age first and then by FirstName in the same result.
            Console.WriteLine($"These are the employees over the age of 26:");
            var fullName26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var item in fullName26)
            {
                Console.WriteLine($"{item.FullName}, {item.Age}");
            }

            Console.WriteLine();
            Console.WriteLine();


            //DONE: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var sumYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
                            .Sum(x => x.YearsOfExperience);

            var avgYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).
                            Average(x => x.YearsOfExperience);
            avgYOE = Math.Round(avgYOE, 2);
            Console.WriteLine($"This is the sum of the Years of Experience of all the " +
                $"employees who have worked less than 10 years and are older than 35: {sumYOE}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"This is the average of the Years of Experience of all the " +
               $"employees who have worked less than 10 years and are older than 35: {avgYOE}");

            Console.WriteLine();
            Console.WriteLine();


            //DONE: Add an employee to the end of the list without using employees.Add()
            Employee newEmployee = new Employee("Kaylie", "Phillips", 35, 5);
            var newList = employees.Append(newEmployee);

            foreach (var item in newList)
            {
                Console.WriteLine($"{item.FullName}");
            }

            Console.WriteLine();
            Console.ReadLine();

            // can simplify like below but its a little confusing for me still.  
            //Employee newEmployee = new Employee("Kaylie", "Phillips", 35, 5);
            //employees.Append(newEmployee).ToList().ForEach(x => Console.WriteLine(x.FullName));
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
