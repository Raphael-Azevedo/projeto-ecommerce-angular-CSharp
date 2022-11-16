using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO `sanclerdb`.`aspnetusers` (`Id`,`UserName`,`NormalizedUserName`,`Email`,`NormalizedEmail`,`EmailConfirmed`,`PasswordHash`,`SecurityStamp`,`ConcurrencyStamp`,`PhoneNumber`,`PhoneNumberConfirmed`,`TwoFactorEnabled`,`LockoutEnd`,`LockoutEnabled`,`AccessFailedCount`) VALUES ('a1cf9047-8e65-4808-a651-d15c059019c6','usuario@gft.com','USUARIO@GFT.COM','usuario@gft.com','USUARIO@GFT.COM',1,'AQAAAAEAACcQAAAAEMI10dZ7KKE+gPT/ITRlTtUXZwKXu8EQ/NvD7NsgbLQxNzW2523tmiLM5XW9VSiPQQ==','GO4KH6573HPWSEESE5ODDCFL3DKGMXXS','a4547d3b-ef1c-4059-a883-d4e35745bf29',NULL,0,0,NULL,1,0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
