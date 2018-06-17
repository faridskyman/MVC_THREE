namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeedbackTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedbackTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManagedBy = c.String(),
                        ManagedByEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeedbackTypes");
        }
    }
}
