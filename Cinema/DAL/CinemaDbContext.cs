using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CinemaDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Person>()
            .HasKey(e => e.ID);
        
        modelBuilder.Entity<Actor>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Actor>()
            .HasOne<Person>(e => e.Person)
            .WithOne()
            .HasForeignKey<Actor>(e => e.PersonID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Director>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Director>()
            .HasOne<Person>(e => e.Person)
            .WithOne()
            .HasForeignKey<Director>(e => e.PersonID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<User>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<User>()
            .HasOne<Person>(e => e.Person)
            .WithOne()
            .HasForeignKey<User>(e => e.PersonID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Ticket>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Ticket>()
            .HasOne<User>(e => e.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>()
            .HasOne<Session>(t => t.Session)
            .WithMany(s => s.Tickets)
            .HasForeignKey(t => t.SessionID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Movie>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Movie>()
            .HasMany<Actor>(e => e.Actors)
            .WithMany(a => a.Movies);
        modelBuilder.Entity<Movie>()
            .HasMany<Director>(e => e.Directors)
            .WithMany(d => d.Movies);
        modelBuilder.Entity<Movie>()
            .HasMany<Genre>(e => e.Genres)
            .WithMany(g => g.Movies);
        
        modelBuilder.Entity<Session>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Session>()
            .HasOne<Movie>(e => e.Movie)
            .WithMany(m => m.Sessions)
            .HasForeignKey(e => e.MovieID)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Session>()
            .HasOne<Hall>(e => e.Hall)
            .WithMany(h => h.Sessions)
            .HasForeignKey(e => e.HallID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Genre>()
            .HasKey(e => e.ID);
        
        modelBuilder.Entity<Hall>()
            .HasKey(e => e.ID);
    }
}