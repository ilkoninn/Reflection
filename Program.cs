using System.Reflection;
using System.Runtime.Versioning;
using UpcastingDowncasting.Models;

namespace UpcastingDowncasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ilkin", "Rajabov", 18);
            User user2 = new User("Tunay", "Huseynli", 20);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("===================================");

            foreach (Type item in assembly.GetTypes())
            {
                if (item.Name == "User")
                {
                    Console.WriteLine("\n====== Properities ======\n");
                    foreach (PropertyInfo prop in item.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        Console.WriteLine(prop);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n====== Fields ======\n");
                    foreach (FieldInfo field in item.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        Console.WriteLine(field);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n====== Methods ======\n");
                    foreach (MethodInfo method in item.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        Console.WriteLine(method);
                        Console.WriteLine();
                    }
                    break;
                }
            }

            Console.WriteLine("===================================");

            Type type = typeof(User);
            FieldInfo newField = type.GetField("Id", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo newProp = type.GetProperty("Name", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo newProp2 = type.GetProperty("Surname", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo newMethod = type.GetMethod("GetFullName", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo newMethod2 = type.GetMethod("ChangeAge", BindingFlags.NonPublic | BindingFlags.Static);


            Console.Write("Please, enter new age: ");
            int newAge = int.Parse(Console.ReadLine());
            Console.Write("Please, enter new name: ");
            string newName = Console.ReadLine();
            Console.Write("Please, enter new surname: ");
            string newSurname = Console.ReadLine();

            Console.WriteLine();
            newField.SetValue(user, newAge);
            Console.Write("New age: ");
            Console.WriteLine(newField.GetValue(user));

            Console.Write("New name: ");
            newProp.SetValue(user, newName);
            Console.WriteLine(newProp.GetValue(user));

            Console.Write("New surname: ");
            newProp2.SetValue(user, newSurname);
            Console.WriteLine(newProp2.GetValue(user));

            Console.WriteLine("==================");
            newMethod.Invoke(user, null);
            newMethod2.Invoke(user2, null);

        }
    }
}