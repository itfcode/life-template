namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refs_Currency_MoneyAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ShortName = c.String(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoneyAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoneyAccount", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.MoneyAccount", new[] { "CurrencyId" });
            DropTable("dbo.MoneyAccount");
            DropTable("dbo.Currency");
        }
    }
}
