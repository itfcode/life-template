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
                        ('980','UAH','������',''),
                        ('840','USD','������ ���',''),
                        ('978','EUR','����',''),
                        ('826','GBP','���� ����������',''),
                        ('643','RUR','���������� �����','')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
