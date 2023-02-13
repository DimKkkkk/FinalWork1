Console.Clear();

Console.Write("Введите количество элементов в массиве: ");
uint N = SizeArray();

string[] array = GetArray(N);
Console.WriteLine();

PrintArray(array);
Console.Write(" -> ");
PrintArray(CheckArray(array));


uint SizeArray() // задаём размер массива. применяем тип uint чтобы не было отрицательных чисел от пользователя
{
    while(true)
    {
        bool isCorrect = uint.TryParse(Console.ReadLine(), out uint num);
        if (isCorrect) return num;
        else Console.WriteLine("Ошибка ввода!");
    }
}

string[] GetArray(uint n) // заполняем массив вручную
{
    string[] result = new string[n];
    for(int i = 0; i < n; i++)
    {
        result[i] = Console.ReadLine() ?? "";
    }
    return result;
}

string[] CheckArray(string[] array) // делаем проверку нашего массива и на основе него создаём новый
{
    int count = 0;  // счётчик для подсчёта количества элементов, которые <= 3, чтобы в новом массиве не было пустых элементов
    int index =0; // счётчик индексов элементов в новом массиве
    for (int i = 0; i < array.Length; i++) // прогоняем весь наш массив с проверкой количества символов в элементе
    {
        if (array[i].Length <= 3)                 
            count++; // если условие выполняется, то счётчик увеличивается на 1.
    }
    string[] newArray = new string[count]; // новому массива присваиваем его длину, которую получили ранее и присвоили в count
    for (int j = 0; j < array.Length; j++) // снова проходим наш первоначальный массива
    {
        if (array[j].Length <= 3) // проверяем длину элемента
        {
            newArray[index] = array[j]; // удовлетворяющий нас заносим в новый массив
            index++; // переходим на следующий индекс
        }
    }
    return newArray; // возвращаем наш элемент в новый массив строка 42
}

void PrintArray(string[] arr) // выводим на экран массив
{   
    string str = "\"";
    Console.Write("[");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"{str}{arr[i]}{str}");
        if (i < arr.Length-1) Console.Write(", ");
    }
    Console.Write("]");    
}