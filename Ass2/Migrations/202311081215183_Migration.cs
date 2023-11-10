namespace Ass2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Characters", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Characters", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Characters", "Description", c => c.String());
            AlterColumn("dbo.Characters", "Name", c => c.String());
        }
    }
}
