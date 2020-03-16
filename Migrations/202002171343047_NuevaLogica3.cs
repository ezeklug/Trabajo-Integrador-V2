namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaLogica3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Examen", "TiempoLimite");
        }
        
        public override void Down()
        {
            AddColumn("public.Examen", "TiempoLimite", c => c.Single(nullable: false));
        }
    }
}
