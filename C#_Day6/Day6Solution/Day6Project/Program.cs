﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Project
{
    class Program
    {
        public delegate void sample(int n1, int n2); //Creating a type for creating the reff
        sample myDel;//reff to the type
        
        Program()
        {
            myDel = new sample(Add);//instantiate the type
        }
        void Add(int num1,int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("The sum of {0} and {1} is {2}",num1,num2,sum);
            //return sum;
        }
        void Mul(int num1, int num2)
        {
            int sum = num1 * num2;
            Console.WriteLine("The product of {0} and {1} is {2}", num1, num2, sum);
            //return sum;
        }
        void AccessDelegate()
        {
            myDel += new sample(Mul);//made the delegate multicast
            myDel += delegate (int n1, int n2)//annon method
            {
                int res = n1 - n2;
                Console.WriteLine("The subtraction result is "+res);
                //return res;
            };
            myDel += (num1, num2) => Console.WriteLine("The result of division is "+(num1/num2));//lambda expression
            CallMethods(myDel);//passing the reff as parameter
        }
        void CallMethods(sample s)//receiving the reff as parameter
        {
            Console.WriteLine("I have the method as parameter");
            try
            {
                Console.WriteLine("Please enter the first number");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the second number");
                int num2 = Convert.ToInt32(Console.ReadLine());
                s(num1, num2);//call the deletegare which will call the methods
                //int res = s(num1, num2);//invoking the type
                //Console.WriteLine("from the return "+res);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Your input was not in right format");
            }
        }
        static void Main(string[] args)
        {
            new Program().AccessDelegate();
            Console.ReadKey();
        }
    }
}
