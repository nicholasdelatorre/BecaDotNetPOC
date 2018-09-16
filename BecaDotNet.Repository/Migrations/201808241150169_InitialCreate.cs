namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FULL_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        EMAIL = c.String(nullable: false, maxLength: 200, unicode: false),
                        LOGIN = c.String(nullable: false, maxLength: 100, unicode: false),
                        PASSWORD = c.String(nullable: false, maxLength: 150, unicode: false),
                        REGISTER_DATE = c.DateTime(nullable: false),
                        USER_TYPE_ID = c.Int(nullable: false),
                        SUPERIOR_ID = c.Int(),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_USER_TYPE", t => t.USER_TYPE_ID, cascadeDelete: true)
                .Index(t => t.USER_TYPE_ID);
            
            CreateTable(
                "dbo.TB_USER_TYPE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DESC_USER_TYPE = c.String(nullable: false, maxLength: 200, unicode: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_USER_TYPE_USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        USER_TYPE_ID = c.Int(nullable: false),
                        CREATED_DATE = c.DateTime(nullable: false),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER", "USER_TYPE_ID", "dbo.TB_USER_TYPE");
            DropIndex("dbo.TB_USER", new[] { "USER_TYPE_ID" });
            DropTable("dbo.TB_USER_TYPE_USER");
            DropTable("dbo.TB_USER_TYPE");
            DropTable("dbo.TB_USER");
        }
    }
}
