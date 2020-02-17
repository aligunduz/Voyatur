namespace DataAccessLayer
{
    using DataAccessLayer.entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLayer.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Users> Users { get; set; }
         public virtual DbSet<Organisations> Organisations { get; set; }
         public virtual DbSet<Ships> Ships { get; set; }
         public virtual DbSet<Tours> Tours { get; set; }
         public virtual DbSet<YachtRenting> YachtRenting { get; set; }

        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.RentedYachtes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId); 
            modelBuilder.Entity<Ships>()
                .HasMany(e => e.RentedYachtes)
                .WithOptional(e => e.Ship)
                .HasForeignKey(e => e.YachtId);
            

        }
    }
}