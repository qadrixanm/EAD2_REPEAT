//X00114185 -  Kadrieh Mohamadzadeh
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace EAD2_Repeat.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }
        public DbSet<Weather> Weathers { get; set; }
    }
}