using SQLServer.Models;
using System.Data.Entity;

namespace SQLServer
{
    public partial class MicromobililtyContext : DbContext
    {
        public MicromobililtyContext()
            : base("name=MicromobililtyContext")
        {
        }

        public virtual DbSet<Historical> historicals { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Payment_method> payment_method { get; set; }
        public virtual DbSet<Payment> payments { get; set; }
        public virtual DbSet<Problem> problems { get; set; }
        public virtual DbSet<Trip> trips { get; set; }
        public virtual DbSet<UnitOfMeasure> unit_measurements { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region HISTORICAL
            modelBuilder.Entity<Historical>()
                    .Property(e => e.latitude)
                    .HasPrecision(18, 0);

            modelBuilder.Entity<Historical>()
                .Property(e => e.longitude)
                .HasPrecision(18, 0);
            #endregion

            #region LANGUAGE
            modelBuilder.Entity<Language>()
                  .Property(e => e.language1)
                  .IsUnicode(false);
            #endregion

            #region PAYMENT METHOD
            modelBuilder.Entity<Payment_method>()
                  .Property(e => e.payment_type)
                  .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.payment_type)
                .IsUnicode(false);
            #endregion

            #region PROBLEM
            modelBuilder.Entity<Problem>()
                   .Property(e => e.description)
                   .IsUnicode(false);
            #endregion

            #region TRIP
            modelBuilder.Entity<Trip>()
                  .Property(e => e.feedback)
                  .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.historicals)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.problems)
                .WithRequired(e => e.trip)
                .WillCascadeOnDelete(false);
            #endregion

            #region UNIT OF MEASURE
            modelBuilder.Entity<UnitOfMeasure>()
                   .Property(e => e.unit_measurement)
                   .IsUnicode(false);
            #endregion

            #region USER
            modelBuilder.Entity<User>()
                 .Property(e => e.name)
                 .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.numero_conta)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.nome_utilizador)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.historicals)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.trips)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
            #endregion

            #region VEHICLE
            modelBuilder.Entity<Vehicle>()
                   .Property(e => e.status)
                   .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.latitude);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.longitude);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.trips)
                .WithRequired(e => e.vehicle)
                .WillCascadeOnDelete(false);
            #endregion
        }
    }
}
