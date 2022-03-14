#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Facebook.Entities;

namespace Facebook.UI.MVC.Data
{
    public class FacebookUIMVCContext : DbContext
    {
        public FacebookUIMVCContext (DbContextOptions<FacebookUIMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Facebook.Entities.PostEntities> PostEntities { get; set; }
    }
}
