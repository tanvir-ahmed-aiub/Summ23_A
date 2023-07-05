namespace CodeFirstUMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseStudentRelationandTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SId = c.Int(nullable: false),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.SId, cascadeDelete: false)
                .Index(t => t.SId)
                .Index(t => t.CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseStudents", "SId", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "CId", "dbo.Courses");
            DropIndex("dbo.CourseStudents", new[] { "CId" });
            DropIndex("dbo.CourseStudents", new[] { "SId" });
            DropTable("dbo.CourseStudents");
        }
    }
}
