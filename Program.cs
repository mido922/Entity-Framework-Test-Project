using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using (var context = new MyDbContext())
{
    var basicToDoTask = new toDoTask()
    {
        Name = "Clean House",
        Status = "Unfinished.",
    };

    context.toDoTasks.Add(basicToDoTask);

    context.SaveChanges();

    var allToDoTasks = context.toDoTasks.ToList();
} 



public class MyDbContext : DbContext
{
    public DbSet<toDoTask> toDoTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TestTaskDB");
    }


}

public class toDoTask
{
    public string Name { get; set; }
    public string Status { get; set; }


}