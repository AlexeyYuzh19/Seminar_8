/*
Треугольник Паскаля в виде "новогодней ёлки"
В математике треугольник Паскаля является треугольным массивом из биномиальных коэффициентов. 
Он назван в честь французского математика Блеза Паскаля.
Основная формула Строки треугольника обычно нумеруются, начиная со строки n = 0 в верхней части. 
Записи в каждой строке целочисленные и нумеруются слева, начиная с k = 0, обычно располагаются в шахматном порядке 
относительно чисел в соседних строчках. Построить фигуру можно следующим образом: 
В центре верхней части листа ставится цифра "1". 
В следующем ряду — две единицы слева и справа от центра (получается треугольная форма). 
В каждой последующей строке ряд будет начинаться и заканчиваться числом "1". 
Внутренние члены вычисляются путём суммирования двух цифр над ним. 
Запись в n строке и k столбце паскалевской фигуры обозначается (n k). 
Например, уникальная ненулевая запись в самой верхней строке (0 0) = 1. 
С помощью этого конструкция предыдущего абзаца может быть записана следующим образом, 
образуя формулу треугольника Паскаля (n k) = (n - 1 k-1) + (n - 1 k), для любого неотрицательного целого числа n 
и любого целого числа k от 0 до n включительно. 
Трёхмерная версия называется пирамидой или тетраэдром, а общие — симплексами.
*/

// М Е Т О Д Ы

void OutputDynamicString(string text)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    for (int i = 0; i < text.Length; i++)
    {
        Thread.Sleep(1000 / text.Length);
        Console.Write(text[i]);
        if (!OperatingSystem.IsMacOS()) Console.Beep(Random.Shared.Next(37, 32767), 100);
    }
    Console.ResetColor();
}

int ReadNumber(string prompt, Predicate<int> condition, string errorMessage)
{
    int result;
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out result) && condition(result))
            break;
        Console.WriteLine(errorMessage);
    }
    return result;
}

int Input(string err_msg, string msg, bool DEBUG)
{
    return ReadNumber(msg, x => x > 0, err_msg);
}

uint[] CreateArrayUint(int N)
{
    return new uint[N];
}

void PrefillArray(uint[] array, int interval, bool DEBUG)
{
    if (DEBUG) Console.WriteLine("PrefillArray fill");
    int size0 = array.Length, locOfset = size0 / 2;
    for (int i = 0; i < size0; i++)
    {
        array[i] = 0;
    }
    array[locOfset] = 1;
    if (DEBUG) Console.WriteLine($"Отступ = locOfset * interval = {locOfset * interval}");
}

string ConcatLocal(string msg, int repeater, bool DEBUG)
{
    if (repeater > 0)
    {
        return string.Concat(Enumerable.Repeat(msg, repeater));
    }
    else
    {
        return "repeater < 0 Alarm!\n";
    }
}

void ChangeForegroundColor(int colorNumber)
{
    switch (colorNumber)
    {
        case 0:
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case 1:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Cyan;
            break;
        case 4:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            break;
        case 6:
            Console.ForegroundColor = ConsoleColor.DarkGray;
            break;
        case 7:
            Console.ForegroundColor = ConsoleColor.Magenta;
            break;
        case 8:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case 9:
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}

string FillPascalTriangle(uint[] array, int interval, int curr_line_number, bool DEBUG)
{
    string output = String.Empty;
    int size0 = array.Length, digInNumber;

    int locOffset = size0 / 2 - curr_line_number + 2;

    for (int i = size0 - 1; i <= 1; i--)
    {
        array[i] = array[i - 1];
    }
    array[0] = 0;

    string intervalOfsetString = ConcatLocal(" ", interval / 2, DEBUG);
    string even_ofset = ConcatLocal(intervalOfsetString, locOffset, DEBUG) + ConcatLocal(" ", interval / 2, DEBUG);
    string odd_ofset = ConcatLocal(intervalOfsetString, locOffset + 1, DEBUG);
    output = (curr_line_number % 2 == 0) ? even_ofset : odd_ofset;
    Console.Write(output);
    if (DEBUG)
    {
        Console.Write($"curr_line_number = {curr_line_number} ");
        Console.Write($"even_ofset = {even_ofset.Length} ");
        Console.Write($"odd_ofset = {odd_ofset.Length} ");
        Console.Write((curr_line_number % 2 == 0) ? "use even_ofset " : "use odd_ofset ");
        Console.Write($"locOffset {locOffset} ");
        Console.WriteLine($"output.Length {output.Length} ");
    }

    for (int i = locOffset + 1; i < size0 / 2 + 1; i++)
    {
        array[i] += array[i + 1];
        digInNumber = array[i].ToString().Length;
        if (DEBUG) Console.WriteLine($"digInNumber = {digInNumber} ");
        ChangeForegroundColor((int)array[i] % 10);
        Console.Write($"{ConcatLocal(" ", interval - digInNumber, DEBUG)}{array[i]}");
        //Console.Write($"{ConcatLocal(" ", interval - digInNumber, DEBUG)} *");         // - можно звездочки вместо цифр вывести
        Console.ResetColor();
    }
    return output;
}

void PascalTriangle()
{
    bool DEBUG = false;

    int triangleHeight = Input("ошибка, введено не целое число", "введите высоту пирамиды от вершины в строках (целое число), например, 5: ", DEBUG), interval, triangleSize = triangleHeight * 2;

    uint[] array = CreateArrayUint(triangleSize + 4);

    interval = ((triangleSize + 4) - 5) / 3 + 1;

    PrefillArray(array, interval, DEBUG);

    for (int i = 0; i < array.Length / 2; i++)
    {
        string output = FillPascalTriangle(array, interval, i + 2, DEBUG);
        Console.WriteLine();
    }
    Console.WriteLine("\n\n\n");
}

// К О Д   З А Д А Ч И

Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkCyan;
System.Console.WriteLine("Построим треугольник Паскаля в цветном украшении :");

Console.ForegroundColor = ConsoleColor.DarkGreen;
PascalTriangle();
Console.ResetColor();
