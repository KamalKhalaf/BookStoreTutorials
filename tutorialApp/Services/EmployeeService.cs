using tutorialApp.Models;

namespace tutorialApp.Services
{
    public class EmployeeService
    {
        static List<Employee> employeesList { get; }
        static int nextEmp = 3;

        static EmployeeService()
        {
            employeesList = new List<Employee>()
            {
                new Employee {Id = 1, EmployeeName="kamal", EmployeeTittle ="Mobile App Developer", EmployeeSalary = 2500},
                new Employee {Id = 2, EmployeeName="waleed", EmployeeTittle ="CEO - Procco", EmployeeSalary = 50000}
            };
        } 

        public static List<Employee> GetAll() => employeesList;
        public static Employee Get(int id) => employeesList.FirstOrDefault(e => e.Id == id);

        public static void Add(Employee emp)
        {
            emp.Id = nextEmp;
            employeesList.Add(emp);
        }

        public static void Update(Employee emp)
        {
            var index = employeesList.FindIndex(e => e.Id == emp.Id);
            if (index == -1)
            {
                return;
            }else
            {
                employeesList[index] = emp;
            }
        }

        public static void Delete(int id)
        {
            var employee = Get(id);
            if (employee is null) return;
            employeesList.Remove(employee);
        }
    }
}
