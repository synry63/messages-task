using messages_task_api.Models;
using Microsoft.EntityFrameworkCore;

namespace messages_task_api
{
    public class MessagesTaskContext : DbContext
    {
        public MessagesTaskContext(DbContextOptions<MessagesTaskContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<HistoryLog> HistoryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(e => e.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<Message>().Property(e => e.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<HistoryLog>().Property(e => e.Id).HasDefaultValueSql("newid()");


            //Seed Data for testing
            Guid[] guidsUsers = new Guid[] { Guid.NewGuid(), Guid.NewGuid()};
            modelBuilder.Entity<User>().HasData(
                 new User { Id = guidsUsers[0], Email = "synry63@gmail.com",
                     PasswordSalt = "/DYD9vqoSbSJ9B9b8AoThQ==",
                     PasswordHash = "C3TZb8Ef5NcKnL/1CmjTrvYsixij9REwLDVkoK2UvFs="
                 },
                 new User { Id = guidsUsers[1], Email = "toto@gmail.com", 
                     PasswordSalt = "/DYD9vqoSbSJ9B9b8AoThQ==", 
                     PasswordHash = "C3TZb8Ef5NcKnL/1CmjTrvYsixij9REwLDVkoK2UvFs="
                 }
            );
            Guid[] guidsMessages = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
            modelBuilder.Entity<Message>().HasData(
                 new Message { 
                     Id = Guid.NewGuid(), SenderEmail = "toto@gmail.com", 
                     Body ="Hello Patrick how are you", UserId = guidsUsers[0],DateReceived= new DateTime(2023,1,1),
                 },
                 new Message { Id = Guid.NewGuid(), SenderEmail = "toto@gmail.com", 
                     Body = "I hope you are fine", UserId = guidsUsers[0] ,DateReceived= new DateTime(2023,1,2)
                 }
            );
        }
    }
}
