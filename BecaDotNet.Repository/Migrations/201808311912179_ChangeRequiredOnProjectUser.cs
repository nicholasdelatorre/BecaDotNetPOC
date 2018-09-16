namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRequiredOnProjectUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_PROJECT_USER", "END_DATE", c => c.DateTime());
            AlterColumn("dbo.TB_PROJECT_USER", "RESPONSIBLE", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_PROJECT_USER", "RESPONSIBLE", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.TB_PROJECT_USER", "END_DATE", c => c.DateTime(nullable: false));
        }
    }
}
