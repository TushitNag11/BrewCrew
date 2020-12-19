namespace BrewCrewDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// This is an entity class to hold all the Dbsets for each of the database tables 
    /// </summary>
    public partial class BrewCrewEntities : DbContext
    {
        public BrewCrewEntities()
            : base("name=BrewCrewEntities")
        {
        }

        //Dbset corresponding to each table of the database
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        /// <summary>
        /// This method defines the model for each of the context 
        /// </summary>
        /// <param name="modelBuilder">It is used to map each of the DAL class to the databse schema</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drink>()
                .Property(e => e.DrinkPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Drink>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Drink)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topping>()
                .Property(e => e.ToppingPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Topping>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Topping)
                .WillCascadeOnDelete(false);
        }
    }
}
