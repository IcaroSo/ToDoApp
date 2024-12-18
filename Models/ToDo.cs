using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApplication.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        public List<Task> Tasks { get; set; } = new List<Task>();

        public required Guid UserId { get; set; }


        [NotMapped]
        public List<Task> ImportantTasks => Tasks.Where(t => t.IsImportant).ToList();


        [NotMapped]
        public List<Task> CompletedTasks => Tasks.Where(t => t.IsCompleted).ToList();
    }
}
