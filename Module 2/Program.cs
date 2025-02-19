//Task 1-Methods, Method Parameters, Method Overloading

using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Transactions;
using System;
using Microsoft.VisualBasic;

//Task 2.2:- Create a Class Representing a Bank Account with Deposit and Withdrawal Methods
class BankAccount
{
    private long accountNumber;
    private double balance;
    private string accountHolderName;
    private int age;

    //Constructor for initializing variable
    public  BankAccount(long AccountNumber , double Balance,string accountHolderName, int age)

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
        this.accountHolderName = accountHolderName;
        this.age = age;
        
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
    public virtual void Withdraw(double amount)
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
    public virtual void DisplayAccountDetails()
    {
        Console.WriteLine($"\nThe Account Number is: {accountNumber}");
        Console.WriteLine($"The Current Balance is: {balance}");

    }

    public double GetBalance => balance;
    public double GetAccountNumber => accountNumber;
    public string AccountHolderName => accountHolderName;
    public double GetAge => age;



}
//Extend the Bank Account Class to Include Different Account Types
class SavingsAccount : BankAccount
{
    const double minimumBalance = 500;
    const double interestRate = 0.03;
    public SavingsAccount(long accountNumber,double balance,string accountHolderName, int age) : base(accountNumber, balance,accountHolderName,age)
    {

    }
    public override void Withdraw(double amount)
    {
        if (GetBalance - amount < minimumBalance)
        {
            Console.WriteLine($"\nWithdrawal failed: To proceed, you must maintain a minimum balance of 500. Your current balance is {GetBalance}.");
        }
        else
        {
            base.Withdraw(amount);
        }
    }
    public void CalculateInterest()
    {
        double interest = GetBalance * interestRate;
        Deposit(interest);
        Console.WriteLine($"\nInterest of {interest:F2} has been added to your account!");
    }
    public override void DisplayAccountDetails()
        
    {  
        Console.WriteLine("\nAccount details and Account type : Savings ");
        base.DisplayAccountDetails();
    }
}
class CurrentAccount : BankAccount
{
    const double draftLimit = 1000;
    public CurrentAccount(long AccountNumber, double balance, string accountHolderName, int age) : base(AccountNumber, balance, accountHolderName, age)
    {

    }

    public override void Withdraw(double amount)
    {
        if (GetBalance - amount < draftLimit)
        {
            Console.WriteLine($"\nWithdrawal failed: To proceed, you must maintain a minimum balance of 500. Your current balance is {GetBalance}.");
        }
        else
        {
            base.Withdraw(amount);
        }
    }
    public override void DisplayAccountDetails()

    {
        Console.WriteLine("\nAccount details and Account type : Current");
        base.DisplayAccountDetails();
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

      
            bool taskRunning = true;
            while (taskRunning) {
                Console.WriteLine("Choose a task to start:");
                Console.WriteLine("1. Task 1: Methods, Method Parameters, Method Overloading");
                Console.WriteLine("2. Task 2 and 3: Bank Account (Deposit, Withdrawal, Savings, and Current Accounts)");
                Console.WriteLine("3. Do you want to exit from tasks?");
                Console.Write("\nEnter the task Choice: ");
                int taskChoice;
              
                while (!int.TryParse(Console.ReadLine(), out taskChoice))
                {
                    Console.WriteLine("\nInvalid choice!!Please enter 1 for Task 1 or 2 for Task 2 or 3 for exit.");
                }
                //Greeting Message – Create a method GreetUser() that takes a name as input and prints a greeting message.

                if (taskChoice==1)
                {
                    Console.WriteLine("\nTask 1: ");
                    Console.Write("\nEnter your name: ");
                    string userName = Console.ReadLine();
                    Greet(userName);

                    //Calculate Area of a Rectangle – Create a method CalculateArea(int length, int width) that takes two parameters and returns the area of a rectangle.

                    Console.Write("Enter the length of rectangle: ");
                    int length = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the width of rectangle: ");
                    int width = Convert.ToInt32(Console.ReadLine());

                    long rectangleArea = CalculateArea(length, width);
                    Console.WriteLine($"The area of the rectangle is: {rectangleArea}\n");


                    //Sum of Numbers – Create an overloaded method Sum() that calculates the sum of:
                    //Two integers
                    //Three integers
                    //Two double values
                    Console.WriteLine("Method overloading to calculate the Sum(): ");
                    Console.WriteLine($"The sum of 5 and 8 is: {Sum(5, 8)}");
                    Console.WriteLine($"The sum of 4 ,2 and 6 is: {Sum(4, 2, 6)}");
                    Console.WriteLine($"The sum of 5.66 and 8.78 is: {Sum(5.66, 8.78)}\n");
                }
                if (taskChoice == 2)
                {
                    //Define a BankAccount class with private fields(accountNumber, balance).
                    //Implement a constructor to initialize the account.
                    //Create Deposit and Withdraw methods with balance validation
                    //Display account details after each transaction.
                    //Add input handling to test the class with user-defined values.


                    //Create a SavingsAccount and CurrentAccount class that inherit from BankAccount.
                    //Override the Withdraw method to enforce different rules(e.g., minimum balance for savings).
                    // Add an interest calculation method in SavingsAccount.
                    //Implement polymorphism by handling different account types through a base class reference.
                    //Test the extended functionality with multiple account instances.

                    Console.WriteLine("\nTask 2 & 3:: ");

                    bool start = true;
                    while (start)
                    {
                        Console.WriteLine("\nChoose an option:");
                        Console.WriteLine("1. Log in to an existing account");
                        Console.WriteLine("2. Create a new account");
                        Console.WriteLine("3. List of all accounts");

                        Console.WriteLine("4. Exit");
                        Console.Write("\nEnter your choice: ");

                        int choice;
                        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                        {
                            Console.WriteLine("Invalid choice! Please enter 1, 2, 3 or 4.");
                        }

                        switch (choice)
                        {
                            case 1:
                                LoginAccount();
                                break;
                            case 2:
                                CreateAccount();
                                break;
                            case 3:
                                ShowAllAccounts();
                                break;
                          
                            case 4:
                                start = false;
                                Console.WriteLine("Exiting. Thank you for using the banking system!");
                                break;
                        }

                    }

                }
                if (taskChoice == 3)
                {   
                    Console.WriteLine("Exiting! Thankyou for using the program.");
                    taskRunning = false;

                }
                

            }
                

      }
         const string FilePath = "accounts.txt";
        static void LoginAccount()
        {
            Console.Write("Enter your account number: ");
            long accountNumber;

            while (!long.TryParse(Console.ReadLine(), out accountNumber) || accountNumber.ToString().Length != 11)
            {
                Console.WriteLine("Invalid account number! Please enter exactly 11 digits.");
                Console.Write("Enter your account number again: ");

            }


            if (File.Exists(FilePath))
            {
                string[] accounts = File.ReadAllLines(FilePath);
                for (int i = 0; i < accounts.Length; i++)
                {
                    string[] details = accounts[i].Split(',');

                    if (long.Parse(details[0]) == accountNumber)
                    {
                        string accountHolderName = details[1];
                        Console.WriteLine($"You have logged in {accountHolderName}!");
                        Console.WriteLine("\nAccount found!");

                        string accountType = details[4];
                        double balance = double.Parse(details[3]);
                
                        int age = int.Parse(details[2]);

                        BankAccount account = accountType == "Savings" ?
                            new SavingsAccount(accountNumber, balance,accountHolderName,age) : new CurrentAccount(accountNumber, balance,accountHolderName,age);

                        // Perform operations
                        while (true)
                        {
                            Console.WriteLine("\nChoose an operation:");
                            Console.WriteLine("1. Check Balance");
                            Console.WriteLine("2. Deposit");
                            Console.WriteLine("3. Withdraw");
                            Console.WriteLine("4. Logout");
                            Console.Write("Enter the choice: ");

                            int choice;
                            if (!int.TryParse(Console.ReadLine(), out choice))
                            {
                                Console.WriteLine("Invalid choice! Try again.");
                                continue;
                            }

                            if (choice == 1)
                            {
                                Console.WriteLine($"Your current balance is: {account.GetBalance}");
                            }
                            else if (choice == 2)
                            {
                                Console.Write("Enter amount to deposit: ");
                                double depositAmount;
                                if (double.TryParse(Console.ReadLine(), out depositAmount))
                                {
                                    account.Deposit(depositAmount);
                                    Console.WriteLine($"Amount deposited successfully! New balance: {account.GetBalance}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount!");
                                }
                            }
                            else if (choice == 3)
                            {
                                Console.Write("Enter amount to withdraw: ");
                                double withdrawAmount;
                                if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                                {
                                    
                                    account.Withdraw(withdrawAmount);
                                    Console.WriteLine($"Amount withdrawn successfully! New balance: {account.GetBalance}");
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount!");
                                }
                            }
                            else if (choice == 4)
                            {
                                // Update the account in the file
                                accounts[i] = $"{account.GetAccountNumber},{account.AccountHolderName},{account.GetAge},{account.GetBalance},{accountType}";
                                File.WriteAllLines(FilePath, accounts);

                                Console.WriteLine("Logged out successfully!");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice! Try again.");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nAccount not found! Please create a new account.");
        }

        static void CreateAccount()
        {
            Console.WriteLine("\nChoose Account Type: ");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.Write("\nEnter your account choice: ");

            int accountChoice;
            while (!int.TryParse(Console.ReadLine(), out accountChoice) || (accountChoice != 1 && accountChoice != 2))
            {
                Console.WriteLine("Invalid choice!!Please enter 1 for Savings account or 2 for Current Account choice.");
            }

            //Console.Write("Enter Account Number: ");
            //long accountNumber = Convert.ToInt64(Console.ReadLine());
            Random random = new Random();
            long accountNumber = random.NextInt64(10000000000, 100000000000); // Inclusive of 11 digits
            Console.WriteLine($"The Account Number is: {accountNumber}");



            Console.Write("Enter Initial Balance: ");
            double initialBalance;

            while (!double.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.WriteLine("Invalid input. Please enter a valid number");
                Console.Write("Enter InitialBalance: ");


            }

            Console.Write("Enter your name: ");
            string accountHolderName = Console.ReadLine();

            // Validate name input
            while (string.IsNullOrWhiteSpace(accountHolderName))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                Console.Write("Enter your name: ");
                accountHolderName = Console.ReadLine();
            }

            int age;
            Console.Write("Enter your age: ");

            // Validate age input
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0 || age > 120)
            {
                Console.WriteLine("Please enter a valid age: ");
                Console.Write("Enter your age: ");
            }

            Console.WriteLine($"Hello {accountHolderName}, you are {age} years old!");

            Console.WriteLine('\n');

            string accountType = accountChoice == 1 ? "Savings" : "Current";
            BankAccount newAccount = accountChoice == 1 ?
                new SavingsAccount(accountNumber, initialBalance,accountHolderName,age) : new CurrentAccount(accountNumber, initialBalance,accountHolderName,age);

            // Save account details to file
            string accountDetails = $"{accountNumber},{accountHolderName},{age},{newAccount.GetBalance},{accountType}";
            File.AppendAllText(FilePath, accountDetails + Environment.NewLine);

            Console.WriteLine("\nAccount created successfully!");
            PerformBankOperations(newAccount);

        }
         static void PerformBankOperations(BankAccount account)
        {
            string[] accounts = File.ReadAllLines(FilePath); // Load all accounts
            bool flag = true;
            while (flag)
            {
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
                        while (!double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Console.WriteLine("Invalid amount! Please try again.");
                            Console.Write("Enter a deposit amount: ");

                        }
                        account.Deposit(depositAmount);
                        break;

                    case 2:
                        Console.Write("Enter a withdrawal amount: ");
                        double WithdrawalAmount;
                        while (!double.TryParse(Console.ReadLine(), out WithdrawalAmount))
                        {
                            Console.WriteLine("Invalid amount! Please try again.");
                            Console.Write("Enter a withdrawal amount: ");

                        }
                        account.Withdraw(WithdrawalAmount);
                        break;

                    case 3:
                        //Console.WriteLine("Account details of the user: ");
                        account.DisplayAccountDetails();
                        if (account is SavingsAccount savingsAccount)
                        {
                            savingsAccount.CalculateInterest();
                        }
                        break;


                    case 4:
                        flag = false;
                        Console.WriteLine("\nExit,Thank you for using the bank account! Have a nice day.");
                        break;


                    default:
                        Console.WriteLine("Invalid choice , Please try again!\n");
                        break;
                }
                UpdateAccountFile(accounts, account);

            }
         }
        static void UpdateAccountFile(string[] accounts, BankAccount account)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                string[] details = accounts[i].Split(',');
                if (long.Parse(details[0]) == account.GetAccountNumber)
                {
                    // Update balance
                    accounts[i] = $"{account.GetAccountNumber},{account.AccountHolderName},{account.GetAge},{account.GetBalance},{details[4]}";
                    break;
                }
            }

            // Write back updated data to the file
            File.WriteAllLines(FilePath, accounts);
        }

        static void ShowAllAccounts() {
            // Check if the file exists
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("No accounts found. File does not exist.");
                return;
            }

            // Read all lines from the file
            string[] accounts = File.ReadAllLines(FilePath);

            Console.WriteLine("Displaying all account details in table format:");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-20} {2,-5} {3,-10} {4,-10}",
                              "Account Number", "Name", "Age", "Balance", "Account Type");
            Console.WriteLine("----------------------------------------------------------");

            foreach (string account in accounts)
            {
                // Split each line into account details
                string[] details = account.Split(',');

              
                if (details.Length == 5)
                {
                    string accountNumber = details[0];
                    string name = details[1];
                    string age = details[2];
                    string balance = details[3];
                    string accountType = details[4];

                    // Print account details in a tabular format
                    Console.WriteLine("{0,-15} {1,-20} {2,-5} {3,-10} {4,-10}",
                                      accountNumber, name, age, balance, accountType);
                }
                else
                {
                    Console.WriteLine("Error: Account details are not in the correct format.");
                }
            }

            Console.WriteLine("----------------------------------------------------------");

        }



    }

}

