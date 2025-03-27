// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        
        //1. First Question: Reverse Numbers
        // int[] numbers = GenerateNumbers(10);
        // Reverse(numbers);
        // PrintNumbers(numbers);
        
        // 2. Second Question: Fibonacci Series

        // int number = int.Parse(Console.ReadLine());
        // Fibonacci(number);
    }

    static int[] GenerateNumbers(int num)
    {
        int[] numbers = new int[num];
        for (int i = 0; i < num; i++)
        {
            numbers[i] = i;
        }
        return numbers;
    }

    static void Reverse(int[] numbers)
    {
        int a = 0;
        int b = numbers.Length - 1;

        while (a < b)
        {
            int temp = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = temp;
            a++;
            b--;
        }
    }

    static void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }


    static void Fibonacci(int n)
    {
        int a = 0;
        int b = 1;
        int next=0;
        for (int i = 1; i < n; i++)
        {
            if (i <= 1)
            {
                a = b;
            }
            else
            {
                next = a + b;
                a = b;
                b = next;
            }
        }
        Console.WriteLine(next);
    }
    
}