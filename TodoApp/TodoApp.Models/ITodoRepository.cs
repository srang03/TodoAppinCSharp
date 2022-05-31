using System.Collections.Generic;

namespace TodoApp.Models
{
    public interface ITodoRepository<T> where T : class
    {
        /// <summary>
        /// Todo 리스트를 출력합니다.
        /// </summary>
        /// <param name="model"></param>
        void AddTodo(T model);

        /// <summary>
        /// 모든 Todo 리스트를 출력하기 위해 List형태를 반환합니다.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Todo 리스트에서 id값을 입력받아 해당 요소를 삭제합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Todo 리스트에서 id 값을 입력받아 원하는 상세 내용을 반환합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T BrowseDetail(int id);

        bool UpdateTodo(T model);
    }
}
