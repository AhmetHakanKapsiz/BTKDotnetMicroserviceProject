using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi.Service.MessageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adminConnectionId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Messages",
                newName: "Datetime");

            migrationBuilder.RenameColumn(
                name: "clientConnectionId",
                table: "Messages",
                newName: "ClientConnectionId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientConnectionId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MessageContent",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Messages",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "ClientConnectionId",
                table: "Messages",
                newName: "clientConnectionId");

            migrationBuilder.AlterColumn<string>(
                name: "MessageContent",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "clientConnectionId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adminConnectionId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
