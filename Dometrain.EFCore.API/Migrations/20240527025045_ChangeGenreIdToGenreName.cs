using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGenreIdToGenreName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_MainGenreId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ChannelFirstAiredOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "GrossRevenu",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "MainGenreId",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "MainGenreName",
                table: "Pictures",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "CinemaMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GrossRevenu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Pictures_Id",
                        column: x => x.Id,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelevisionMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ChannelFirstAiredOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelevisionMovie_Pictures_Id",
                        column: x => x.Id,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreName",
                table: "Pictures",
                column: "MainGenreName");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Genres_MainGenreName",
                table: "Pictures",
                column: "MainGenreName",
                principalTable: "Genres",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Genres_MainGenreName",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropTable(
                name: "TelevisionMovie");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_MainGenreName",
                table: "Pictures");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MainGenreName",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "ChannelFirstAiredOn",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pictures",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "GrossRevenu",
                table: "Pictures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainGenreId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreId",
                table: "Pictures",
                column: "MainGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
