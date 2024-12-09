using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Company> Company { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=209_Shkurkin_Manager;password=M9aR3@L;database=aspnet";

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}