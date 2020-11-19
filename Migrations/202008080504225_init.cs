namespace ReservationProjectMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogic",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.TblBookInfo",
                c => new
                    {
                        BId = c.Int(nullable: false, identity: true),
                        bPassName = c.String(nullable: false),
                        bPassAddress = c.String(nullable: false),
                        bPassEmail = c.String(nullable: false),
                        bPassSeats = c.Int(nullable: false),
                        bPassPhone = c.String(nullable: false),
                        bPassNid = c.String(nullable: false),
                        ResId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BId)
                .ForeignKey("dbo.TblTicketReserves", t => t.ResId, cascadeDelete: true)
                .Index(t => t.ResId);
            
            CreateTable(
                "dbo.TblTicketReserves",
                c => new
                    {
                        ResId = c.Int(nullable: false, identity: true),
                        ResFrom = c.String(nullable: false),
                        ResTo = c.String(nullable: false),
                        ResDate = c.String(),
                        DepTime = c.String(maxLength: 15),
                        TrainId = c.Int(nullable: false),
                        TrainSeat = c.Int(nullable: false),
                        ResTicketPrice = c.Single(nullable: false),
                        ResPlaneType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.TrainInfoes", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.TrainId);
            
            CreateTable(
                "dbo.TrainInfoes",
                c => new
                    {
                        TrainId = c.Int(nullable: false, identity: true),
                        TrainName = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TrainId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        Phoneno = c.String(nullable: false, maxLength: 11),
                        NID = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TblTicketReserves", "TrainId", "dbo.TrainInfoes");
            DropForeignKey("dbo.TblBookInfo", "ResId", "dbo.TblTicketReserves");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TblTicketReserves", new[] { "TrainId" });
            DropIndex("dbo.TblBookInfo", new[] { "ResId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrainInfoes");
            DropTable("dbo.TblTicketReserves");
            DropTable("dbo.TblBookInfo");
            DropTable("dbo.TblAdminLogic");
        }
    }
}
