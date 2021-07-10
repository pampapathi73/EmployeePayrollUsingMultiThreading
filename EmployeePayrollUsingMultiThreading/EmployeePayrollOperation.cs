using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollUsingMultiThreading
{
     public class EmployeePayrollOperation
    {
        
        public List<EmployeeDetails> employeePayrollDetailsList = new List<EmployeeDetails>();
        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.addEmployeeToPayroll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailsList.ToString());

        }

        public void Display()
        {
            foreach (EmployeeDetails emp in this.employeePayrollDetailsList)
            {
                Console.WriteLine(emp.EmployeeID + "    " + emp.EmployeeName + "    " + emp.Address + " " + emp.BasicPay + "    " + emp.City + "    " + emp.Country + "     " + emp.Deduction + "   " + emp.Department + "\n");
            }
        }


        public void addEmployeeToPayroll(EmployeeDetails emp)
        {
            employeePayrollDetailsList.Add(emp);
        }

        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDetailsList)
        {

            employeePayrollDetailsList.ForEach(employeeData =>
            {
                //Console.WriteLine("abc");
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                    this.addEmployeeToPayroll(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.EmployeeName);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailsList.Count);
        }
    }
}
