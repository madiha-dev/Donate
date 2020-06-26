using Donate.Domain;
using System.Data.Entity;

namespace Donate.Data
{
    public partial class DonateContext : DbContext
    {
        public DonateContext() : base("name=csDonate") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DonorInfo>().Ignore(c => c.HasError);
            //modelBuilder.Entity<DonorInfo>().Ignore(c => c.ErrorMessage);
            modelBuilder.Entity<DonorInfo>().ToTable("DonorInformation");               
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<DonationDetails> DonationDetails { get; set; }
        public virtual DbSet<DonorInfo> DonorInfo { get; set; }

        /*
         2 cup myda
         1/2 cup dhi
         1/2 tsp salt, sugr, backng soda

         2 tbs oil
         nem grm watr

        Add all things  mix then oil mix then dhi , mix , then watr mix it web , goond lo


        roghni k lye
        3 tbl dry milk
        buttr 1 tb
        dhi 1tb
        bkng 1/4 
        till 5 mins, put 4 hrs, apply oil , cover , 
         
         
         */
    }
}
