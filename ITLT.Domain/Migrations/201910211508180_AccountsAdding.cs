namespace ITLT.Domain.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class AccountsAdding : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[Currency]([Code],[ShortName],[Name],[Description])
                    VALUES
                        ('980','UAH','Гривня',''),
                        ('840','USD','Доллар США',''),
                        ('978','EUR','Евро',''),
                        ('826','GBP','Фунт стерлингов',''),
                        ('643','RUR','Российский рубль','')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
