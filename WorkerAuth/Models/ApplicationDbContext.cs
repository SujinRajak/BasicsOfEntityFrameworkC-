using Microsoft.EntityFrameworkCore;

namespace WorkerAuth
{
    
    //summary
    //the relational model of the application
    //summary
    public class ApplicationDbContext : DbContext
    {
        #region prioperties
        /// <summary>
        /// the  setting for user table of the application
        /// </summary>
        public DbSet<UserAcc> User { get; set; }

        #endregion

        #region constructor
        /// <summary>
        ///deafault constructor passing options expecting databsae options passsed in
        /// </summary>

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        #endregion




        //wiill be doing this in the constructor see above
        ////summary
        ////for the  dependecy injection 
        ////summary
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-THG2BP2;Database=Worker;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

       
        
        /// <summary>
        /// so if we want to do anything with the data in the table we ca ndo it here too
        /// </summary>
        /// <param name="modelBuilder"></param>
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //we cant creat indexers in the data model and to do that we can use it using model builder
            //using this we can make changes in the database attributes we can do anything with attributes in the database attrributes
            //fluent Api
            modelBuilder.Entity<UserAcc>().HasIndex(a => a.Citizenship).IsUnique();
        }
    }
}
