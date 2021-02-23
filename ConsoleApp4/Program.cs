using System;
using System.Linq;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter M: ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MIN: ");
            int MIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MAX: ");
            int MAX = Convert.ToInt32(Console.ReadLine());
            //var array = randomArray(N, MIN, MAX);
            var array = random2dArray(N, M, MIN, MAX);
            var array1 = new int[,] {{1, 2, 3}, {2, 3, 1}, {3, 1, 2}};
            //task1(N, array);
            //task2(N, array);
            //task4(N, array);
            //task6(N, array);
            //task2_2(N, M, array);
            task2_2(3,3, array1);
        }

        // Вивести спочатку факторіали парних, а потім числа які не діляться на 3.
        // Вивести суму чисел які повторються з парних.
        private static void task1(int N, int[] array)
        {
            int[] factArray = new int[N / 2];
            int[] evenArray = new int[N / 2];
            int[] not3Array = new int[N / 2];
            int oddResultIndex = 0;
            int factIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    factArray[factIndex] = fact(array[i]);
                    evenArray[factIndex] = array[i];
                    factIndex++;
                }
                else
                {
                    if (array[i] % 3 != 0)
                    {
                        not3Array[oddResultIndex] = array[i];
                        oddResultIndex++;
                    }
                }
            }

            int sum = 0;
            foreach (var el in evenArray)
            {
                int count = 0;
                foreach (var el2 in evenArray)
                {
                    if (el == el2)
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    sum += el;
                }
            }


            PrintArray(array);
            PrintArray(factArray);
            PrintArray(not3Array);
            Console.WriteLine(sum);
        }

        private static int[] randomArray(int N, int MIN, int MAX)
        {
            int[] array = new int[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(MIN, MAX);
            }

            PrintArray(array);
            return array;
        }

        private static int[,] random2dArray(int N, int M, int MIN, int MAX)
        {
            int[,] array = new int[N,M];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
             
                for (int j = 0; j < M; j++)
                {
                    array[i,j] = random.Next(MIN, MAX);
                }
   
            }
            PrintArray(array, N, M);
            return array;
        }

        private static int fact(int n)
        {
            return n == 1
                ? 1
                : n * fact(n - 1);
        }

        private static void PrintArray(int[] array)
        {
            foreach (var el in array)
            {
                Console.Write(el + ", ");
            }

            Console.WriteLine();
        }

        private static void PrintArray(int[,] array, int N, int M)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        //Поміняти місцями 1-й позитивний елемент з останнім позитивним елементом, 2-й – з передостаннім і т.д.
        //Вивести елементи масиву на екран. ПРИМІТКА. Вважати нуль позитивним числом.
        private static void task2(int N, int[] array)
        {
            int last = N - 1;
            for (int i = 0; i < last; i++)
            {
                if (array[i] >= 0)
                {
                    for (int j = last; j > i; j--)
                    {
                        if (array[j] >= 0)
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                            last = j - 1;
                            break;
                        }
                    }
                }
            }

            PrintArray(array);
        }


        //Знайти різницю чисел, що знаходяться між максимальним і мінімальним елементами масиву
        //(в різницю не включати максимальний та мінімальний елементи).
        //Вивести різницю на екран. ПРИМІТКА. Якщо в масиві є декілька елементів,
        //які відповідають мінімальному або максимальному значенню, то використовувати перші з них.
        public static void task4(int N, int[] array)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;

            int max_i = 0;
            int min_i = 0;
            for (int i = 0; i < N; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    max_i = i;
                }

                if (min > array[i])
                {
                    min = array[i];
                    min_i = i;
                }
            }

            int left_i = Math.Min(max_i, min_i);
            int right_i = Math.Max(max_i, min_i);

            int diff = array[left_i + 1];
            for (int i = left_i + 2; i < right_i; i++)
            {
                diff -= array[i];
            }

            Console.WriteLine("diff: " + diff);
        }


        //6.	Вивести на екран елементи масиву, значення яких лежать в межах:
        //елемент в хочаб 3 рази більший за значення найменшого елемента масиву,
        //але менший в хочаб 3 рази за значення найбільшого елемента масиву.
        private static void task6(int N, int[] array)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;

            for (int i = 0; i < N; i++)
            {
                min = Math.Min(min, array[i]);
                max = Math.Max(max, array[i]);
            }

            int right_value = max / 3;
            int left_value = min * 3;

            for (int i = 0; i < N; i++)
            {
                if (array[i] >= left_value && array[i] <= right_value)
                {
                    Console.WriteLine("element " + array[i]);
                }
            }
        }
        
        //2.	Яка знаходить і друкує номери тих рядків і стовпців, суми елементів яких однакові.
        private static void task2_2(int N, int M, int[,] array)
        {
            int[] sumsByRow = new int[N];
            int[] sumsByColumn = new int[M];
            
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < M; j++)
                {
                    sum += array[i, j];
                }

                sumsByRow[i] = sum;
            }
            
            for (int i = 0; i < M; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += array[j, i];
                }

                sumsByColumn[i] = sum;
            }

            var a = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (sumsByRow[i] == sumsByColumn[j])
                    {
                        a = true;
                        Console.WriteLine("sum of row "+ i + "is equal sum of column "+ j);
                    }
                }
                
            }

            if (!a)
            {
                Console.WriteLine("No matches");
            }
        }
    }
}