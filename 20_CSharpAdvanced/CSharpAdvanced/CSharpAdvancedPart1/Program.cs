using System;

namespace CSharpAdvancedPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> myStack= new MyStack<string>();
            myStack.Push("John");
            myStack.Push("Ann");
            myStack.Push("Dean");

            myStack.PrintStack();
            Console.ReadLine();
        }
    }
}