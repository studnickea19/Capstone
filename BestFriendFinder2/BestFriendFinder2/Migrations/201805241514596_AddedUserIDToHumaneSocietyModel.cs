namespace BestFriendFinder2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDToHumaneSocietyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HumaneSocieties", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HumaneSocieties", "UserID");
        }
    }
}
