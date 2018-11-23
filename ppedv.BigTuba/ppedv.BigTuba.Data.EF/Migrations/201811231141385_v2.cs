namespace ppedv.BigTuba.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teilnehmers", name: "Name", newName: "DerNameDesTN");
            AddColumn("dbo.Kurs", "Level2", c => c.Int(nullable: false));
            AlterColumn("dbo.Teilnehmers", "DerNameDesTN", c => c.String(nullable: false, maxLength: 987));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teilnehmers", "DerNameDesTN", c => c.String());
            DropColumn("dbo.Kurs", "Level2");
            RenameColumn(table: "dbo.Teilnehmers", name: "DerNameDesTN", newName: "Name");
        }
    }
}
