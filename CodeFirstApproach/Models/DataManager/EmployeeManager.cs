using CodeFirstApproach.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproach.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeDBContext _employeeContext;

        public EmployeeManager(EmployeeDBContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            return _employeeContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
        }

       
        public void SaveEmployee(Employee employee)
        {
             _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee,Employee employee1)
        {
            //_employeeContext.Employees.Update(employee);
            employee.FirstName = employee1.FirstName;
            employee.LastName = employee1.LastName;
            employee.PhoneNumber = employee1.PhoneNumber;
            _employeeContext.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }


    }
}
