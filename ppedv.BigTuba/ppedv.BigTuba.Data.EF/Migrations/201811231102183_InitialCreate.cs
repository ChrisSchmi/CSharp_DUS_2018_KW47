namespace ppedv.BigTuba.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Beschreibung = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teilnehmers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GebDatum = c.DateTime(nullable: false),
                        Firma = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeilnehmerKurs",
                c => new
                    {
                        Teilnehmer_Id = c.Int(nullable: false),
                        Kurs_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teilnehmer_Id, t.Kurs_Id })
                .ForeignKey("dbo.Teilnehmers", t => t.Teilnehmer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kurs", t => t.Kurs_Id, cascadeDelete: true)
                .Index(t => t.Teilnehmer_Id)
                .Index(t => t.Kurs_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeilnehmerKurs", "Kurs_Id", "dbo.Kurs");
            DropForeignKey("dbo.TeilnehmerKurs", "Teilnehmer_Id", "dbo.Teilnehmers");
            DropIndex("dbo.TeilnehmerKurs", new[] { "Kurs_Id" });
            DropIndex("dbo.TeilnehmerKurs", new[] { "Teilnehmer_Id" });
            DropTable("dbo.TeilnehmerKurs");
            DropTable("dbo.Teilnehmers");
            DropTable("dbo.Kurs");
        }
    }
}
