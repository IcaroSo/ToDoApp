using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDoApplication.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("name", TypeName = "VARCHAR(255)"), Required(ErrorMessage = "Required name")]
    public required string Name { get; set; }

    [EmailAddress(ErrorMessage = "Email format invalid!")]
    [Column("email", TypeName = "VARCHAR(255)"), Required(ErrorMessage = "Required email!")]
    public required string Email { get; set; }

    [Column("password", TypeName = "VARCHAR(255)"), Required(ErrorMessage = "Required password")]
    public required string Password { get; set; }

    [Column("create_at", TypeName = "TIMESTAMP"), Required]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    public ToDo? ToDo { get; set; }

    public User() { }

}
