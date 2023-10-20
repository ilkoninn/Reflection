using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace UpcastingDowncasting.Models
{
    internal class User
    {
        private int Id;
        private string Name { get; set; }
        private string Surname { get; set; }
        private static int Age;

        public User(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        private void GetFullName()
        {
            Console.WriteLine($"{Name} {Surname}");
        }

        private static void ChangeAge()
        {
            while(true)
            {
                Console.Write("Please, enter new age: ");
                int age = int.Parse(Console.ReadLine());

                if(age != Age) 
                {
                    Age = age;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again!");
                }
            }
            
        }
    }
}
