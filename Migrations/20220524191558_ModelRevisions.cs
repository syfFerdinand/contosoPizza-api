using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contosoPizza.Migrations
{
    public partial class ModelRevisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Toppings_ToppingId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "ToppingId",
                table: "Pizzas",
                newName: "SauceId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_ToppingId",
                table: "Pizzas",
                newName: "IX_Pizzas_SauceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pizzas",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzasId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToppingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzasId, x.ToppingsId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingsId",
                        column: x => x.ToppingsId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingsId",
                table: "PizzaTopping",
                column: "ToppingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.RenameColumn(
                name: "SauceId",
                table: "Pizzas",
                newName: "ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_SauceId",
                table: "Pizzas",
                newName: "IX_Pizzas_ToppingId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pizzas",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlutenFree",
                table: "Pizzas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingId",
                table: "Pizzas",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id");
        }
    }
}
