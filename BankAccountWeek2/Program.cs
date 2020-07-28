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

            Console.WriteLine("Welcome to Maja's Bank");
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
                    if (String.IsNullOrWhiteSpace(userPassword)) { Console.WriteLine("Password cannot be empty"); }
                    else
                    {
                        person.Password = userPassword;
                        peopleList.Add(person);
                    }

                    //Determine if customer already exist

                    //foreach (var people in peopleList)
                    //{
                    //    if (people.Email == person.Email)
                    //    {
                    //        Console.WriteLine("Customer Already exist");
                    //        customerFound = true;
                    //    }
                    //}
                    //if (!customerFound) { 
                    //    peopleList.Add(person); 
                    //}


                    //Login goes in here
                    //  if (!customerFound)
                    //  {
                        
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

                        //Consider removing the code below
                        if (peopleList.Count == 0)
                        {
                            Console.Write("Customer does not exist count == 0");
                        }

                        //Determine if customer exist
                        bool customerFound = false;
                        foreach (var content in peopleList)
                        {
                            if (content.Email == userEmail && content.Password == userPassword)
                            {
                                //To implement account transaction
                                var creatingAccount = new CreateAccounts();
                                
                                //Console.WriteLine("Implement account transaction");
                                customerFound = true;
                                break;
                            }

                        }

                        if (!customerFound)
                        {
                            Console.WriteLine("Customer does not have existing account");
                        }

                        //Reset customerFound
                        customerFound = false;
                  //  }

                    Console.Write("Do you what to create another Customer? Enter Y for Yes or N for No: ");
                    userInputs = Console.ReadLine();
                    Console.WriteLine();
                    if(userInputs.ToLower() == "n") { userInputs = "q"; }
       
                }

            } while (userInputs.ToLower() != "q");

            //To remove this testing
            foreach(var people in peopleList)
            {
                Console.WriteLine($"{people.Id} {people.FullName()} {people.Email} {people.Password}");
            }



            //Create account Object
            //If conditional statement to be used in here

            //string userMoney;
            //string customerResponse;

            //Console.Write("Enter account type (choose Current or Savings Account) ");
            //var accountType = Console.ReadLine();
            //Console.WriteLine();

            //if (String.IsNullOrWhiteSpace(accountType))
            //{
            //    Console.WriteLine("Account type cannot be empty");
            //}
            //else if(accountType.Trim().ToLower() == "current account" || accountType.Trim().ToLower() == "current")
            //{

            //    //Creating current account
                
            //    Console.Write("Enter the initial opening balance minimum of #1,000:00 : ");
            //    userMoney = Console.ReadLine();
            //    Console.WriteLine();

            //    if (String.IsNullOrWhiteSpace(userMoney))
            //    {
            //        Console.WriteLine("Opening balance cannot be empty");
            //    }
            //    else
            //    {

            //        try
            //        {
            //            var personCurrentAccount = new CurrentAccount(person.FullName(), Convert.ToDecimal(userMoney), accountType);
            //            Console.WriteLine(personCurrentAccount.AccountStatememt());

            //            do
            //            {
            //                Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
            //                customerResponse = Console.ReadLine();
            //                if (customerResponse.ToLower() == "d")
            //                {
            //                    Console.Write("Enter amount to deposit: ");
            //                    userMoney = Console.ReadLine();
            //                    Console.Write("Enter remark, necessary for transaction success: ");
            //                    var remark = Console.ReadLine();
            //                    Console.WriteLine();
            //                    if (!String.IsNullOrWhiteSpace(remark))
            //                    {
            //                        personCurrentAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
            //                        Console.WriteLine(personCurrentAccount.AccountStatememt());
            //                    }
            //                    else { Console.WriteLine("Transaction fail, try again"); }
            //                }
            //                else if (customerResponse == "w")
            //                {
            //                    Console.Write("Enter amount to withdraw: ");
            //                    userMoney = Console.ReadLine();
            //                    Console.Write("Enter remark, necessary for transaction success: ");
            //                    var remark = Console.ReadLine();
            //                    Console.WriteLine();
            //                    if (!String.IsNullOrWhiteSpace(remark))
            //                    {
            //                        personCurrentAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
            //                        Console.WriteLine(personCurrentAccount.AccountStatememt());
            //                    }
            //                    else { Console.WriteLine("Transaction fail, try again"); }
            //                }
            //                else if (customerResponse.ToLower() != "q")
            //                {
            //                    Console.WriteLine("Wrong input, try again");
            //                }

            //            } while (customerResponse != "q");

            //            //Output Account balance for a particular account
            //            var accountBalanceBuilder = new StringBuilder();
            //            Console.WriteLine();
            //            Console.WriteLine($"Account Balance after transaction");
            //            accountBalanceBuilder.AppendLine("Account Number\t\tBalance");
            //            accountBalanceBuilder.AppendLine($"{personCurrentAccount.AccountNumber}\t\t{personCurrentAccount.Balance}");
            //            Console.WriteLine(accountBalanceBuilder.ToString());

            //        }
            //        catch (InvalidOperationException e)
            //        {
            //            Console.WriteLine("Error! " + e.Message);
            //        }
            //        catch(ArgumentOutOfRangeException)
            //        {
            //            Console.WriteLine("Error! You cannot deposit zero or negative amount");
            //        }

            //    }
                
            //}

            //else if(accountType.Trim().ToLower() == "savings account" || accountType.Trim().ToLower() == "savings")
            //{

            //    //Create savings account
            //    Console.Write("Enter the initial opening balance minimum of #100:00 : ");
            //    userMoney = Console.ReadLine();
            //    Console.WriteLine();

            //    if (String.IsNullOrWhiteSpace(userMoney))
            //    {
            //        Console.WriteLine("Opening balance cannot be empty");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            var personSavingsAccount = new SavingsAccount(person.FullName(), Convert.ToDecimal(userMoney), accountType);
            //            Console.WriteLine(personSavingsAccount.AccountStatememt());
                        
            //            do
            //            {
            //                Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
            //                customerResponse = Console.ReadLine();
            //                if(customerResponse.ToLower() == "d")
            //                {
            //                    Console.Write("Enter amount to deposit: ");
            //                    userMoney = Console.ReadLine();
            //                    Console.Write("Enter remark, necessary for transaction success: ");
            //                    var remark = Console.ReadLine();
            //                    Console.WriteLine();
            //                    if (!String.IsNullOrWhiteSpace(remark))
            //                    {
            //                        personSavingsAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
            //                        Console.WriteLine(personSavingsAccount.AccountStatememt());
            //                    }
            //                    else { Console.WriteLine("Transaction fail, try again"); }
            //                }
            //                else if(customerResponse == "w")
            //                {
            //                    Console.Write("Enter amount to withdraw: ");
            //                    userMoney = Console.ReadLine();
            //                    Console.Write("Enter remark, necessary for transaction success: ");
            //                    var remark = Console.ReadLine();
            //                    Console.WriteLine();
            //                    if (!String.IsNullOrWhiteSpace(remark))
            //                    {
            //                        personSavingsAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
            //                        Console.WriteLine(personSavingsAccount.AccountStatememt());
            //                    }
            //                    else { Console.WriteLine("Transaction fail, try again"); }
            //                }
            //                else if(customerResponse.ToLower() != "q")
            //                {
            //                    Console.WriteLine("Wrong input, try again");
            //                }

            //            } while (customerResponse.ToLower() != "q");

            //            //Output Account balance for a particular account
            //            var accountBalanceBuilder = new StringBuilder();
            //            Console.WriteLine();
            //            Console.WriteLine($"Account Balance after transaction");
            //            accountBalanceBuilder.AppendLine("Account Number\t\tBalance");
            //            accountBalanceBuilder.AppendLine($"{personSavingsAccount.AccountNumber}\t\t{personSavingsAccount.Balance}");
            //            Console.WriteLine(accountBalanceBuilder.ToString());
            //        }
            //        catch (InvalidOperationException e)
            //        {
            //            Console.WriteLine("Error! " + e.Message);
            //        }
            //    }
                  
            //}
            //else { Console.WriteLine("Please type Current or Savings Account"); }


        }
    }
}
