using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class Program
    {
        static void Main(string[] args)
        {

            var person = new Customer();
            var peopleList = new List<Customer>();

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
            }
            peopleList.Add(person);

            //Create account Object
            string userMoney;
            string customerResponse;

            Console.Write("Enter account type (choose Current or Savings Account) ");
            var accountType = Console.ReadLine();
            Console.WriteLine();

            if (String.IsNullOrWhiteSpace(accountType))
            {
                Console.WriteLine("Account type cannot be empty");
            }
            else if(accountType.Trim().ToLower() == "current account" || accountType.Trim().ToLower() == "current")
            {

                //Creating current account
                Console.Write("Enter the initial opening balance minimum of #1,000:00 : ");
                userMoney = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(userMoney))
                {
                    Console.WriteLine("Opening balance cannot be empty");
                }
                else
                {

                    try
                    {
                        var personCurrentAccount = new CurrentAccount(person.FullName(), Convert.ToDecimal(userMoney), accountType);
                        Console.WriteLine(personCurrentAccount.AccountStatememt());

                        do
                        {
                            Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
                            customerResponse = Console.ReadLine();
                            if (customerResponse.ToLower() == "d")
                            {
                                Console.Write("Enter amount to deposit: ");
                                userMoney = Console.ReadLine();
                                Console.Write("Enter remark, necessary for transaction success: ");
                                var remark = Console.ReadLine();
                                Console.WriteLine();
                                if (!String.IsNullOrWhiteSpace(remark))
                                {
                                    personCurrentAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                    Console.WriteLine(personCurrentAccount.AccountStatememt());
                                }
                                else { Console.WriteLine("Transaction fail, try again"); }
                            }
                            else if (customerResponse == "w")
                            {
                                Console.Write("Enter amount to withdraw: ");
                                userMoney = Console.ReadLine();
                                Console.Write("Enter remark, necessary for transaction success: ");
                                var remark = Console.ReadLine();
                                Console.WriteLine();
                                if (!String.IsNullOrWhiteSpace(remark))
                                {
                                    personCurrentAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                    Console.WriteLine(personCurrentAccount.AccountStatememt());
                                }
                                else { Console.WriteLine("Transaction fail, try again"); }
                            }
                            else if (customerResponse.ToLower() != "q")
                            {
                                Console.WriteLine("Wrong input, try again");
                            }

                        } while (customerResponse != "q");

                        //Output Account balance for a particular account
                        var accountBalanceBuilder = new StringBuilder();
                        Console.WriteLine();
                        Console.WriteLine($"Account Balance after transaction");
                        accountBalanceBuilder.AppendLine("Account Number\t\tBalance");
                        accountBalanceBuilder.AppendLine($"{personCurrentAccount.AccountNumber}\t\t{personCurrentAccount.Balance}");
                        Console.WriteLine(accountBalanceBuilder.ToString());

                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error! " + e.Message);
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Error! You cannot deposit zero or negative amount");
                    }

                }
                
            }

            else if(accountType.Trim().ToLower() == "savings account" || accountType.Trim().ToLower() == "savings")
            {

                //Create savings account
                Console.Write("Enter the initial opening balance minimum of #100:00 : ");
                userMoney = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(userMoney))
                {
                    Console.WriteLine("Opening balance cannot be empty");
                }
                else
                {
                    try
                    {
                        var personSavingsAccount = new SavingsAccount(person.FullName(), Convert.ToDecimal(userMoney), accountType);
                        Console.WriteLine(personSavingsAccount.AccountStatememt());
                        
                        do
                        {
                            Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
                            customerResponse = Console.ReadLine();
                            if(customerResponse.ToLower() == "d")
                            {
                                Console.Write("Enter amount to deposit: ");
                                userMoney = Console.ReadLine();
                                Console.Write("Enter remark, necessary for transaction success: ");
                                var remark = Console.ReadLine();
                                Console.WriteLine();
                                if (!String.IsNullOrWhiteSpace(remark))
                                {
                                    personSavingsAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                    Console.WriteLine(personSavingsAccount.AccountStatememt());
                                }
                                else { Console.WriteLine("Transaction fail, try again"); }
                            }
                            else if(customerResponse == "w")
                            {
                                Console.Write("Enter amount to withdraw: ");
                                userMoney = Console.ReadLine();
                                Console.Write("Enter remark, necessary for transaction success: ");
                                var remark = Console.ReadLine();
                                Console.WriteLine();
                                if (!String.IsNullOrWhiteSpace(remark))
                                {
                                    personSavingsAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                    Console.WriteLine(personSavingsAccount.AccountStatememt());
                                }
                                else { Console.WriteLine("Transaction fail, try again"); }
                            }
                            else if(customerResponse.ToLower() != "q")
                            {
                                Console.WriteLine("Wrong input, try again");
                            }

                        } while (customerResponse.ToLower() != "q");

                        //Output Account balance for a particular account
                        var accountBalanceBuilder = new StringBuilder();
                        Console.WriteLine();
                        Console.WriteLine($"Account Balance after transaction");
                        accountBalanceBuilder.AppendLine("Account Number\t\tBalance");
                        accountBalanceBuilder.AppendLine($"{personSavingsAccount.AccountNumber}\t\t{personSavingsAccount.Balance}");
                        Console.WriteLine(accountBalanceBuilder.ToString());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error! " + e.Message);
                    }
                }
                  
            }
            else { Console.WriteLine("Please type Current or Savings Account"); }


        }
    }
}
