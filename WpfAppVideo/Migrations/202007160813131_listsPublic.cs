namespace WpfAppVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listsPublic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UtilisateurRoles",
                c => new
                    {
                        Utilisateur_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Utilisateur_Id, t.Role_Id })
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Utilisateur_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UtilisateurRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UtilisateurRoles", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.UtilisateurRoles", new[] { "Role_Id" });
            DropIndex("dbo.UtilisateurRoles", new[] { "Utilisateur_Id" });
            DropTable("dbo.UtilisateurRoles");
        }
    }
}
