using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AuthSystem
{
    class Auth
    {
        static string path = @"C:\Users\DEV.ANS\Desktop\a.txt";
        static string bookPath = @"C:\Users\DEV.ANS\Desktop\book.txt";
        public int newId(string path) {
            if (!File.Exists(path))
            {
                return 1;
            }
            else { 
            return File.ReadAllLines(path).Length + 1;   
            }

        }
        public void register() {
            while (true)
            {
                Console.WriteLine("\n\n\n\t\t\t  Register Form");
                Console.WriteLine("Enter username");
                string? userName = Console.ReadLine();
                Console.WriteLine("Enter password");
                string? password = Console.ReadLine();
              
                if (userName != null && password != null)
                {
                    User registerUser = new(userName, password);
                    registerUser.setId = newId(path);
                    if (!File.Exists(path)) {
                        File.WriteAllText(path, registerUser.ToString());
                        break;
                    }
                    File.AppendAllText(path, $"\n{registerUser.ToString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please input all the fields... :(");
                }

            }
        }

        public void login() {
            
            if (!File.Exists(path))
            {
                Console.WriteLine("User does not exist... :(");//maybe change the error message
                return;
            }

            var users = File.ReadAllLines(path);

            Dictionary<string, List<string>> usersData = new Dictionary<string, List<string>>();
            
            foreach ( var user in users)
            {
                string[] credentials =  user.Split(" ");
                string userName = credentials[1];
                string password = credentials[2];
                string role = credentials[3];
                List<string> passwordAndRole = new List<string>() { password, role };

                usersData.Add(userName, passwordAndRole);
             
            }

            do
            {
                Console.WriteLine("\n\n\n\t\t\tLogin Form");
                Console.WriteLine("Enter username: ");
                string? loginUserName = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string? loginPassword = Console.ReadLine();

                if (loginUserName != null && loginPassword != null) {

                    if (!usersData.ContainsKey(loginUserName))
                    {
                        Console.WriteLine("User does not exist. Please try again... :(");
                        continue;
                    }
                    else if (usersData[loginUserName][0] != loginPassword)
                    {
                        Console.WriteLine("Invalid password. Please try again... :(");
                        continue;
                    }
                    else {
                        Console.WriteLine($"Welcome, {loginUserName} - ({usersData[loginUserName][1]})");
                        
                        break;
                    }
                }

            } while (true);
        }

        public void listBook() {
            if (!File.Exists(bookPath) || File.ReadAllLines(bookPath).Length == 0) {
                Console.WriteLine("No books available...");
            }
        }
        public void addBook(string role, string bookName, string description) {
            if (role != "admin")
            {
                Console.WriteLine("You are not authorized to perform this task");
                return;
            }
            else
            {
                Books book = new Books(bookName, description);
                book.setId = newId(bookPath);
            }
        }

    }
}
