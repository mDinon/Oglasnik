namespace Oglasnik.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToAdsFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "User_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ads", "User_ID");
            AddForeignKey("dbo.Ads", "User_ID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "User_ID", "dbo.AspNetUsers");
            DropIndex("dbo.Ads", new[] { "User_ID" });
            DropColumn("dbo.Ads", "User_ID");
        }
    }
}
