namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_InvoiceInSrc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceInSrcs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        CheckNumber = c.String(),
                        Name = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cash = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InvoiceInSrcs");
        }
    }
}
