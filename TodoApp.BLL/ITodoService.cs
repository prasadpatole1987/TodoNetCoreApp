using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.BLL.DTO;

namespace TodoApp.BLL
{
    public interface ITodoService
    {
        List<TodoRequest> GetAll();
        TodoRequest Get(Guid id);

        TodoRequest Insert(TodoRequest todoRequest);

        void Update(TodoRequest todoRequest);

        void Delete(Guid id);
    }
}
