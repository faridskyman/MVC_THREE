namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFeedbackType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO FeedbackTypes (Name, ManagedBy, ManagedByEmail) VALUES ('General','Helpdesk','helpdesk@skylabs.com')");
            Sql("INSERT INTO FeedbackTypes (Name, ManagedBy, ManagedByEmail) VALUES ('MobileApp','MobileDev','mobile@skylabs.com')");
            Sql("INSERT INTO FeedbackTypes (Name, ManagedBy, ManagedByEmail) VALUES ('WebApp','WebAppDev','webappdev@skylabs.com')");
            Sql("INSERT INTO FeedbackTypes (Name, ManagedBy, ManagedByEmail) VALUES ('Products','Sales','sales@skylabs.com')");
    }
        
        public override void Down()
        {
        }
    }
}
