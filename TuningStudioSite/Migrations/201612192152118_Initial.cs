namespace TuningStudioSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Car = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IdClient = c.Int(nullable: false),
                        IdMaster = c.Int(nullable: false),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.IdMaster, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .Index(t => t.IdClient)
                .Index(t => t.IdMaster);
            
            CreateTable(
                "dbo.DetailTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDetail = c.Int(nullable: false),
                        IdTask = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.IdDetail, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.IdTask, cascadeDelete: true)
                .Index(t => t.IdDetail)
                .Index(t => t.IdTask);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSupplier = c.Int(nullable: false),
                        NameDetail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.IdSupplier, cascadeDelete: true)
                .Index(t => t.IdSupplier);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Fax = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        SiteCatalog = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Tasks", "IdMaster", "dbo.Masters");
            DropForeignKey("dbo.DetailTasks", "IdTask", "dbo.Tasks");
            DropForeignKey("dbo.Details", "IdSupplier", "dbo.Suppliers");
            DropForeignKey("dbo.DetailTasks", "IdDetail", "dbo.Details");
            DropIndex("dbo.Details", new[] { "IdSupplier" });
            DropIndex("dbo.DetailTasks", new[] { "IdTask" });
            DropIndex("dbo.DetailTasks", new[] { "IdDetail" });
            DropIndex("dbo.Tasks", new[] { "IdMaster" });
            DropIndex("dbo.Tasks", new[] { "IdClient" });
            DropTable("dbo.Masters");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Details");
            DropTable("dbo.DetailTasks");
            DropTable("dbo.Tasks");
            DropTable("dbo.Clients");
        }
    }
}
