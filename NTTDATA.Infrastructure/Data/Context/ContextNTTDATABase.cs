
using Microsoft.EntityFrameworkCore;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTTDATA.Infrastructure.Data.Context
{
    public partial class ContextNTTDATA
    {
        public DbSet<DetalleMov> detalleMovs { get; set; }
        public DbSet<Resulset> resulsets { get; set; }
        public DbSet<Reports> reportes { get; set; }
        public DbSet<ResulsetBase>  resulsetBases{ get; set; }
        


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleMov>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });
            modelBuilder.Entity<Reports>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });
            modelBuilder.Entity<Resulset>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });
            modelBuilder.Entity<ResulsetBase>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });
            
        }
     
    }
}
