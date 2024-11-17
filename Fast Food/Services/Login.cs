using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fast_Food.Models;

namespace Fast_Food.Services
{
    internal class Login
    {
        private readonly string FilePath;
        private List<Employee> Employees;
        public Login(string filePath)
        {
            FilePath = filePath;
            Employees = JsonHelper.LoadFromJson(FilePath);
        }

        public void SaveEmployees(List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(FilePath, json);
        }

        public List<Employee> LoadEmployees()
        {
            return Employees;
        }
        public bool Logger(string surname, string password)
        {
            var employee = Employees.FirstOrDefault(e => e.Surname == surname);
            if (employee == null)
            {
                Console.WriteLine("Pracownik o podanym nazwisku nie istnieje w bazie.");
                return false;
            }

            string hashedInputPassword = HashPassword(password, employee.Salt);
            if(employee.Password == hashedInputPassword)
            {
                Console.WriteLine("Zalogowano pomyślnie!");
                return true;
            }
            else
            {
                Console.WriteLine("Niepoprawne dane logowania!");
                return false;
            }
            //return employee.Password == hashedInputPassword;
        }

        public static string CreateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
