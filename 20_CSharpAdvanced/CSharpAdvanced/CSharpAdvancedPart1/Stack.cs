using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedPart1
{
    public class MyStack<T>
    {
        static readonly int MAX = 1000;
        int top;
        T[] stack = new T[MAX];

        bool IsEmpty()
        {
            return (top < 0);
        }
        public MyStack()
        {
            top = -1;
        }
        internal bool Push(T data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stack[++top] = data;
                return true;
            }
        }

        internal T Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                throw new Exception();
            }
            else
            {
                T value = stack[top--];
                return value;
            }
        }

        internal void Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
                Console.WriteLine("The topmost element of Stack is : {0}", stack[top]);
        }

        internal void PrintStack()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the Stack are :");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(stack[i]);
                }
            }
        }
    }

}
