using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchPharmacy.Migrations
{
    /// <inheritdoc />
    public partial class third_migration : Migration
    {
        /// <inheritdoc />
        /// add the table TbSettings , TbSlider
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSettings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebsiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AboutUs = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CopyRight = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstgramLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddlePanner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPanner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSettings", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "TbSlider",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSlider", x => x.SliderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbSettings");

            migrationBuilder.DropTable(
                name: "TbSlider");
        }
    }
}
