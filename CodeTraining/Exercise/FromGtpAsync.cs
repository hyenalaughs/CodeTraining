using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace Leetcode.Exercise
{
    internal class FromGtpAsync
    {
        public void Test()
        {

        }


        // Async
        // 🧠 Задача:
        // Скачай 5 страниц с сайта(например, https://example.com/page1 ... page5)
        // параллельно, не блокируя основной поток, и выведи их длину.
        public async Task Execute1()
        {
            HttpClient client = new HttpClient();
            string[] urls = { "https://small-games.info/?s=1", "https://small-games.info/?s=2",
                              "https://small-games.info/?s=3", "https://small-games.info/?s=4",
                              "https://small-games.info/?s=5" };

            List<Task> tasks = new List<Task>();

            foreach (var url in urls)
            {
                tasks.Add(Task.Run(async () =>
                {
                    string content = await client.GetStringAsync(url);
                    Console.WriteLine("ulr: " + content.Length);
                }));
            }

            await Task.WhenAll(tasks);
        }

        public void Execute2()
        {
            // Многопоточность 
            // 🧠 Задача:
            // Создай 3 потока, каждый из которых пишет числа от 1 до 10 с
            // задержкой 100 мс между числами.Все потоки работают независимо,
            // но пишут в консоль с указанием своего имени([Thread 1] 1, [Thread 2] 1...).
            // Условия:
            // Используй Thread, Task или ThreadPool.
            // Не допускай одновременной записи в консоль(используй lock).

            for (int i = 0; i < 3; i++)
            {
                int threadNum = i;
                Thread th = new Thread(() => PrintDigits(threadNum));
                th.Name = $"Thread {threadNum + 1}";
                th.Start();
            }
        }

        object locker = new();

        public void PrintDigits(int threadNum)
        {
            for (int i = 0;i <= 10; i++)
            {
                lock (locker)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} ведет отсчёт {i}.");
                }
                Thread.Sleep(100);
            }
        }

        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;

        public void Execute3()
        {
            // 🧠 Задача:
            // Посчитай сумму квадратов всех чисел от 1 до 10_000_000,
            // используя Parallel.For или Parallel LINQ(PLINQ).

            //for (int i = 0; i < 1000001; i++)
            //{
            //    Square(i);
            //}

            Parallel.For(1, 10000000, () => 0L, 
                (i,loopState, localSum) =>
                {
                    localSum += (long)i * i;
                    return localSum;
                },
                localSum =>
                {
                    lock(locker)
                    {
                        sum += localSum;
                    }
                });

            sw.Stop();
            Console.WriteLine("Сумма равна: " + sum);
            Console.WriteLine("Затрачено времени: " + sw.Elapsed);
        }

        private void Square(int n)
        {
            lock (locker)
            {
                sum += (long)n*n;
            }
            Console.WriteLine("Сумма на " + n + " равна: " + sum);
        }
    }
}
