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
    public class TodoRepositoryFile : ITodoRepository<TodoModel>
    {
        // [1] 인-메모리 데이터베이스 역할 (인-메모리 > 컬렉션)
        private static List<TodoModel> _todos = new List<TodoModel>();
        private const string _filePath = "C:\\Users\\Ian\\Desktop\\ian\\C#\\TodoAppinCSharp\\TodoApp\\Todo.ConsoleApp\\Todo.txt";

        // [2] 초기화 > Dummy 데이터 3개 출력
        public TodoRepositoryFile(string filePath = _filePath)
        {
            string[] todos = File.ReadAllLines(filePath, Encoding.Default);
            foreach (string todo in todos)
            {
                string[] str = todo.Split(',');
                _todos.Add(new TodoModel()
                {
                    Id = int.Parse(str[0]), Title = str[1], IsDone = bool.Parse(str[2])
                });

            }
            Console.WriteLine("파일 생성 완료");
        }

        public void AddTodo(TodoModel model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            model.IsDone = false;
           _todos.Add(model);

            string data_all = File.ReadAllText(_filePath)+  $"{model.Id},{model.Title},{model.IsDone}";
  
            StreamWriter sw = new StreamWriter(_filePath);
            sw.WriteLine(data_all);
            sw.Close();
            sw.Dispose();
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
            StreamWriter sw = new StreamWriter(_filePath);

            foreach (TodoModel todo in _todos)
            {
                sw.WriteLine($"{todo.Id},{todo.Title},{todo.IsDone}");
            }
            sw.Close();
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
    }
}
