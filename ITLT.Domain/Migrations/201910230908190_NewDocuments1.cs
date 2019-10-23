namespace ITLT.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDocuments1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceInHead", "Commited", c => c.Boolean(nullable: false));
            AddColumn("dbo.InvoiceOutHead", "Commited", c => c.Boolean(nullable: false));
            AddColumn("dbo.MoneyTransferHead", "Commited", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentInHead", "Commited", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentOutHead", "Commited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentOutHead", "Commited");
            DropColumn("dbo.PaymentInHead", "Commited");
            DropColumn("dbo.MoneyTransferHead", "Commited");
            DropColumn("dbo.InvoiceOutHead", "Commited");
            DropColumn("dbo.InvoiceInHead", "Commited");
        }
    }
}
