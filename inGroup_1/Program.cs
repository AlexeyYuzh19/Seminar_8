/*
Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
*/

Console.Clear();

// Методы

int[,] FillArray(int m, int n)
{
    int[,] arr = new int[m, n];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(0, 10);
        }
    }
    return arr;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            System.Console.Write(arr[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

// Код задачи

const int M = 6;
const int N = 5;

int[] arr = new int[10];

int[,] myArray = FillArray(M, N);

PrintArray(myArray);

for (int i = 0; i < myArray.GetLength(0); i++)
{
    for (int j = 0; j < myArray.GetLength(1); j++)
    {
        arr[myArray[i, j]] += 1;
    }
}

for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] != 0)
    {
        System.Console.WriteLine($"Значение {i} встречается {arr[i]} раз");
    }
}

