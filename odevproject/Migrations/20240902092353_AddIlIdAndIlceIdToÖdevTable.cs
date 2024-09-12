using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevproject.Migrations
{
    /// <inheritdoc />
    public partial class AddIlIdAndIlceIdToÖdevTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "iller",
            //    columns: table => new
            //    {
            //        IlId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IlAd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_iller", x => x.IlId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ilceler",
            //    columns: table => new
            //    {
            //        IlceId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IlceAd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        IlId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ilceler", x => x.IlceId);
            //        table.ForeignKey(
            //            name: "FK_ilceler_iller_IlId",
            //            column: x => x.IlId,
            //            principalTable: "iller",
            //            principalColumn: "IlId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ödev_table",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        kullaniciAdi = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        kullaniciSoyadi = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        telefonNumarasi = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Mail = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        yetki = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        Yas = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        ilId = table.Column<int>(type: "int", nullable: false),
            //        ilceId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ödev_table", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_ödev_table_ilceler_ilceId",
            //            column: x => x.ilceId,
            //            principalTable: "ilceler",
            //            principalColumn: "IlceId");
            //        table.ForeignKey(
            //            name: "FK_ödev_table_iller_ilId",
            //            column: x => x.ilId,
            //            principalTable: "iller",
            //            principalColumn: "IlId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ilceler_IlId",
            //    table: "ilceler",
            //    column: "IlId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ödev_table_ilceId",
            //    table: "ödev_table",
            //    column: "ilceId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ödev_table_ilId",
            //    table: "ödev_table",
            //    column: "ilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ödev_table");

            //migrationBuilder.DropTable(
            //    name: "ilceler");

            //migrationBuilder.DropTable(
            //    name: "iller");
        }
    }
}
