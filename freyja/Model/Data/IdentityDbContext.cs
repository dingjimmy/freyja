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

        public DbSet<Role> Roles { get; set; }

    }

}