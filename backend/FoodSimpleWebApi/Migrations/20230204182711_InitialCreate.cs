using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodSimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Difficult = table.Column<int>(type: "int", nullable: false),
                    UserDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    RecipeDtoId = table.Column<int>(type: "int", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Recipes_RecipeDtoId",
                        column: x => x.RecipeDtoId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "TNRPUPE@gmail.com", "KCILPNH", "UGTJHS" },
                    { 2, "RCBPPAA@gmail.com", "IHVCQFN", "CPVWAR" },
                    { 3, "YQDFDKC@gmail.com", "JSXQUBP", "OBVPAI" },
                    { 4, "VQSGLBW@gmail.com", "CBTIPLM", "PEHGNV" },
                    { 5, "MQYDHSE@gmail.com", "WOIQCMA", "FGWXNR" },
                    { 6, "QLGVTIO@gmail.com", "MOXEEDH", "TARTXN" },
                    { 7, "LSVARLX@gmail.com", "KDRMZYM", "GVELVB" },
                    { 8, "GLXXRWF@gmail.com", "LKAFXLJ", "LVMCTZ" },
                    { 9, "NXIAQYE@gmail.com", "YAGEGZX", "KGJZBN" },
                    { 10, "FIUAHON@gmail.com", "GHZZRIS", "TDRHVV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeDtoId",
                table: "Products",
                column: "RecipeDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDtoId",
                table: "Products",
                column: "UserDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserDtoId",
                table: "Recipes",
                column: "UserDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
