namespace MiniQM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates");
            DropIndex("dbo.Criteria", new[] { "CertificateId" });
            AlterColumn("dbo.Criteria", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Criteria", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Criteria", "CertificateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Criteria", "Contrafactor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Criteria", "AQL", c => c.Int(nullable: false));
            AlterColumn("dbo.Criteria", "Description", c => c.String(maxLength: 4000));
            CreateIndex("dbo.Criteria", "CertificateId");
            AddForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates");
            DropIndex("dbo.Criteria", new[] { "CertificateId" });
            AlterColumn("dbo.Criteria", "Description", c => c.String());
            AlterColumn("dbo.Criteria", "AQL", c => c.Int());
            AlterColumn("dbo.Criteria", "Contrafactor", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Criteria", "CertificateId", c => c.Int());
            AlterColumn("dbo.Criteria", "Level", c => c.Int());
            AlterColumn("dbo.Criteria", "Name", c => c.String());
            CreateIndex("dbo.Criteria", "CertificateId");
            AddForeignKey("dbo.Criteria", "CertificateId", "dbo.Certificates", "Id");
        }
    }
}
