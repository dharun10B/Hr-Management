using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Hr_Management.Models
{
    public class HrManageContext : DbContext
    {
        public HrManageContext(DbContextOptions<HrManageContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterModule>().HasData(
                new RegisterModule { EmpId = 4570 , FirstName = "Sai" , LastName = "Aravindh" , Department = "HR" , DOB = new DateOnly(2003, 2, 27) , Gender = "Male" , Email = "sai@gmail.com" , Phone = 9876556789 , Password = "sai@123"}
                );
        }

        public DbSet<LoginModule> Login { get; set; }
        public DbSet<RegisterModule> Register { get; set; }


    }
}
