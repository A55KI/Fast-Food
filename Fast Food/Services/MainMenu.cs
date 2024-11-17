using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fast_Food.Models;

namespace Fast_Food.Services
{
    internal class MainMenu
    {
        private string filePath;
        private Login login;

        public MainMenu(string filePath)
        {
            this.filePath = filePath;
            this.login = new Login(filePath);
            if (File.Exists(filePath))
            {
                string FileContent = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(FileContent.Trim()))
                {
                    Console.WriteLine("Plik jest pusty. Dodaję zawartość...");
                    Employee.CreateAndSaveEmployeeList(filePath);
                }
            }
            else
            {
                Console.WriteLine("Plik nie istnieje. Tworzę plik...");
                Employee.CreateAndSaveEmployeeList(filePath);
            }
        }
        
        public void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Witaj w Dobroć Burger!");
                Console.WriteLine("Wybierz jedną z opcji:\n");
                Console.WriteLine("1. Logowanie pracownika");
                Console.WriteLine("2. Złóż zamówienie");
                Console.WriteLine("3. Wyjście");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1"://logowanie
                        break;
                    case "2"://zamów
                        Order order = new Order();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór opcji");
                        break;
                }
            }
        }
    }
}
