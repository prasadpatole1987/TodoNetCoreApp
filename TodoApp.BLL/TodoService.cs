using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.BLL.DTO;
using TodoApp.DAL;
using TodoApp.DAL.Domain;

namespace TodoApp.BLL
{
    public class TodoService : ITodoService
    {
        IRepository<Todo> _repository;

        public TodoService(IRepository<Todo> repository)
        {
            this._repository = repository;
        }

        public void Delete(Guid id)
        {
            var todo = this._repository.GetAll().SingleOrDefault(t => t.Id == id);
            this._repository.Delete(todo);
        }

        public TodoRequest Get(Guid id)
        {
            return this._repository.GetAll().Where(t=> t.Id == id).Select(x => new TodoRequest
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsComplete = x.IsComplete
            }).SingleOrDefault();
        }

        public List<TodoRequest> GetAll()
        {
            return this._repository.GetAll().Select(x => new TodoRequest {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsComplete = x.IsComplete
            }).ToList();
        }

        public TodoRequest Insert(TodoRequest todoRequest)
        {
            if (todoRequest != null)
            {
                var todo = new Todo
                {
                    Id = Guid.NewGuid(),
                    Title = todoRequest.Title,
                    Description = todoRequest.Description,
                    IsComplete = todoRequest.IsComplete
                };

                this._repository.Insert(todo);
                todoRequest.Id = todo.Id;
            }
            return todoRequest;
        }

        public void Update(TodoRequest todoRequest)
        {
            if (todoRequest != null && todoRequest.Id != null)
            {
                var todo = this._repository.GetAll().SingleOrDefault(x => x.Id == todoRequest.Id);
                todo.Title = todoRequest.Title;
                todo.Description = todoRequest.Description;
                todo.IsComplete = todoRequest.IsComplete;

                this._repository.Update(todo);
            }
        }
    }
}
