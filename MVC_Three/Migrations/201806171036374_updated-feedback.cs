namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedfeedback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "FeedbackTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "FeedbackTypeId");
            AddForeignKey("dbo.Feedbacks", "FeedbackTypeId", "dbo.FeedbackTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Feedbacks", "FeedbackType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "FeedbackType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Feedbacks", "FeedbackTypeId", "dbo.FeedbackTypes");
            DropIndex("dbo.Feedbacks", new[] { "FeedbackTypeId" });
            DropColumn("dbo.Feedbacks", "FeedbackTypeId");
        }
    }
}
