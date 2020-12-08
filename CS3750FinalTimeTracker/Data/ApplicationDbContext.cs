using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS3750FinalTimeTracker;
using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
    }
