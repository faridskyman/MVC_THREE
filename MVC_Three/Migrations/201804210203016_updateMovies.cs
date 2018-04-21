namespace MVC_Three.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Movies] ON");
            Sql("INSERT INTO[dbo].[Movies]([Id], [Name]) VALUES(1, N'Star Wars The Force Awakens')");
            Sql("INSERT INTO[dbo].[Movies]([Id], [Name]) VALUES(2, N'Star Wars The Last Jedi')");
            Sql("INSERT INTO[dbo].[Movies] ([Id], [Name]) VALUES(3, N'Avengers')");
            Sql("INSERT INTO[dbo].[Movies] ([Id], [Name]) VALUES(4, N'Avengers Age Of Ultron')");
            Sql("INSERT INTO[dbo].[Movies] ([Id], [Name]) VALUES(5, N'Avengers Infinity Wars')");
            Sql("SET IDENTITY_INSERT[dbo].[Movies] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
