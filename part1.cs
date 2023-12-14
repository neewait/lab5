using System;
using System.Collections;
using System.Runtime.CompilerServices;

class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private int minValue;
    private int maxValue;

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        this.rows = rows;
        this.columns = columns;
        this.minValue = minValue;
        this.maxValue = maxValue;
        matrix = new int[rows, columns];
        Fill();
    }

    public void Fill()
    {
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns)
    {
        int[,] newMatrix = new int[newRows, newColumns];
        int copyRows = Math.Min(newRows, rows);
        int copyColumns = Math.Min(newColumns, columns);

        for (int i = 0; i < copyRows; i++)
        {
            for (int j = 0; j < copyColumns; j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        if (newRows > rows || newColumns > columns)
        {
            Random random = new Random();
            for (int i = copyRows; i < newRows; i++)
            {
                for (int j = copyColumns; j < newColumns; j++)
                {
                    newMatrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;
    }

    public void ShowPartialy(int startRow, int startColumn, int endRow, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество строк матрицы:");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int columns = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите минимальное значение для заполнения матрицы:");
        int minValue = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для заполнения матрицы:");
        int maxValue = Convert.ToInt32(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

        Console.WriteLine("Исходная матрица:");
        matrix.Show();

        Console.WriteLine("Введите новое количество строк для изменения размера матрицы:");
        int newRows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите новое количество столбцов для изменения размера матрицы:");
        int newColumns = Convert.ToInt32(Console.ReadLine());

        matrix.ChangeSize(newRows, newColumns);

        Console.WriteLine("Измененная матрица:");
        matrix.Show();

        Console.WriteLine("Введите начальное значение строки для вывода подматрицы:");
        int startRow = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите начальное значение столбца для вывода подматрицы:");
        int startColumn = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите конечное значение строки для вывода подматрицы:");
        int endRow = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите конечное значение столбца для вывода подматрицы:");
        int endColumn = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Подматрица:");
        matrix.ShowPartialy(startRow, startColumn, endRow, endColumn);

        Console.WriteLine("Введите значения индексов элемента матрицы, который хотите изменить:");
        int index1 = Convert.ToInt32(Console.ReadLine());
        int index2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите новое значение для элемента:");
        int newValue = Convert.ToInt32(Console.ReadLine());

        matrix[index1, index2] = newValue;

        Console.WriteLine("Измененная матрица:");
        matrix.Show();
    }
}

