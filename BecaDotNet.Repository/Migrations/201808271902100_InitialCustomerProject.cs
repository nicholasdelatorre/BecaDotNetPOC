namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCustomerProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_CUSTOMER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FULL_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        CNPJ = c.Long(nullable: false),
                        CONTACT_NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_PROJECT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PROJECT_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(),
                        CLIENT_ID = c.Int(nullable: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_CUSTOMER", t => t.CLIENT_ID)
                .Index(t => t.CLIENT_ID);
            
            CreateTable(
                "dbo.TB_PROJECT_USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        PROJECT_ID = c.Int(nullable: false),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(nullable: false),
                        RESPONSIBLE = c.String(nullable: false, maxLength: 200, unicode: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_PROJECT", t => t.PROJECT_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_USER", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.USER_ID)
                .Index(t => t.PROJECT_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PROJECT_USER", "USER_ID", "dbo.TB_USER");
            DropForeignKey("dbo.TB_PROJECT_USER", "PROJECT_ID", "dbo.TB_PROJECT");
            DropForeignKey("dbo.TB_PROJECT", "CLIENT_ID", "dbo.TB_CUSTOMER");
            DropIndex("dbo.TB_PROJECT_USER", new[] { "PROJECT_ID" });
            DropIndex("dbo.TB_PROJECT_USER", new[] { "USER_ID" });
            DropIndex("dbo.TB_PROJECT", new[] { "CLIENT_ID" });
            DropTable("dbo.TB_PROJECT_USER");
            DropTable("dbo.TB_PROJECT");
            DropTable("dbo.TB_CUSTOMER");
        }
    }
}
