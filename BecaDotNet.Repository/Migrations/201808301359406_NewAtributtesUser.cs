namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAtributtesUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_USER", "CurrentProjectId", c => c.Int());
            CreateIndex("dbo.TB_USER", "CurrentProjectId");
            AddForeignKey("dbo.TB_USER", "CurrentProjectId", "dbo.TB_PROJECT", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER", "CurrentProjectId", "dbo.TB_PROJECT");
            DropIndex("dbo.TB_USER", new[] { "CurrentProjectId" });
            DropColumn("dbo.TB_USER", "CurrentProjectId");
        }
    }
}
