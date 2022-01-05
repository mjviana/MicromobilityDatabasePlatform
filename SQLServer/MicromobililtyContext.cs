using SQLServer.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SQLServer
{
    public partial class MicromobililtyContext : DbContext
    {
        public MicromobililtyContext()
            : base("name=MicromobililtyContext")
        {
        }

        public virtual DbSet<historical> historicals { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<payment_method> payment_method { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<problem> problems { get; set; }
        public virtual DbSet<trip> trips { get; set; }
        public virtual DbSet<unit_measurements> unit_measurements { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vehicle> vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<historical>()
                .Property(e => e.latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<historical>()
                .Property(e => e.longitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Language>()
                .Property(e => e.language1)
                .IsUnicode(false);

            modelBuilder.Entity<payment_method>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<problem>()
                .Property(e => e.problem1)
                .IsUnicode(false);

            modelBuilder.Entity<trip>()
                .Property(e => e.feedback)
                .IsUnicode(false);

            modelBuilder.Entity<trip>()
                .HasMany(e => e.historicals)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trip>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trip>()
                .HasMany(e => e.problems)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<unit_measurements>()
                .Property(e => e.unit_measurement)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.numero_conta)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nome_utilizador)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.historicals)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.trips)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.latitude);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.longitude);

            modelBuilder.Entity<vehicle>()
                .HasMany(e => e.trips)
                .WithRequired(e => e.vehicle)
                .WillCascadeOnDelete(false);
        }
    }
}
