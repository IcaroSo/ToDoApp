using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.Services
{
    public class ToDoService
    {
        public required Guid UserId { get; set; }
        public required ToDo ToDo { get; set; }
        public DatabaseContext DatabaseContext { get; set; }


        public ToDoService(Guid userId, DatabaseContext databaseContext)
        {
            UserId = userId;
            DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            ToDo = DatabaseContext.ToDo.FirstOrDefault(t => t.UserId == UserId) ?? throw new ArgumentNullException(nameof(ToDo));
        }

        public async Task createTask(Tasks task)
        {
            task.ToDoId = ToDo.Id;
            DatabaseContext.Tasks.Add(task);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task deleteTask(Tasks task)
        {
            DatabaseContext.Tasks.Remove(task);
            await DatabaseContext.SaveChangesAsync();
        }
        
        public async Task editTask(Tasks task, Tasks taskEdit)
        {
            var newTaskEdit = await DatabaseContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id && t.ToDoId == ToDo.Id) ?? throw new ArgumentNullException(nameof(Tasks));
            newTaskEdit = taskEdit;
            DatabaseContext.Tasks.Update(newTaskEdit);
            await DatabaseContext.SaveChangesAsync();

        }

        public async Task markAsComplete(Tasks task)
        {
            var taskForMark = await DatabaseContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id && t.ToDoId == ToDo.Id) ?? throw new ArgumentNullException(nameof(Tasks));
            taskForMark.IsCompleted = true;
            DatabaseContext.Tasks.Update(taskForMark);
            await DatabaseContext.SaveChangesAsync();
        }

        public List<Tasks> showTasksWithFiltes(FilterType.Filter filter)
        {
            List<Tasks> tasksWithFilter = new List<Tasks>();

            switch (filter)
            {
                case FilterType.Filter.Important:
                    tasksWithFilter = DatabaseContext.Tasks.Where(t => t.ToDoId == ToDo.Id && t.IsImportant).ToList();
                    break;

                case FilterType.Filter.NotCompleted:
                    tasksWithFilter = DatabaseContext.Tasks.Where(t => t.ToDoId == ToDo.Id && !t.IsCompleted).ToList();
                    break;

                case FilterType.Filter.Completed:
                    tasksWithFilter = DatabaseContext.Tasks.Where(t => t.ToDoId == ToDo.Id && t.IsCompleted).ToList();
                    break;

                case FilterType.Filter.MyDay:
                    tasksWithFilter = DatabaseContext.Tasks.Where(t => t.ToDoId == ToDo.Id && t.ScheduledFor.Date == DateTime.Today.Date).ToList();
                    break;

                default:
                    break;

            }
            return tasksWithFilter;
        }
    }
}
