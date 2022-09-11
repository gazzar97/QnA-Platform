using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA_Platform.Persistence.Migrations
{
    public partial class addUserTablewithSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Password" },
                values: new object[,]
                {
                    { "user1", "123" },
                    { "user2", "123" },
                    { "user3", "123" },
                    { "user4", "123" },
                    { "user5", "123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
