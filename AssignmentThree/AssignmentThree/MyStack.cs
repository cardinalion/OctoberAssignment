using System;
using System.Collections.Generic;

namespace AssignmentThree
{
    class MyStack<T>
    {
        private LinkedList<T> Stack;
        public MyStack()
        {
            Stack = new LinkedList<T>();
        }

        public int Count()
        {
            return Stack.Count;
        }

        public T Pop()
        {
            T elem = Stack.Last.Value;
            Stack.RemoveLast();
            return elem;
        }

        public void Push(T elem)
        {
            Stack.AddLast(elem);
        }
    }
}
