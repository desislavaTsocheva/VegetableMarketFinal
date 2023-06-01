namespace Desislava_11d_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Greens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vegetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VegetableTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.VegetableTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vegetables", "TypeId", "dbo.VegetableTypes");
            DropIndex("dbo.Vegetables", new[] { "TypeId" });
            DropTable("dbo.VegetableTypes");
            DropTable("dbo.Vegetables");
        }
    }
}
