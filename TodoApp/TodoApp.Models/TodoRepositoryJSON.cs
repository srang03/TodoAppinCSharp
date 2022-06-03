using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TodoApp.Models
{
    /// <summary>
    /// 인-메모리 데이터베이스 사용 영역
    /// </summary>
    public class TodoRepositoryJSON : ITodoRepository<TodoModel>
    {
        // [1] 인-메모리 데이터베이스 역할 (인-메모리 > 컬렉션)
        private static List<TodoModel> _todos = new List<TodoModel>();
        private const string _filePath = "C:\\Users\\Ian\\Desktop\\ian\\C#\\TodoAppinCSharp\\TodoApp\\Todo.ConsoleApp\\Todo.json";

        // [2] 초기화 > Dummy 데이터 3개 출력
        public TodoRepositoryJSON(string filePath = _filePath)
        {
            var todos = File.ReadAllText(filePath, Encoding.Default);
            _todos = JsonConvert.DeserializeObject<List<TodoModel>>(todos);
        }

        public void AddTodo(TodoModel model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
           _todos.Add(model);

            ChangeFile();
        }

        public TodoModel BrowseDetail(int id)
        {
            TodoModel todo = _todos.Where(todo => todo.Id == id).SingleOrDefault();
            return todo;
        }

        public bool Delete(int id)
        {
            int count = _todos.RemoveAll(t => t.Id == id);

            if (count > 0) 
            {
                ChangeFile();
                return true;
            }
            
            return false;
        }

        private void ChangeFile()
        {
            string json = JsonConvert.SerializeObject(_todos, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public List<TodoModel> GetAll()
        {
            List<TodoModel> result = _todos;
            return result;
        }

        public bool UpdateTodo(TodoModel model)
        {
            
            var result = _todos.Where(todo => todo.Id == model.Id).Select(todo => { todo.Title = model.Title;  todo.IsDone = model.IsDone; return todo; }).SingleOrDefault();
            System.Console.WriteLine(result.Id);
            if (result != null)
            {
                ChangeFile();
                return true;
            }
                
            return false;
        }
        public string Test()
        {
            return $"{_todos[_todos.Count - 1].Id}, {_todos[_todos.Count - 1].Title}, {_todos[_todos.Count - 1].IsDone}";
        }
    }
}
