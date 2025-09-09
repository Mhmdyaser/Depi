using EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HrDbContext db = new HrDbContext();

            #region Select * from Employees 
            //var emps = db.Employees;
            //foreach (var emp in emps)
            //{
            //    Console.WriteLine($"ID {emp.Id} , FullName {emp.FirstName}  {emp.LastName}");
            //}
            #endregion

            #region save to memory
            // ToList() => Execute the query and bring the data from database to memory
            //var emps1 = db.Employees.ToList();
            //foreach (var emp in emps1)
            //{
            //    Console.WriteLine($"ID {emp.Id} , FullName {emp.FirstName}  {emp.LastName}");
            //}
            #endregion

            #region Where IQuerable
            //var emps2 = db.Employees.Where(e=> e.MonthlySalary > 2000).ToList();
            //foreach (var emp in emps2)
            //{
            //    Console.WriteLine($"ID {emp.Id} , FullName {emp.FirstName}  {emp.LastName} Salary {emp.MonthlySalary}");
            //}
            #endregion

            #region Include Practice
            //var emps3 = db.Employees.Include(e => e.Department).ToList();
            //foreach (var emp in emps3)
            //{
            //    Console.WriteLine($"ID {emp.Id} , FullName {emp.FirstName}  {emp.LastName} , Department {emp.Department.Name}");
            //}
            #endregion

            #region Tracking
            //find the employee with ID = 285
            //var emp = db.Employees.Find(285);
            //emp.FirstName = "Updated Name";
            //Console.WriteLine(emp.FirstName);
            //db.SaveChanges();

            //Single
            //var emp2 = db.Employees.Single(e => e.Id == 286);
            //emp2.FirstName = "Single Name";
            //Console.WriteLine(emp2.FirstName);
            //Console.WriteLine(db.Entry(emp2).State=EntityState.Unchanged); // Unchanged 
            //db.SaveChanges();
            #endregion

            #region Add New Employee
            //Employee newEmp = new Employee() {FirstName="Mhmd ", LastName="Yaser", Gendor="M", DateOfBirth=new DateTime(2004,2,27), CountryId=1, DepartmentId=1, HireDate=DateTime.Now, MonthlySalary=5000, BonusPerc=0.1};
            //db.Employees.Add(newEmp);
            //db.SaveChanges();
            //Console.WriteLine($"New Employee ID = {newEmp.Id}");
            #endregion

            #region Delete Employee
            //var emp = db.Employees.Find(290);
            //if (emp != null)
            //{
            //    Console.WriteLine($"Found Employee ID = {emp.Id}");
            //    db.Employees.Remove(emp);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
            //}

            #endregion

            #region upddate Department
            //var dept = db.Departments.Find(3);
            //dept.Name = "IT";
            //Console.WriteLine(dept.Name);
            //db.SaveChanges();
            #endregion
        }
    }
}
