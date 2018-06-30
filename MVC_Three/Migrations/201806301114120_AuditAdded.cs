namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditEventId = c.Int(nullable: false),
                        AdditionalInfo = c.String(),
                        UserID = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}
