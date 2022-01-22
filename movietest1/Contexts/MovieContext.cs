using movietest1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace movietest1.Contexts
{
    public class MovieContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}