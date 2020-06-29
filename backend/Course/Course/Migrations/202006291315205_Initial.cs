namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duur = c.Int(nullable: false),
                        Titel = c.String(nullable: false, maxLength: 300),
                        Code = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.CursusInstanties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDatum = c.DateTime(nullable: false),
                        CursusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursus", t => t.CursusId, cascadeDelete: true)
                .Index(t => t.CursusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursusInstanties", "CursusId", "dbo.Cursus");
            DropIndex("dbo.CursusInstanties", new[] { "CursusId" });
            DropIndex("dbo.Cursus", new[] { "Code" });
            DropTable("dbo.CursusInstanties");
            DropTable("dbo.Cursus");
        }
    }
}
