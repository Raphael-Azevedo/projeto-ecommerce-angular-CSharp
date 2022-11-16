using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class PopuleProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products` (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (4,'Calça pantalona xadrez','calça justa, linho fino coloração em xadrez ','SKU00001',100.00,1)");
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products`  (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (5,'Blusa Gola Alta','Suétter, linho fino, em varias colorações','SKU00002',50.00,1)");
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products`  (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (6,'Short Listrado social','Short justo, tecido leve e fino, em varias colorações','SKU00003',70.00,1)");
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products`  (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (7,'Macacão Animal Print','Tecido leve e fino, em varias colorações','SKU00004',80.00,1)");
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products`  (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (8,'Vestido Longo florido','Tecido leve e fino, semi transparente, forrado e em varias colorações','SKU00005',80.00,1)");
            migrationBuilder.Sql("INSERT INTO `sanclerdb`.`products`  (`Id`,`Title`,`Descriptions`,`SKU`,`Price`,`Status`) VALUES (9,'Blusa De Alça Viscose','Tecido Viscose, alça fina em varias colorações','SKU00006',80.00,1)");

        }  

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
