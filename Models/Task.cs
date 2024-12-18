using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ToDoApplication.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "The task must have an title")]
        [Column("title", TypeName = "VARCHAR(255)")]
        public required string Title { get; set; }
        

        [Column("is_important", TypeName = "BOOLEAN")]
        public bool IsImportant { get; set; }


        [Column("is_completed", TypeName = "BOOLEAN")]
        public bool IsCompleted { get; set; }


        [Column("is_task_list", TypeName = "BOOLEAN")]
        public bool IsTaskList { get; set; }


        [Column("description", TypeName = "VARCHAR(255)")]
        public string? Description { get; set; }


        [Column("task_list", TypeName = "TEXT")]
        public string? TaskListJson
        {
            get => TaskList == null ? null : JsonSerializer.Serialize(TaskList);
            set => TaskList = string.IsNullOrWhiteSpace(value)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(value);
        }

        [NotMapped]
        public List<string>? TaskList { get; set; }


        [Column("created_at", TypeName = "TIMESTAMP")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [Column("scheduled_for", TypeName = "TIMESTAMP")]
        public DateTime ScheduledFor { get; set; }

        public required Guid ToDoId { get; set; }
    
        public Task(ToDo toDo)
        {
            ToDoId = toDo.Id;
        }
    
    }
}
