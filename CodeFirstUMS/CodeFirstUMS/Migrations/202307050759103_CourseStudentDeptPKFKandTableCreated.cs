namespace CodeFirstUMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseStudentDeptPKFKandTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        OfferedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.OfferedBy, cascadeDelete: true)
                .Index(t => t.OfferedBy);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OfferedBy", "dbo.Departments");
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
            DropIndex("dbo.Courses", new[] { "OfferedBy" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
