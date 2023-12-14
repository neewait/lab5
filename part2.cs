using System;
using System.Collections;
using System.Runtime.CompilerServices;

class MyList<T> : IEnumerable<T>
{
    private T[] list;
    private int count;

    public MyList()
    {
        list = new T[0];
        count = 0;
    }
    
    public void Add(T item)
    {
        Array.Resize(ref list, count + 1);
        list[count] = item;
        count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.ToList().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return list.GetEnumerator();
    }

    public T this[int index]
    {
        get { return list[index]; }
    }    

    public int Count
    {
        get { return count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>() { 1, 2, 3, 4, 5 };

        Console.WriteLine("Элементы списка:");

        for (int i = 0; i < myList.Count; i++) // Итерируемся по элементам списка
        {
            Console.WriteLine(myList[i]); // Получаем значение элемента по индексу
        }

        MyList<string> myStringList = new MyList<string>();

        myStringList.Add("Hello");
        myStringList.Add("World");

        Console.WriteLine("Строки списка:");

        for (int i = 0; i < myStringList.Count; i++)
        {
            Console.WriteLine(myStringList[i]);
        }
    }
}



