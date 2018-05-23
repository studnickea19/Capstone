namespace BestFriendFinder2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UserID");
        }
    }
}
