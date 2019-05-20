using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScinReport.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cafedra> Cafedras  { get; set; }
        public DbSet< Facultet>  Facultets { get; set; }
        public DbSet< Manager> Managers  { get; set; }
        public DbSet<Publication> Publications  { get; set; }
        public DbSet< Teacher> Teachers  { get; set; }
        public DbSet< User> User_s  { get; set; }
        public DbSet< Title> Titles  { get; set; }
        public DbSet<Work_User> Work_Users  { get; set; }
        public DbSet<WorkEnum> Work_Enums  { get; set; }
    
public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

            Database.EnsureCreated();
        }
    }
}
