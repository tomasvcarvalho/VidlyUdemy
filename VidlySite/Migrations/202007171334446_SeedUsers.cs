namespace VidlySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'747926e2-8eb6-4267-8da2-11c76fb7f5ce', N'guest@vidly.com', 0, N'AM71Ihl/eEPnO2yyd7FOw+6nPRaAVjuh39rsutUfc6GDmGf15If8vhFNlA1WxDgTMg==', N'e899c915-706d-4df3-9d19-42b6aab1d55b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd06da19f-8011-4934-a26f-c22b75f8d409', N'admin@vidly.com', 0, N'AAJxvZ5TAri2TzkWY7UjKLiPARfcZBgfAY5c1UoTjU6i21MVB3NSGxQvP3+yIVizdw==', N'd636e7af-3bd4-4058-8d87-eff14e63c6bb', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68c8098d-5ccd-4dcf-a40f-f34c4ea19544', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd06da19f-8011-4934-a26f-c22b75f8d409', N'68c8098d-5ccd-4dcf-a40f-f34c4ea19544')
");

        }

        public override void Down()
        {
        }
    }
}
