namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Good",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RevenueItemId = c.Int(),
                        ExpenseItemId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseItem", t => t.ExpenseItemId)
                .ForeignKey("dbo.RevenueItem", t => t.RevenueItemId)
                .Index(t => t.RevenueItemId)
                .Index(t => t.ExpenseItemId);
            
            CreateTable(
                "dbo.RevenueItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Good", "RevenueItemId", "dbo.RevenueItem");
            DropForeignKey("dbo.Good", "ExpenseItemId", "dbo.ExpenseItem");
            DropIndex("dbo.Good", new[] { "ExpenseItemId" });
            DropIndex("dbo.Good", new[] { "RevenueItemId" });
            DropTable("dbo.RevenueItem");
            DropTable("dbo.Good");
            DropTable("dbo.ExpenseItem");
        }
    }
}
