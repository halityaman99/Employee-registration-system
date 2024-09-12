using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevproject.Migrations
{
    /// <inheritdoc />
    public partial class deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AdminPassword",
            //    table: "Admin");

            //migrationBuilder.DropColumn(
            //    name: "AdminRole",
            //    table: "Admin");

            //migrationBuilder.DropColumn(
            //    name: "AdminUserName",
            //    table: "Admin");

            //migrationBuilder.RenameColumn(
            //    name: "AdmınId",
            //    table: "Admin",
            //    newName: "AdminId");

            //migrationBuilder.AddColumn<string>(
            //    name: "Kullanici",
            //    table: "Admin",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Sifre",
            //    table: "Admin",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Kullanici",
            //    table: "Admin");

            //migrationBuilder.DropColumn(
            //    name: "Sifre",
            //    table: "Admin");

            //migrationBuilder.RenameColumn(
            //    name: "AdminId",
            //    table: "Admin",
            //    newName: "AdmınId");

            //migrationBuilder.AddColumn<string>(
            //    name: "AdminPassword",
            //    table: "Admin",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "AdminRole",
            //    table: "Admin",
            //    type: "nvarchar(1)",
            //    maxLength: 1,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "AdminUserName",
            //    table: "Admin",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
