using System;
using System.Collections.Generic;
using System.Text;
using CentralDeApostasApi.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CentralDeApostasApi.Infrastructure.Context
{
    public class PostgreSqlContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
    }
}
