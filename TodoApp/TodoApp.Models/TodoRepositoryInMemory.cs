using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Models
{
    /// <summary>
    /// 인-메모리 데이터베이스 사용 영역
    /// </summary>
    public class TodoRepositoryInMemory : ITodoRepository<TodoModel>
    {
        // [1] 인-메모리 데이터베이스 역할 (인-메모리 > 컬렉션)
        private static List<TodoModel> _todos;

        // [2] 초기화 > Dummy 데이터 3개 출력
        public TodoRepositoryInMemory()
        {
            _todos = new List<TodoModel>() {
                new TodoModel(){ Id=1, Title="ASP.NET 학습", IsDone=false },
                new TodoModel(){ Id=2, Title="C# 학습", IsDone=false },
                new TodoModel(){ Id=3, Title="Blazor 학습", IsDone=false },
            };
        }

        public void AddTodo(TodoModel model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            model.IsDone = false;
           _todos.Add(model);
        }

        public TodoModel BrowseDetail(int id)
        {
            TodoModel todo = _todos.Where(todo => todo.Id == id).SingleOrDefault();
            return todo;
        }

        public bool Delete(int id)
        {
            int count = _todos.RemoveAll(t => t.Id == id);

            if (count > 0) return true;
            return false;
        }

        public List<TodoModel> GetAll()
        {
            List<TodoModel> result = _todos;
            return result;
        }

        public string Test()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTodo(TodoModel model)
        {
            
            var result = _todos.Where(todo => todo.Id == model.Id).Select(todo => { todo.Title = model.Title;  todo.IsDone = model.IsDone; return todo; }).SingleOrDefault();
            System.Console.WriteLine(result.Id);
            if (result != null)
            {
                return true;
            }
                
            return false;
        }
    }
}
