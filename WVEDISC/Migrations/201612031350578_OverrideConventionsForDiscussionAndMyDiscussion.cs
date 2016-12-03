namespace WVEDISC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForDiscussionAndMyDiscussion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discussions", "MyDiscussion_Id", "dbo.MyDiscussions");
            DropForeignKey("dbo.Discussions", "Originator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Discussions", new[] { "MyDiscussion_Id" });
            DropIndex("dbo.Discussions", new[] { "Originator_Id" });
            AlterColumn("dbo.Discussions", "WorkUnit", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Discussions", "MyDiscussion_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Discussions", "Originator_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MyDiscussions", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.MyDiscussions", "Detail", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Discussions", "MyDiscussion_Id");
            CreateIndex("dbo.Discussions", "Originator_Id");
            AddForeignKey("dbo.Discussions", "MyDiscussion_Id", "dbo.MyDiscussions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Discussions", "Originator_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussions", "Originator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "MyDiscussion_Id", "dbo.MyDiscussions");
            DropIndex("dbo.Discussions", new[] { "Originator_Id" });
            DropIndex("dbo.Discussions", new[] { "MyDiscussion_Id" });
            AlterColumn("dbo.MyDiscussions", "Detail", c => c.String());
            AlterColumn("dbo.MyDiscussions", "Title", c => c.String());
            AlterColumn("dbo.Discussions", "Originator_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Discussions", "MyDiscussion_Id", c => c.Int());
            AlterColumn("dbo.Discussions", "WorkUnit", c => c.String());
            CreateIndex("dbo.Discussions", "Originator_Id");
            CreateIndex("dbo.Discussions", "MyDiscussion_Id");
            AddForeignKey("dbo.Discussions", "Originator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Discussions", "MyDiscussion_Id", "dbo.MyDiscussions", "Id");
        }
    }
}
