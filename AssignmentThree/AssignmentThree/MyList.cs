using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentThree
{
    class MyList<T>
    {
        private T[] Arr;
        private int Count;
        private static int MINLENGTH = 100;

        public MyList()
        {
            Arr = new T[MINLENGTH];
            Count = 0;
        }

        private void ModifyLength()
        {
            if (Count * 3 / 2 > Arr.Length)
            {
                T[] newArr = new T[Arr.Length * 2];
                Array.Copy(Arr, newArr, Count);
                Arr = newArr;
            } else if (Arr.Length > MINLENGTH && Count * 4 < Arr.Length)
            {
                T[] newArr = new T[Math.Max(Arr.Length / 2, MINLENGTH)];
                Array.Copy(Arr, newArr, Count);
                Arr = newArr;
            }
        }

        public void Add(T element)
        {
            Arr[Count++] = element;
            ModifyLength();
        }

        public bool Contains(T element)
        {
            foreach (var e in Arr)
            {
                if (e.Equals(element)) return true;
            }
            return false;
        }

        public void Clear()
        {
            Arr = new T[100];
            Count = 0;
        }

        public void InsertAt(T element, int index)
        {
            if (index > Count)
            {
                Console.WriteLine("Index number to be inserted is larger than the list length");
                return;
            }
            for (int i = Count-1; i >= index; --i)
            {
                Arr[i + 1] = Arr[i];
            }
            Arr[index] = element;
            ++Count;
            ModifyLength();
        }

        public void DeleteAt(int index)
        {
            if (index > Count)
            {
                Console.WriteLine("Index number to be inserted is larger than the list length");
                return;
            }
            for (int i = index + 1; i < Count; ++i)
            {
                Arr[i - 1] = Arr[i];
            }
            Arr[Count] = Arr[Count+1];
            --Count;
            ModifyLength();
        }

        public T Find(int index)
        {
            return Arr[index];
        }
    }
}
