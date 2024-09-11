using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchPharmacy.Migrations
{
    /// <inheritdoc />
    public partial class twomigration : Migration
    {
        /// <inheritdoc />
        /// it's add column CreatedBy , CreatedDate , CurrentState , UpdatedBy
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbPharmcists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPharmcists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbPharmcists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbPharmcists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPharmcists",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbPharmcists");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPharmcists");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbPharmcists");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbPharmcists");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPharmcists");
        }
    }
}
