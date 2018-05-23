namespace BestFriendFinder2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingQuestionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Selection", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Selection");
        }
    }
}
