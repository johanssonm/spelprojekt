namespace Ef6Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Identities", t => t.Identity_Id)
                .Index(t => t.Identity_Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Identities", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "Identity_Id", "dbo.Identities");
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "Identity_Id" });
            DropIndex("dbo.Identities", new[] { "PlayerId" });
            DropTable("dbo.Scores");
            DropTable("dbo.Players");
            DropTable("dbo.Identities");
        }
    }
}
