using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToInternetRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Before :
            // migrationBuilder.DropColumn(
            //     name: "ImdbRating",
            //     table: "Pictures");
            //
            // migrationBuilder.AddColumn<decimal>(
            //     name: "InternetRating",
            //     table: "Pictures",
            //     type: "decimal(18,2)",
            //     nullable: false,
            //     defaultValue: 0m);
            
            //After :
            migrationBuilder.AlterColumn<int>(
                name: "ImdbRating",
                table: "Pictures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.RenameColumn(
                name: "ImdbRating",
                table: "Pictures",
                newName: "InternetRating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Before :
            // migrationBuilder.DropColumn(
            //     name: "InternetRating",
            //     table: "Pictures");
            //
            // migrationBuilder.AddColumn<int>(
            //     name: "ImdbRating",
            //     table: "Pictures",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);
            
            //After :
            migrationBuilder.AlterColumn<decimal>(
                name: "InternetRating",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.RenameColumn(
                name: "InternetRating",
                table: "Pictures",
                newName: "ImdbRating");
        }
    }
}
