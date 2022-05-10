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
        public DbSet<Facebook.Entities.PostLikeEntities> PostLikeEntities { get; set; }
        public DbSet<Facebook.Entities.AccountUserInfoEntities> AccountUserInfoEntities { get; set; }
        public DbSet<Facebook.Entities.CommentEntities> CommentEntities { get; set; }
    }
}
