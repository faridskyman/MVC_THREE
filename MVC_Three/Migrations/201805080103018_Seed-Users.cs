namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'53076be7-2768-41f1-8965-9161805edb11', N'guest@videorents.com', 0, N'AEX7wtm7Y37yKKQ3Q86laEuj3YMF8Ra4d7+y5CEGqXmXZyIyzsMtEeM4OVsPg1pwGw==', N'a66ea342-5530-4830-b651-e7bc32a7c1bc', NULL, 0, 0, NULL, 1, 0, N'guest@videorents.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e60f8af-25a1-4b67-ae74-fd981b447973', N'admin@videorent.com', 0, N'AG6rGBKQFrB5ju63/W0/aMPQmcQjMxkS+0AuKSPfP5J/E+qS3mPAJ3bB7kCIqrMX3w==', N'bba84fec-f5a5-47a0-8172-f0cf72779f84', NULL, 0, 0, NULL, 1, 0, N'admin@videorent.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'edb0853d-b317-422f-bfae-857897228590', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e60f8af-25a1-4b67-ae74-fd981b447973', N'edb0853d-b317-422f-bfae-857897228590')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
