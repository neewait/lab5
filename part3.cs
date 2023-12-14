using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace lab5
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();

            myDictionary[1] = "Value 1";
            myDictionary[2] = "Value 2";
            myDictionary[3] = "Value 3";

            string value = myDictionary[2];
            Console.WriteLine("Значение элемента по ключу 2: " + value);


            int size = myDictionary.Size;
            Console.WriteLine("Общее количество элементов: " + size);

            foreach (KeyValuePair<int, string> pair in myDictionary)
            {
                Console.WriteLine("Ключ: " + pair.Key + ", Значение: " + pair.Value);
            }
        }
    }


    public class MyDictionary<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        private int size;

        public MyDictionary()
        {
            keys = new TKey[0];
            values = new TValue[0];
            size = 0;
        }

        public void Add(TKey key, TValue value)
        {
            Array.Resize(ref keys, size + 1);
            Array.Resize(ref values, size + 1);
            keys[size] = key;
            values[size] = value;
            ++size;
        }

        public TValue this[TKey key]
        {
            get
            {
                int index = Array.IndexOf(keys, key);
                if (index == -1)
                {
                    throw new KeyNotFoundException();
                }

                return values[index];
            }
            set
            {
                int index = Array.IndexOf(keys, key);
                if (index == -1)
                {
                    Add(key, value);
                }
                else
                {
                    values[index] = value;
                }
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < size; ++i)
            {
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
            }
        }
    }
}
