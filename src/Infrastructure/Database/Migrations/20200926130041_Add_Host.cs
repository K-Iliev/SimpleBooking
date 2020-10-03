using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class Add_Host : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HostId",
                table: "Hotels",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Host_HostId",
                table: "Hotels",
                column: "HostId",
                principalTable: "Host",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Host_HostId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Host");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HostId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Hotels");
        }
    }
}
