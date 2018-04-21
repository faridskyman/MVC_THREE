namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
