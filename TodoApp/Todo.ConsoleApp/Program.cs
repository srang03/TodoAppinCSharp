using TodoApp.Models;

public class Program
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
    static void Main(string[] args)
    {
        //// [1] 인-메모리 데이터베이스 생성
        //ITodoRepository<TodoModel> _repository = new TodoRepositoryInMemory();

        //List<TodoModel> todos = new List<TodoModel>();

        //// [2] 모든 데이터 출력
        //todos = _repository.GetAll();
        //ShowAll(todos);

        //// [3] 데이터 입력
        //TodoModel todo = new TodoModel() { Title="DB 학습하기" };
        //_repository.AddTodo(todo);

        //// [4] 데이터 삭제
        //_repository.Delete(1);
        //ShowAll(todos);

        //// [5] 상세 데이터 가져오기
        //TodoModel details = _repository.BrowseDetail(2);
        //Console.WriteLine($"[{details.Id}] \t {details.Title} \t {details.IsDone}");

        //// [6] 데이터 수정
        //TodoModel tmp = new TodoModel() { Id=3, Title=".NET Standard", IsDone=true };
        //_repository.UpdateTodo(tmp);

        //ShowAll(todos);

        // [1] 파일 데이터베이스 
        //ITodoRepository<TodoModel> _repository = new TodoRepositoryFile();

        //List<TodoModel> todos = new List<TodoModel>();

        //todos = _repository.GetAll();
        //ShowAll(todos);

        //_repository.AddTodo(new TodoModel()
        //{
        //    Title = "SQL Server2",
        //    IsDone = false
        //});

        //ShowAll(todos);
        //_repository.Delete(1);

        //ShowAll(todos);

        //_repository.UpdateTodo(new TodoModel() { Id = 3, Title = "Core Core", IsDone = true });
        //ShowAll(todos);

        // [3] JSON 파일
        ITodoRepository<TodoModel> _repository = new TodoRepositoryJSON();

        var todos = _repository.GetAll();
        ShowAll(todos);
    }
}