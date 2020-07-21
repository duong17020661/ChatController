using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebChat.Models;

namespace WebChat.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FileAndImage> Files { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
    }
}
