using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fast_Food.Services;

namespace Fast_Food.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public Employee(int id, string name, string surname, int age, string password, string salt)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Password = password;
            Salt = salt;
        }
         
        public static void CreateAndSaveEmployeeList(string filePath)
        {
            List<Employee> Employees = new List<Employee>();

            string salt1 = Login.CreateSalt();
            string hashedPassword1 = Login.HashPassword("password1", salt1);
            Employees.Add(new Employee(1, "Adam", "Poltys", 48, hashedPassword1, salt1));

            string salt2 = Login.CreateSalt();
            string hashedPassword2 = Login.HashPassword("password2", salt2);
            Employees.Add(new Employee(2, "Radek", "Semen", 9, hashedPassword2, salt2));

            JsonHelper.SaveToJson(filePath, Employees);
        }
    }
}
