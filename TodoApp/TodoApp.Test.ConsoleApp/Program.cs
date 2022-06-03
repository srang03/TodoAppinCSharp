using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Test.ConsoleApp
{
    internal class Program
    {
        public static void ShowAll(List<TodoModel> list)
        {
            Console.WriteLine("------------------------------");
            foreach (TodoModel model in list)
            {
                System.Console.WriteLine($"[{model.Id}] \t {model.Title} \t {model.IsDone}");
            }
            Console.WriteLine("------------------------------");
        }

        static async Task Main(string[] args)
        {
            const string url = "https://localhost:44368/api/todos";
        

            using (var client = new HttpClient())
            {
                // 데이터 전송
                TodoModel todo = new TodoModel()
                {
                    Title = "WEB API Test",
                    IsDone = false
                };

                var json = JsonConvert.SerializeObject(todo, Formatting.Indented);
                var post = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(url, post);

                // 데이터 수신
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                var todos = JsonConvert.DeserializeObject<List<TodoModel>>(result);

                ShowAll(todos);
            }

        }
    }
}
