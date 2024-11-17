using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fast_Food.Models;

namespace Fast_Food.Services
{
    internal class JsonHelper
    {
        public static void SaveToJson(string filePath, List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(filePath, json);
        }
        public static List<Employee> LoadToJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json);
        }
        public static List<Employee> LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Employee>(); 
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json);
        }
    }
}
