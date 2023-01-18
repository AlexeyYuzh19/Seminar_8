/*
Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3

Делаем ввод массива с консоли - с окончанием вода по кодовому слову + печать заданного массива.
*/

// М Е Т О Д Ы

int[] EnterArray(string action, string errorAction)
{
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine("Задайте одномерный массив из целых чисел - по окончании ввода наберите кодовое слово < stop >.");

    int EnNum;
    string text;
    List<int> EnArray = new List<int>();

    do
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(action);
            text = Console.ReadLine();

            if (int.TryParse(text, out EnNum))
            {
                EnArray.Add(EnNum);
                break;
            }
            if (text == "stop")
            {
                Console.ResetColor();
                break;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorAction);
            Console.ResetColor();
        }
    }
    while (text != "stop");

    int[] Array = new int[EnArray.Count];
    EnArray.CopyTo(Array);
    Console.ResetColor();
    return Array;
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

void NumMoreNull(int[] array, out int Numbers, out int arL)
{
    Numbers = 0;
    arL = array.Length;

    System.Console.WriteLine("\nОтрицательные и нулевые значения со значениями больше нуля разделены цветами :\n");

    foreach (int ari in array)
    {
        if (ari > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {ari}");
            Console.ResetColor();
            System.Console.Write(" | ");
            Numbers++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write($" {ari}");
            //System.Console.Write(ari);
            Console.ResetColor();
            System.Console.Write(" | ");
        }
    }
}

// К О Д   

Console.Clear();

int[] Arr = EnterArray("Введите число : ", "Задано не целое число, повторите ввод.");

if (Arr.Length == 0)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine("Массив не задан.");
    Console.ResetColor();
}
else PrintArray1D(Arr, "Из чисел сформирован одномерный");

NumMoreNull(Arr, out int Numbers, out int arL);

Console.ForegroundColor = ConsoleColor.DarkRed;
System.Console.WriteLine($"\n\nИз {arL} чисел количество значений больше нуля = {Numbers}\n");
Console.ResetColor();
