//Task 1-Methods, Method Parameters, Method Overloading

using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Transactions;
using System;

//Task 2.2:- Create a Class Representing a Bank Account with Deposit and Withdrawal Methods
class BankAccount
{
    private long accountNumber;
    private double balance;

    //Constructor for initializing variable
    public  BankAccount(long AccountNumber , double Balance)

    {
        this.accountNumber = AccountNumber;
        if (balance >= 0)
        {
            this.balance = Balance;
        }
        else
        {
            Console.WriteLine("Balance cannot be negative. Set Balance to 0");
            this.balance=0;

        }
        
        



    }
    //Deposit method
    public void Deposit(double amount)
    {
        if (amount >= 0)
        {
            balance += amount;
            Console.WriteLine($"\nSuccessfully deposited: {amount:F2}");
            Console.WriteLine($"Current Balance: {balance:F2}");
        }
        else {
            Console.WriteLine("The amount for deposit must be positive!");
        }
         
    }
    //Withdrawal method
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount<=balance)
        {
            balance -= amount;
            Console.WriteLine($"\nSuccessfully withdrawal: {amount:F2}");
            Console.WriteLine($"Current Balance: {balance:F2}");

        }
        else if(amount < 0) 
        {
            Console.WriteLine("Withdrawal failed: The amount must be positive.");
        }
        else if(amount > balance)
            {
                Console.WriteLine("Withdrawal failed: Insufficient Balance!!");
           
            }
        


    }
    //Display Details
    public void DisplayAccountDetails()
    {
        Console.WriteLine($"\nThe AccountNumber is: {accountNumber}");
        Console.WriteLine($"The Current Balance is: {balance}");

    }

}

namespace Module_2
{
    class Module__2
    {
        //Task 1.1-Methods

         static  void Greet(string name)
        {
            Console.WriteLine($"Hello {name}, Welcome to C# module 2 programming!!\n");
          
        }

        //Task 1.2-Method Parameters
        

        static int CalculateArea(int length,int width )
        {
            return length * width;
        }

        //Task 1.3-Method Overloading
        static int Sum(int a,int b)
        {
            return a + b;
        }
        static int Sum(int a, int b,int c)
        {
            return a + b + c;
        }
        static double Sum(double a, double b)
        {
            return a + b;
        }
        static void Main()
        {

            //Greeting Message – Create a method GreetUser() that takes a name as input and prints a greeting message.

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Greet(userName);

            //Calculate Area of a Rectangle – Create a method CalculateArea(int length, int width) that takes two parameters and returns the area of a rectangle.

            Console.Write("Enter the length of rectangle: ");
            int length= Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the width of rectangle: ");
            int width = Convert.ToInt32(Console.ReadLine());

            long rectangleArea= CalculateArea(length,width);
            Console.WriteLine($"The area of the rectangle is: {rectangleArea}\n");


            //Sum of Numbers – Create an overloaded method Sum() that calculates the sum of:
            //Two integers
            //Three integers
            //Two double values

            Console.WriteLine($"The sum of 5 and 8 is: {Sum(5,8)}");
            Console.WriteLine($"The sum of 4 ,2 and 6 is: {Sum(4,2,6)}");
            Console.WriteLine($"The sum of 5.66 and 8.78 is: {Sum(5.66,8.78)}\n");



            //Define a BankAccount class with private fields(accountNumber, balance).
            //Implement a constructor to initialize the account.
            //Create Deposit and Withdraw methods with balance validation
            //Display account details after each transaction.
            //Add input handling to test the class with user-defined values.


            Console.Write("Enter Account Number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Initial Balance: ");
            double initialbalance;

            while(!double.TryParse(Console.ReadLine(), out initialbalance))
            {
                Console.WriteLine("Invalid input. Please enter a valid number");
                Console.Write("Enter InitialBalance: ");
               
                
            }
            Console.WriteLine('\n');
            BankAccount account = new BankAccount(accountNumber, initialbalance);

            bool flag = true;
            while (flag) {
                Console.WriteLine("\n What would you like to do?");
                Console.WriteLine("1. Deposit an amount? ");
                Console.WriteLine("2. Withdrawal an amount? ");
                Console.WriteLine("3. Display an bank balance? ");
                Console.WriteLine("4. Want to Exit!\n");
                Console.Write("Enter the choice: ");
                

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a deposit amount: ");
                        double depositAmount;
                        while(!double.TryParse(Console.ReadLine(),out depositAmount))
                        {
                            Console.WriteLine("Invalid amount! Please try again");
                            Console.Write("Enter a deposit amount: ");

                        }
                        account.Deposit(depositAmount);
                        break;

                    case 2:
                        Console.Write("Enter a withdrawal amount: ");
                        double WithdrawalAmount;
                        while (!double.TryParse(Console.ReadLine(), out WithdrawalAmount))
                        {
                            Console.WriteLine("Invalid amount! Please try again");
                            Console.Write("Enter a withdrawal amount: ");

                        }
                        account.Withdraw(WithdrawalAmount);
                        break;

                    case 3:
                        Console.WriteLine("Account details of the user: ");
                       
                        account.DisplayAccountDetails();
                        break;

                    case 4:
                        flag = false;
                        Console.WriteLine("\nExit,Thank you for using the bank account! Have a nice day");
                        break;


                    default:
                  
                        Console.WriteLine("Invalid choice, Please try again!\n");
                        break;



                }




            }
            



















        }






    }
}
