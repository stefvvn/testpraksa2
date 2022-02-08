using Microsoft.EntityFrameworkCore;
using Facebook.Entities;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() : base("ApplicationDbContext")
        { }


        public virtual DbSet<PostEntities> Post { get; set; }
        public virtual DbSet<AccountUserInfoEntities> User { get; set; }
    }
}
