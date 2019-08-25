using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalDiaryToDo.Models
{
    public class UserDiaryContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserDiary> UserDiary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=UserDiaryDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User {Id=1, FirstName = "Magdy", LastName= "Hussien" });
            modelBuilder.Entity<UserDiary>().HasData(new UserDiary { UserDiaryId = 1,UserId=1, DiaryTitle="Go To Party",DiaryDataTime= DateTime.Now,DiaryContent="",InsertionDate=DateTime.Now});
        }
    }
}
