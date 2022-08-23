using Microsoft.EntityFrameworkCore;

namespace todolist.Models{
public class TodoContext: DbContext{
    public TodoContext(DbContextOptions<TodoContext> options): base(options) {

    }
    public DbSet<todotask> todotasks{get; set;}
    public DbSet<User> Users{get;set;}
    
}

}