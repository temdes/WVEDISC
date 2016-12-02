namespace WVEDISC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDiscussionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        WorkUnit = c.String(),
                        MyDiscussion_Id = c.Int(),
                        Originator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyDiscussions", t => t.MyDiscussion_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Originator_Id)
                .Index(t => t.MyDiscussion_Id)
                .Index(t => t.Originator_Id);
            
            CreateTable(
                "dbo.MyDiscussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussions", "Originator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "MyDiscussion_Id", "dbo.MyDiscussions");
            DropIndex("dbo.Discussions", new[] { "Originator_Id" });
            DropIndex("dbo.Discussions", new[] { "MyDiscussion_Id" });
            DropTable("dbo.MyDiscussions");
            DropTable("dbo.Discussions");
        }
    }
}
