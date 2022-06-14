using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todo.WebForm
{
    public partial class TodoList : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
           DisplayData();
        }

        private void DisplayData()
        {
            const string url = "https://localhost:44368/api/todos";

            using (var client = new System.Net.Http.HttpClient())
            {
                // 데이터 전송
                var json = JsonConvert.SerializeObject(new Todo
                {
                    Title = "Dapper",
                    IsDone= false
                });

                var post = new StringContent(json, Encoding.UTF8, "application/json");
                // client.PostAsync(url, post).Wait();

                // 데이터 수신
                var res = client.GetAsync(url).Result;
                var result = res.Content.ReadAsStringAsync().Result;
                var todos = JsonConvert.DeserializeObject<List<Todo>>(result);

                // 필터링 : LINQ 함수형 프로그래밍

                // [1] SELECT 메서드 : map()
                    //IEnumerable<Todo> query = todos.Select(todo => todo);
                    //var query = from todo in todos
                    //            select todo;

                var query = todos.Select(todo => new TodoViewModel() {  
                    Title = todo.Title,  IsDone = todo.IsDone
                });

                var query2 = todos.AsEnumerable<Todo>();
                var query3 = todos.AsQueryable<Todo>();

                var query4 = todos.Where<Todo>(todo => !todo.IsDone ).OrderBy(it => it.Title);
                

                // 데이터 바인딩
                this.dg_list.DataSource = query;
                this.dg_list.DataBind();

                this.dg_list2.DataSource = todos
                    .Where(todo => todo.Id % 2 == 0 && !todo.IsDone)
                    .OrderBy(todo => todo.Id)
                    .Select(todo => new TodoViewModel() { Title = todo.Title, IsDone = todo.IsDone })
                    .ToList();
                this.dg_list2.DataBind();
            }
        }
    }
 


    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    public class TodoViewModel
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}