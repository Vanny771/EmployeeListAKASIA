using System;
using System.Collections.Generic;

class Program
{
    static List<Employee> employeeList = new List<Employee>();

    static void Main()
    {
        // Main program looping
        while (true)
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Delete Employee");
            Console.WriteLine("3. Show Employee List");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    DeleteEmployee();
                    break;
                case "3":
                    ShowEmployeeList();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Function to add a new employee to the list
    static void AddEmployee()
    {
        Console.WriteLine("Enter Employee Details:");

        // Get EmployeeId from user input
        Console.Write("EmployeeId: ");
        string employeeId = Console.ReadLine();

        // Validate EmployeeId
        if (string.IsNullOrEmpty(employeeId))
        {
            Console.WriteLine("EmployeeId cannot be null or empty. Please try again.\n");
            return;
        }

        // Check for duplicate EmployeeId
        if (employeeList.Exists(e => e.EmployeeId == employeeId))
        {
            Console.WriteLine("Employee with the same EmployeeId already exists. Please enter a unique EmployeeId.\n");
            return;
        }

        // Get FullName from user input
        Console.Write("FullName: ");
        string fullName = Console.ReadLine();

        // Validate FullName
        if (string.IsNullOrEmpty(fullName))
        {
            Console.WriteLine("FullName cannot be null or empty. Please try again.\n");
            return;
        }

        // Get and validate BirthDate from user input
        DateTime birthDate;
        while (true)
        {
            Console.Write("BirthDate (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();

            if (string.IsNullOrEmpty(dateInput))
            {
                Console.WriteLine("BirthDate cannot be null or empty. Please try again.");
                continue;
            }

            if (DateTime.TryParse(dateInput, out birthDate))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
            }
        }

        // Create a new Employee object and add it to the list
        Employee newEmployee = new Employee
        {
            EmployeeId = employeeId,
            FullName = fullName,
            BirthDate = birthDate
        };

        //Validate for duplicate employee
        if (employeeList.Exists(e => e.FullName == fullName && e.BirthDate == birthDate))
        {
            Console.WriteLine("Duplicate employee. Please input new employee.\n");
            return;
        }

        employeeList.Add(newEmployee);
        Console.WriteLine("Employee added successfully!\n");
    }

    // Function to delete an employee from the list
    static void DeleteEmployee()
    {
        // Get EmployeeId to delete from user input
        Console.Write("Enter EmployeeId to delete: ");
        string employeeIdToDelete = Console.ReadLine();

        // Validate EmployeeId
        if (string.IsNullOrEmpty(employeeIdToDelete))
        {
            Console.WriteLine("EmployeeId cannot be null or empty. Please try again.\n");
            return;
        }

        // Find the employee in the list
        Employee employeeToRemove = employeeList.Find(e => e.EmployeeId == employeeIdToDelete);

        // Remove the employee if found, otherwise, display a message
        if (employeeToRemove != null)
        {
            employeeList.Remove(employeeToRemove);
            Console.WriteLine("Employee deleted successfully!\n");
        }
        else
        {
            Console.WriteLine("Employee not found!\n");
        }
    }

    // Function to display the list of employees
    static void ShowEmployeeList()
    {
        Console.WriteLine("Employee List:");

        // Check if there are employees in the list
        if (employeeList.Count > 0)
        {
            // Display each employee details
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"EmployeeId: {employee.EmployeeId}, FullName: {employee.FullName}, BirthDate: {employee.BirthDate.ToString("yyyy-MM-dd")}");
            }
        }
        else
        {
            // Display a message if there are no employees in the list
            Console.WriteLine("No employees in the list.\n");
        }
    }
}

// Employee class to represent employee data
class Employee
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}
