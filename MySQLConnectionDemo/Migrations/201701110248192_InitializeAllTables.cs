namespace MySQLConnectionDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Narackas",
                c => new
                    {
                        NarackaId = c.Int(nullable: false, identity: true),
                        Kolicina = c.Double(nullable: false),
                        Kupeno = c.Int(nullable: false),
                        PratkaId = c.Int(),
                        ProduktId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.NarackaId)
                .ForeignKey("dbo.Pratkas", t => t.PratkaId)
                .ForeignKey("dbo.Produkts", t => t.ProduktId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.PratkaId)
                .Index(t => t.ProduktId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Pratkas",
                c => new
                    {
                        PratkaId = c.Int(nullable: false, identity: true),
                        PratkaIme = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PratkaId);
            
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        ProduktId = c.Int(nullable: false, identity: true),
                        Ime = c.String(unicode: false),
                        SlikaIme = c.String(unicode: false),
                        Cena = c.Double(nullable: false),
                        Popust = c.Double(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduktId)
                .ForeignKey("dbo.Tips", t => t.TipId, cascadeDelete: true)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        TipId = c.Int(nullable: false, identity: true),
                        Ime = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.TipId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserName = c.String(nullable: false, unicode: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                        User_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Narackas", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Produkts", "TipId", "dbo.Tips");
            DropForeignKey("dbo.Narackas", "ProduktId", "dbo.Produkts");
            DropForeignKey("dbo.Narackas", "PratkaId", "dbo.Pratkas");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Produkts", new[] { "TipId" });
            DropIndex("dbo.Narackas", new[] { "ApplicationUserId" });
            DropIndex("dbo.Narackas", new[] { "ProduktId" });
            DropIndex("dbo.Narackas", new[] { "PratkaId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tips");
            DropTable("dbo.Produkts");
            DropTable("dbo.Pratkas");
            DropTable("dbo.Narackas");
        }
    }
}
