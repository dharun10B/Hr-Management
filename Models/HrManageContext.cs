using Microsoft.EntityFrameworkCore;

using Microsoft.VisualBasic;

namespace Hr_Management.Models
{
    public class HrManageContext : DbContext
    {
        public HrManageContext(DbContextOptions<HrManageContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<RegisterModule>().HasData(
            //    new RegisterModule { EmpId = 4570, FirstName = "Sai", LastName = "Aravindh", Department = "HR", DOB = new DateOnly(2003, 2, 27), Gender = "Male", Email = "sai@gmail.com", Phone = 9876556789, Password = "sai@123" }
            //    );


            //modelBuilder.Entity<LoginModule>().HasOne(l => l.Register).WithOne(r => r.Login) // Navigation to LoginModule
            //    .HasForeignKey<LoginModule>(l => l.EmpId);
        }



        public DbSet<LoginModule> Login { get; set; }
        public DbSet<RegisterModule> Register { get; set; }
        public DbSet<AttendanceModule> Attendances { get; set; }
        public DbSet<AttendanceDetailsModule> Attendanced { get; set; }






    }
}
