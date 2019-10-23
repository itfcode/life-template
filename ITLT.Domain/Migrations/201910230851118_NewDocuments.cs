namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDocuments : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MoneyAccount", new[] { "CurrencyId" });
            CreateTable(
                "dbo.InvoiceInHead",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceInRow",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
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
                        DateStart = c.DateTime(nullable: false),
                        DateFinish = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Contraget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contragents", t => t.Contraget_Id)
                .Index(t => t.Contraget_Id);
            
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
            
            AlterColumn("dbo.Currency", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MoneyAccount", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.MoneyAccount", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenseItem", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Good", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RevenueItem", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.MoneyAccount", "CurrencyId");
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
            DropForeignKey("dbo.Contracts", "Contraget_Id", "dbo.Contragents");
            DropForeignKey("dbo.InvoiceInRow", "HeadId", "dbo.InvoiceInHead");
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
            DropIndex("dbo.Contracts", new[] { "Contraget_Id" });
            DropIndex("dbo.InvoiceOutHead", new[] { "Contragent_Id" });
            DropIndex("dbo.InvoiceOutHead", new[] { "Contract_Id" });
            DropIndex("dbo.InvoiceInRow", new[] { "HeadId" });
            DropIndex("dbo.MoneyAccount", new[] { "CurrencyId" });
            AlterColumn("dbo.RevenueItem", "Name", c => c.String());
            AlterColumn("dbo.Good", "Name", c => c.String());
            AlterColumn("dbo.ExpenseItem", "Name", c => c.String());
            AlterColumn("dbo.MoneyAccount", "Name", c => c.String());
            AlterColumn("dbo.MoneyAccount", "CurrencyId", c => c.Int());
            AlterColumn("dbo.Currency", "Name", c => c.String());
            DropTable("dbo.PaymentOutHead");
            DropTable("dbo.PaymentInHead");
            DropTable("dbo.MoneyTransferHead");
            DropTable("dbo.InvoiceOutRow");
            DropTable("dbo.Contragents");
            DropTable("dbo.Contracts");
            DropTable("dbo.InvoiceOutHead");
            DropTable("dbo.InvoiceInRow");
            DropTable("dbo.InvoiceInHead");
            CreateIndex("dbo.MoneyAccount", "CurrencyId");
        }
    }
}
