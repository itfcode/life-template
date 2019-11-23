namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDocuments : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contracts", name: "Contraget_Id", newName: "Contragent_Id");
            RenameIndex(table: "dbo.Contracts", name: "IX_Contraget_Id", newName: "IX_Contragent_Id");
            AddColumn("dbo.InvoiceInHead", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceInHead", "Marked", c => c.Boolean(nullable: false));
            AddColumn("dbo.InvoiceInRow", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceInRow", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceInRow", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceOutHead", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceOutHead", "Marked", c => c.Boolean(nullable: false));
            AddColumn("dbo.InvoiceOutRow", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceOutRow", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceOutRow", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MoneyTransferHead", "Marked", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentInHead", "Marked", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentOutHead", "Marked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contracts", "DateStart", c => c.DateTime());
            AlterColumn("dbo.Contracts", "DateFinish", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "DateFinish", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contracts", "DateStart", c => c.DateTime(nullable: false));
            DropColumn("dbo.PaymentOutHead", "Marked");
            DropColumn("dbo.PaymentInHead", "Marked");
            DropColumn("dbo.MoneyTransferHead", "Marked");
            DropColumn("dbo.InvoiceOutRow", "Amount");
            DropColumn("dbo.InvoiceOutRow", "Price");
            DropColumn("dbo.InvoiceOutRow", "Quantity");
            DropColumn("dbo.InvoiceOutHead", "Marked");
            DropColumn("dbo.InvoiceOutHead", "Total");
            DropColumn("dbo.InvoiceInRow", "Amount");
            DropColumn("dbo.InvoiceInRow", "Price");
            DropColumn("dbo.InvoiceInRow", "Quantity");
            DropColumn("dbo.InvoiceInHead", "Marked");
            DropColumn("dbo.InvoiceInHead", "Total");
            RenameIndex(table: "dbo.Contracts", name: "IX_Contragent_Id", newName: "IX_Contraget_Id");
            RenameColumn(table: "dbo.Contracts", name: "Contragent_Id", newName: "Contraget_Id");
        }
    }
}
