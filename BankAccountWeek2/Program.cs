using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInputs;
            var peopleList = new List<Customer>();
            var buildString = new StringBuilder();
            buildString.Append('-', 120);
            buildString.AppendLine();
            buildString.Append("\t\t\t\t\t\tWelcome to Maja's Bank");
            buildString.AppendLine();
            buildString.Append('-', 120);
            Console.WriteLine(buildString.ToString());
            Console.WriteLine();

            do
            {
                Console.WriteLine("Register if you are new or login if you alresdy have account");
                Console.WriteLine();
                Console.Write("Enter R to register or Q to terminate this transaction: ");
                userInputs = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(userInputs))
                {
                    Console.WriteLine("Please enter R to register or Q to terminate");
                    
                }

                //Registeration goes in here
                else if(userInputs.ToLower() == "r")
                {

                    var person = new Customer();

                    try
                    {
                        Console.Write("Enter your Firstname: ");
                        var firstName = Console.ReadLine();
                        Console.WriteLine();
                        person.FirstName = firstName;
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine("Error! " + e.Message);
                        break;
                    }

                    try
                    {

                        Console.Write("Enter your Lastname: ");
                        var lastName = Console.ReadLine();
                        Console.WriteLine();
                        person.LastName = lastName;
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine("Error! " + e.Message);
                        break;
                    }


                    try
                    {
                        Console.Write("Enter your email address: ");
                        var email = Console.ReadLine();
                        person.Email = email;
                        Console.WriteLine();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Error! " + e.Message);
                        break;
                    }

                    Console.Write("Enter a password: ");
                    var userPassword = Console.ReadLine();
                    Console.WriteLine();
                    if (String.IsNullOrWhiteSpace(userPassword)) 
                    {
                        Console.WriteLine("Password cannot be empty");
                        break;
                    }
                    else
                    {
                        person.Password = userPassword;
                        peopleList.Add(person);
                        Console.WriteLine("Customer registration successful");
                        Console.WriteLine();
                    }

                    //Login goes in here
                    string anotherAccount;
                    do
                    {
                        //Login to create account
                        Console.WriteLine("Enter your email and password to login");
                        Console.WriteLine();
                        Console.Write("Enter email: ");
                        var userEmail = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter password: ");
                        userPassword = Console.ReadLine();
                        Console.WriteLine();
                        if (String.IsNullOrWhiteSpace(userEmail) || String.IsNullOrWhiteSpace(userPassword))
                        {
                            Console.WriteLine("Email can't be empty, please try again");
                        }

                        //Determine if customer exist
                        bool customerFound = false;
                        foreach (var content in peopleList)
                        {
                            if (content.Email == userEmail && content.Password == userPassword)
                            {
                                //To implement account transaction
                                var creatingAccount = new CreateAccounts(person.FullName());
                                customerFound = true;
                                break;
                            }

                        }

                        if (!customerFound)
                        {
                            Console.WriteLine("Email and password incorrect, please try again");
                        }

                        //Reset customerFound
                        customerFound = false;
                        Console.Write("To create another Account enter Y for Yes or N for No: ");
                        anotherAccount = Console.ReadLine();
                        Console.WriteLine();
                        
                    } while (anotherAccount.ToLower() != "n");

                    Console.Write("Do you what to create another Customer? Enter Y for Yes or N for No: ");
                    userInputs = Console.ReadLine();
                    Console.WriteLine();
                    if(userInputs.ToLower() == "n") { userInputs = "q"; }
       
                }

            } while (userInputs.ToLower() != "q");

        }
    }
}
