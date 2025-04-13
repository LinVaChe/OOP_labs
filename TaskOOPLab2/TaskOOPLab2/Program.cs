using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskOOPLab2 
{
    static class Program
    {
        static string[] urls = { "https://www.google.com/", "https://ru.wikipedia.org/wiki", "https://web.whatsapp.com/" };
        public static void SyncRequest() {
            var HttpClient = new HttpClient();
            Stopwatch timer = Stopwatch.StartNew();
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"\nЗапрос к {url}");
                    var response = HttpClient.GetAsync(url).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode} ({(int)response.StatusCode})");
                        return;
                    }

                    string Json = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Ответ (JSON) от {url} :");
                    Console.WriteLine(Json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при запросе к {url}: {ex.Message}");
                }
            }
            timer.Stop();
            Console.WriteLine($"Время синхронного выполнения запросов в мс: {timer.ElapsedMilliseconds}\n");
        }
        public static async Task<string> AsncRequest() 
        {
            var HttpClient = new HttpClient();
            Stopwatch timer = Stopwatch.StartNew();
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"\nЗапрос к {url}");
                    var response = await HttpClient.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode} ({(int)response.StatusCode})");
                        return null;
                    }

                    string Json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Ответ (JSON) от {url} :");
                    Console.WriteLine(Json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при запросе к {url}: {ex.Message}");
                    return null;
                }
            }
            timer.Stop();
            Console.WriteLine($"Время асинхронного выполнения запросов в мс: {timer.ElapsedMilliseconds}\n");
            return timer.Elapsed.ToString();
        }
        public static void Main() {
            SyncRequest();
            AsncRequest().Wait();
        }

    }

}