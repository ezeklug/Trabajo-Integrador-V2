namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaLogica2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Examen", "CantidadPreguntas");
        }
        
        public override void Down()
        {
            AddColumn("public.Examen", "CantidadPreguntas", c => c.Int(nullable: false));
        }
    }
}
