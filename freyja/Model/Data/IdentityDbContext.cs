// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Freyja.Model.Identity;

namespace Freyja.Model.Data
{

    public class IdentityDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<UserSecret> Secrets { get; set; }

        public DbSet<Claim> Claims { get; set; }



        // Primary Constructor
        public IdentityDbContext(string connectionString) : base(connectionString) { }


        // Alternative Constructor - for mocking and testing purposes
        public IdentityDbContext() : base("Server=(localdb)\v11.0;Database=Freyja.Identity;Integrated Security=true;MultipleActiveResultSets=true;") { }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasMany((u) => u.Claims).WithMany();
            
            base.OnModelCreating(modelBuilder);
        }

    }

}