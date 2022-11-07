// See https://aka.ms/new-console-template for more information

using System;
using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;

namespace Infosys.DBFirstCore.ConsoleUI
{
        class Program
        {
            static void Main(string[] args)
            {
                QuestBankEmp emp = new QuestBankEmp();
                

                var employees = emp.GetAllEmployees();
                Console.WriteLine("-------------------------------");
                // Console.WriteLine("EmpID\tEmpName\tUsername\tPassword\tRoleID");
                Console.WriteLine("EmpID\tEmpName");
                Console.WriteLine("-------------------------------");

                foreach (var employee in employees)
                {
                    // Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\n", employee.EmpId, employee.EmpName, employee.Username, employee.Password, employee.RoleId);
                    Console.WriteLine("{0}\t\t{1}", employee.EmpId, employee.EmpName);
                }


                // byte roleID = 3;
                // List<Employee> empByRole = emp.GetEmployeesOnRoleID(roleID);

                // if (empByRole.Count == 0)
                // {
                //     Console.WriteLine("No Employee Found!!");
                // }
                // else
                // {
                //     foreach (var employee in empByRole)
                //     {
                //         Console.WriteLine(employee.EmpName, employee.RoleId);
                //     }
                // }


            }
        }
}