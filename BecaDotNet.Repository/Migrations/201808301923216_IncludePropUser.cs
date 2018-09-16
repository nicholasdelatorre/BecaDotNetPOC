namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludePropUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_USER", name: "CurrentProjectId", newName: "CURRENT_PROJECT_ID");
            RenameIndex(table: "dbo.TB_USER", name: "IX_CurrentProjectId", newName: "IX_CURRENT_PROJECT_ID");
            CreateIndex("dbo.TB_USER", "SUPERIOR_ID");
            AddForeignKey("dbo.TB_USER", "SUPERIOR_ID", "dbo.TB_USER", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER", "SUPERIOR_ID", "dbo.TB_USER");
            DropIndex("dbo.TB_USER", new[] { "SUPERIOR_ID" });
            RenameIndex(table: "dbo.TB_USER", name: "IX_CURRENT_PROJECT_ID", newName: "IX_CurrentProjectId");
            RenameColumn(table: "dbo.TB_USER", name: "CURRENT_PROJECT_ID", newName: "CurrentProjectId");
        }
    }
}
