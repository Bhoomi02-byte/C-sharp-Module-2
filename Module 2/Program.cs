//Task 1-Methods, Method Parameters, Method Overloading

using System.Threading;

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

            int rectangleArea= CalculateArea(length,width);
            Console.WriteLine($"The area of the rectangle is: {rectangleArea}\n");


            //Sum of Numbers – Create an overloaded method Sum() that calculates the sum of:
            //Two integers
            //Three integers
            //Two double values

            Console.WriteLine($"The sum of 5 and 8 is: {Sum(5,8)}");
            Console.WriteLine($"The sum of 4 ,2 and 6 is: {Sum(4,2,6)}");
            Console.WriteLine($"The sum of 5.66 and 8.78 is: {Sum(5.66,8.78)}\n");










        }





    }
}
