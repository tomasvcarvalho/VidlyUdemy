namespace VidlySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Free' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go1' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go2' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go3' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
