namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDocuments1 : DbMigration
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
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoneyAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.ExpenseItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        Name = c.String(nullable: false),
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
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceInHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Commited = c.Boolean(nullable: false),
                        Marked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceInRow",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeadId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceInHead", t => t.HeadId, cascadeDelete: true)
                .Index(t => t.HeadId);
            
            CreateTable(
                "dbo.InvoiceOutHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Commited = c.Boolean(nullable: false),
                        Marked = c.Boolean(nullable: false),
                        Contract_Id = c.Int(),
                        Contragent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .ForeignKey("dbo.Contragents", t => t.Contragent_Id)
                .Index(t => t.Contract_Id)
                .Index(t => t.Contragent_Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(),
                        DateFinish = c.DateTime(),
                        Name = c.String(),
                        Description = c.String(),
                        Contragent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contragents", t => t.Contragent_Id)
                .Index(t => t.Contragent_Id);
            
            CreateTable(
                "dbo.Contragents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ITIN = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceOutRow",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeadId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Good_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Good", t => t.Good_Id)
                .ForeignKey("dbo.InvoiceOutHead", t => t.HeadId, cascadeDelete: true)
                .Index(t => t.HeadId)
                .Index(t => t.Good_Id);
            
            CreateTable(
                "dbo.MoneyTransferHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SummOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SummIn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Commited = c.Boolean(nullable: false),
                        Marked = c.Boolean(nullable: false),
                        AccountIn_Id = c.Int(),
                        AccountOut_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoneyAccount", t => t.AccountIn_Id)
                .ForeignKey("dbo.MoneyAccount", t => t.AccountOut_Id)
                .Index(t => t.AccountIn_Id)
                .Index(t => t.AccountOut_Id);
            
            CreateTable(
                "dbo.PaymentInHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Summ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Commited = c.Boolean(nullable: false),
                        Marked = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Contract_Id = c.Int(),
                        Contragent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoneyAccount", t => t.Account_Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .ForeignKey("dbo.Contragents", t => t.Contragent_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Contract_Id)
                .Index(t => t.Contragent_Id);
            
            CreateTable(
                "dbo.PaymentOutHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Summ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Commited = c.Boolean(nullable: false),
                        Marked = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Contract_Id = c.Int(),
                        Contragent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoneyAccount", t => t.Account_Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .ForeignKey("dbo.Contragents", t => t.Contragent_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Contract_Id)
                .Index(t => t.Contragent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentOutHead", "Contragent_Id", "dbo.Contragents");
            DropForeignKey("dbo.PaymentOutHead", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.PaymentOutHead", "Account_Id", "dbo.MoneyAccount");
            DropForeignKey("dbo.PaymentInHead", "Contragent_Id", "dbo.Contragents");
            DropForeignKey("dbo.PaymentInHead", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.PaymentInHead", "Account_Id", "dbo.MoneyAccount");
            DropForeignKey("dbo.MoneyTransferHead", "AccountOut_Id", "dbo.MoneyAccount");
            DropForeignKey("dbo.MoneyTransferHead", "AccountIn_Id", "dbo.MoneyAccount");
            DropForeignKey("dbo.InvoiceOutRow", "HeadId", "dbo.InvoiceOutHead");
            DropForeignKey("dbo.InvoiceOutRow", "Good_Id", "dbo.Good");
            DropForeignKey("dbo.InvoiceOutHead", "Contragent_Id", "dbo.Contragents");
            DropForeignKey("dbo.InvoiceOutHead", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "Contragent_Id", "dbo.Contragents");
            DropForeignKey("dbo.InvoiceInRow", "HeadId", "dbo.InvoiceInHead");
            DropForeignKey("dbo.Good", "RevenueItemId", "dbo.RevenueItem");
            DropForeignKey("dbo.Good", "ExpenseItemId", "dbo.ExpenseItem");
            DropForeignKey("dbo.MoneyAccount", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.PaymentOutHead", new[] { "Contragent_Id" });
            DropIndex("dbo.PaymentOutHead", new[] { "Contract_Id" });
            DropIndex("dbo.PaymentOutHead", new[] { "Account_Id" });
            DropIndex("dbo.PaymentInHead", new[] { "Contragent_Id" });
            DropIndex("dbo.PaymentInHead", new[] { "Contract_Id" });
            DropIndex("dbo.PaymentInHead", new[] { "Account_Id" });
            DropIndex("dbo.MoneyTransferHead", new[] { "AccountOut_Id" });
            DropIndex("dbo.MoneyTransferHead", new[] { "AccountIn_Id" });
            DropIndex("dbo.InvoiceOutRow", new[] { "Good_Id" });
            DropIndex("dbo.InvoiceOutRow", new[] { "HeadId" });
            DropIndex("dbo.Contracts", new[] { "Contragent_Id" });
            DropIndex("dbo.InvoiceOutHead", new[] { "Contragent_Id" });
            DropIndex("dbo.InvoiceOutHead", new[] { "Contract_Id" });
            DropIndex("dbo.InvoiceInRow", new[] { "HeadId" });
            DropIndex("dbo.Good", new[] { "ExpenseItemId" });
            DropIndex("dbo.Good", new[] { "RevenueItemId" });
            DropIndex("dbo.MoneyAccount", new[] { "CurrencyId" });
            DropTable("dbo.PaymentOutHead");
            DropTable("dbo.PaymentInHead");
            DropTable("dbo.MoneyTransferHead");
            DropTable("dbo.InvoiceOutRow");
            DropTable("dbo.Contragents");
            DropTable("dbo.Contracts");
            DropTable("dbo.InvoiceOutHead");
            DropTable("dbo.InvoiceInRow");
            DropTable("dbo.InvoiceInHead");
            DropTable("dbo.RevenueItem");
            DropTable("dbo.Good");
            DropTable("dbo.ExpenseItem");
            DropTable("dbo.MoneyAccount");
            DropTable("dbo.Currency");
        }
    }
}
