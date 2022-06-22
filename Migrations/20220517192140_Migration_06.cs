using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Migration_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Category] 
            VALUES ('Celulares e SmartPhones','001',1)
            
            GO

            INSERT INTO [dbo].[Products]
            VALUES (1,'iPhone XR Apple 128GB',3999.00,'https://imgs.extra.com.br/15253179/1xg.jpg?imwidth=500'),
		    (4,'Smartphone Motorola Moto G60 Azul 128GB, 6GB RAM',1799.10 ,'https://imgs.extra.com.br/55022927/1xg.jpg?imwidth=500')
            GO
            "); 

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
