using Microsoft.EntityFrameworkCore;

using test1.Entity;

namespace test1.Data;


public class PostDbContext : DbContext {
    public PostDbContext (DbContextOptions<PostDbContext> options) 
    : base (options) { }
    public DbSet<PostEntity> posts { get; set; }
}
