using Database.Models;
using DataModels.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<GroupType>("group_type");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<StateType>("state_type");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=AppDB;Username=postgres;Password=postgres");
            }           
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresEnum<GroupType>();
            builder.HasPostgresEnum<StateType>();           
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }
}
