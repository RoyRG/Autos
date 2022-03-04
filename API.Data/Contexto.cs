using API.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    //DbSet de las tablas de la base de datos
    public class Contexto : DbContext
    {
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        //Contructor del DbContext
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        //Constructor del fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autos>().HasKey(k => k.Id_Auto);
            modelBuilder.Entity<Estado>().HasKey(k => k.Id_Estado);
            modelBuilder.Entity<Lote>().HasKey(k => k.Id_Lote);
            modelBuilder.Entity<Marcas>().HasKey(k => k.Id_Marca);
            modelBuilder.Entity<Modelo>().HasKey(k => k.Id_Modelo);

            modelBuilder.Entity<Autos>()
            .HasOne(d => d.Modelo)
            .WithOne()
            .HasForeignKey<Autos>(c => new { c.Id_Modelo });
            modelBuilder.Entity<Autos>()
            .HasOne(d => d.Estado)
            .WithOne()
            .HasForeignKey<Autos>(c => new { c.Id_Estado });
            modelBuilder.Entity<Autos>()
            .HasOne(d => d.Lote)
            .WithOne()
            .HasForeignKey<Autos>(c => new { c.Id_Lote });
            modelBuilder.Entity<Modelo>()
            .HasOne(d => d.Marca)
            .WithOne()
            .HasForeignKey<Modelo>(c => new {  c.Id_Marca });
        }
    }

}
