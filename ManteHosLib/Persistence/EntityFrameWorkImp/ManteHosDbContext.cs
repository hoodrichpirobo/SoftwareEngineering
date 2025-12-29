using System;
using System.Data.Entity;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using ManteHos.Entities;

namespace ManteHos.Persistence
{
    public class ManteHosDbContext : DbContextISW
    {
        public ManteHosDbContext() : base("Name=ManteHosDbConnection") //this is the connection string name
        {
            /*
            See DbContext.Configuration documentation
            */
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        static ManteHosDbContext()
        {
            Database.SetInitializer<ManteHosDbContext>(new DropCreateDatabaseIfModelChanges<ManteHosDbContext>());
        }

        // DbSets for persistent classes in your case study
        // TO BE DONE by STUDENTS...
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<UsedPart> UsedParts { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
/*                        modelBuilder.Entity<Part>()
                                    .HasMany(p => p.UsedParts)
                                    .WithRequired(uP => uP.Part)
                                    .WillCascadeOnDelete(true);

                        modelBuilder.Entity<UsedPart>()
                            .HasRequired(p => p.Part)
                            .WithMany(uP => uP.UsedParts)
                            .WillCascadeOnDelete(false);
*/

        }

        // Generic method to clear all the data (except some relations if needed)
        public override void RemoveAllData()
        {
            clearSomeRelationships();

            base.RemoveAllData(); 
        }

        // Sometimes it is needed to clear some relationships explicitly 
        private void clearSomeRelationships()
        {
//            SaveChanges();
        }

    }
}

