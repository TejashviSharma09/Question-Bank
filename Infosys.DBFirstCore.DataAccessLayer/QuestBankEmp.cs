using System;
using System.Collections.Generic;
using System.Text;
using Infosys.DBFirstCore.DataAccessLayer.Models;
using System.Linq;

namespace Infosys.DBFirstCore.DataAccessLayer
{
    public class QuestBankEmp
    {
        QuestBankDBContext context;

        public QuestBankEmp()
        {
            context = new QuestBankDBContext();
        }

        public List<Employee> GetAllEmployees()
        {
        //     var employeesList = (from employee in context.Employees
        //                             orderby employee.EmpId
        //                             select employee).ToList();

            var employeesList = context.Employees.ToList();

            return employeesList;
        }

        public List<Employee> GetEmployeesOnRoleID(byte roleID)
        {
            List<Employee> empByRole = null;
            try
            {
                empByRole = context.Employees.Where(e => e.RoleId == roleID).ToList();
            }
            catch (Exception ex)
            {
                empByRole = null;
            }
            return empByRole;
        }

    }
}