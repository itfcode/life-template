namespace ITLT.Domain.Migrations
{

    using ITLT.Domain.Implementations;
    using System.Data.Entity.Migrations;

    public sealed class DataConfiguration : DbMigrationsConfiguration<DataContext>
    {

        public DataConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;

            // Comment the line below if you afraid that critical data can be lost
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
        }
    }
}
