using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class PopuleInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (1,4,2,5)");
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (2,5,3,6)");
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (3,6,4,0)");
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (4,7,1,2)");
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (5,8,2,10)");
           migrationBuilder.Sql("INSERT INTO `sanclerdb`.`inventorys` (`Id`,`ProductId`,`Size`,`Amount`) VALUES (6,9,2,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
