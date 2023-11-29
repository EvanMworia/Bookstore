using AuthSystem;

Auth auth = new Auth();



do
{
    Console.WriteLine("Choose either register of login: ");
    Console.WriteLine("Choose option 1 to login or option 2 to register");
    var option = Console.ReadLine();
    if (option != null)
    {
        bool isNumber = int.TryParse(option, out var number);
        if (isNumber)
        {
            if (number == 1)
            {
                auth.login();
                break;
            }
            else if (number == 2)
            {
                auth.register();
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }
} while (true);
