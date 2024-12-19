using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApplication.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        public List<Tasks> Tasks { get; set; } = new List<Tasks>();

        public Guid UserId { get; set; }


        [NotMapped]
        public List<Tasks> ImportantTasks => Tasks.Where(t => t.IsImportant).ToList();


        [NotMapped]
        public List<Tasks> CompletedTasks => Tasks.Where(t => t.IsCompleted).ToList();
    
        public ToDo() { }
        public ToDo(User user)
        {
            UserId = user.Id;
        }
    
    
    }
}
