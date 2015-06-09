namespace Root.Infrastructure.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "Phonetic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "Phonetic");
        }
    }
}
