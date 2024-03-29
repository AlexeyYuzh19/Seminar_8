﻿/*
Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается каждый элемент входных данных.
*/

Console.Clear();

// Методы

int CheckInputNumber(string Text)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    int number;
    string text;

    while (true)
    {
        Console.Write(Text);
        text = Console.ReadLine();

        if (int.TryParse(text, out number)) break;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Заданное значение числа не соответствует критерию, попробуйте еще раз.");
        Console.ResetColor();
    }
    Console.ResetColor();
    return number;
}

int CheckSize(string text)
{
metka:
    int size = CheckInputNumber(text);

    if (size < 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");
        goto metka;
    }
    if (size == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");
        goto metka;
    }
    Console.ResetColor();
    return size;
}

void EnterArrayParameter(out int lines, out int columns, out int leftRange, out int rightRange)
{
    lines = CheckSize("Введите количество строк матрицы : ");

    columns = CheckSize("Введите количество столбцов матрицы : ");

metka:
    leftRange = CheckInputNumber("Введите величину левого значения (края) матрицы : ");

    rightRange = CheckInputNumber("Введите величину правого значения (края) матрицы : ");

    if (leftRange == rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Значения левого и правого края матриц равны, попробуйте еще раз.");
        goto metka;
    }
    if (leftRange > rightRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Заданное значение левого края матриц больше правого, попробуйте еще раз.");
        goto metka;
    }
    Console.ResetColor();
}

int[,] MakeArray(int lines, int columns, int leftRange, int rightRange)
{
    int[,] array = new int[lines, columns];
    Random rand = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rand.Next(leftRange, rightRange);
        }
    }
    return array;
}

void PrintArray2D(int[,] array)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"\nдвумерный массив размером | {array.GetLength(0)} х {array.GetLength(1)} | :\n");

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            var ar = String.Format("{0,7}", array[i, j]);

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(ar);
            Console.ForegroundColor = ConsoleColor.DarkGray;

            if (j < array.GetLength(1) - 1) System.Console.Write(" | ");
        }
        System.Console.WriteLine();
    }
    Console.ResetColor();
}

int[] Convert2DArrayIn1DArray(int[,] array)
{
    int Len = array.GetLength(0) * array.GetLength(1);
    int[] arr = new int[Len];
    int k = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            arr[k] = array[i, j];
            k++;
        }
    }
    return arr;
}

void QuickSortHoare(int[] Array, int FerstIndex, int LastIndex)
{
    if (FerstIndex >= LastIndex)
    {
        return;
    }

    int SupportIndex = FerstIndex;

    for (int i = FerstIndex; i <= LastIndex; i++)
    {
        if (Array[i] < Array[LastIndex])
        {
            (Array[i], Array[SupportIndex]) = (Array[SupportIndex], Array[i]);
            SupportIndex += 1;
        }
    }

    (Array[LastIndex], Array[SupportIndex]) = (Array[SupportIndex], Array[LastIndex]);

    QuickSortHoare(Array, FerstIndex, SupportIndex - 1);
    QuickSortHoare(Array, SupportIndex + 1, LastIndex);
}

void PrintArray1D(int[] array, string text)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"\n {text} массив размером | {array.Length} | :\n");

    for (int i = 0; i < array.Length; i++)
    {
        var ar = String.Format("{0,2}", array[i]);

        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write(ar);
        Console.ForegroundColor = ConsoleColor.DarkGray;

        if (i < array.Length - 1) System.Console.Write(" | ");
    }
    Console.ResetColor();
    System.Console.WriteLine();
}

Dictionary<int, int> FrequencyDictionaryInArray(int[] array)
{
    var frequencyDictionary = new Dictionary<int, int>();
    int m = 0;
    int equality;
    int count = 0;

    while (m < array.Length)
    {
        equality = array[m];

        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] == equality)
            {
                count++;
                m = j + 1;
            }
        }
        frequencyDictionary.Add(equality, count);
        count = 0;
    }
    return frequencyDictionary;
}

void PrintFrequencyDictionary(Dictionary<int, int> FrequencyDictionary)
{
    System.Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    foreach (var record in FrequencyDictionary)
    {
        Console.WriteLine($"значение {String.Format("{0,4}", record.Key)}  встречается {String.Format("{0,4}", record.Value)} раз");
    }

    Console.ResetColor();
    System.Console.WriteLine();
}

// Код решения

EnterArrayParameter(out int lines, out int columns, out int leftRange, out int rightRange);

int[,] myArray = MakeArray(lines, columns, leftRange, rightRange);

PrintArray2D(myArray);

int[] arr = Convert2DArrayIn1DArray(myArray);

PrintArray1D(arr, "конвертированный исходный");

QuickSortHoare(arr, 0, arr.Length - 1);

PrintArray1D(arr, "отсортированный по возрастанию");

PrintFrequencyDictionary(FrequencyDictionaryInArray(arr));
