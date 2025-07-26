namespace Leetcode.Linq
{
    internal class LinqTraining3
    {
        public static List<Employee> Employees { get; set; }

        public static void Execute()
        {
            Fill();

            var names = Employees.Where(x => x.Age > 30).Select(x => x.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            var departments = Employees.GroupBy(x => x.Department)
                                       .Select(x => new { Name = x.Key, Empls = x.Select(x => x.Name)});
            foreach (var department in departments)
            {
                Console.WriteLine(department.Name + ":");
                foreach (var emp in department.Empls)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine();
            }

            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var quadrInts = ints.Select(x => x*x).Where(x => x > 20).ToList();
            foreach (var quadr in quadrInts)
            {
                Console.WriteLine(quadr);
            }
            Console.WriteLine();

            List<Employee> currentEmp = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Age = 25, Department = "HR" },
                new Employee { Id = 2, Name = "Bob", Age = 35, Department = "IT" },
                new Employee { Id = 3, Name = "Charlie", Age = 40, Department = "Finance" },
                new Employee { Id = 4, Name = "David", Age = 28, Department = "IT" },
                new Employee { Id = 5, Name = "Leon", Age = 27, Department = "Guard"}
            };

            List<Employee> disbandEmp = new List<Employee>
            {
                new Employee { Id = 3, Name = "Charlie", Age = 40, Department = "Finance" },
                new Employee { Id = 4, Name = "David", Age = 28, Department = "IT" },
            };

            var empResult = currentEmp.Union(disbandEmp).Distinct();

            foreach(var emp in empResult)
            {
                Console.WriteLine(emp.Name);
            }
        }

        public static void Fill()
        {
            Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Age = 25, Department = "HR" },
                new Employee { Id = 2, Name = "Bob", Age = 35, Department = "IT" },
                new Employee { Id = 3, Name = "Charlie", Age = 40, Department = "Finance" },
                new Employee { Id = 4, Name = "David", Age = 28, Department = "IT" },
            };
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
}
