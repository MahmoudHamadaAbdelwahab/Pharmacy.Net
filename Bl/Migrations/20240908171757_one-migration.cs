using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchPharmacy.Migrations
{
    /// <inheritdoc />
    public partial class onemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCustomers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TbPayment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPayment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "TbPharmcists",
                columns: table => new
                {
                    PharmcistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmcistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PharmcistEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPharmcists", x => x.PharmcistId);
                });

            migrationBuilder.CreateTable(
                name: "TbProdcutsClassification",
                columns: table => new
                {
                    ProdcutsClassificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdcutsClassificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProdcutsClassification", x => x.ProdcutsClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "TbSupplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSupplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "TbOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrder", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_TbOrder_TbCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TbCustomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbOrder_TbPayment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "TbPayment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuentity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    PharmcistId = table.Column<int>(type: "int", nullable: false),
                    ProdcutsClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_TbProducts_TbPharmcists_PharmcistId",
                        column: x => x.PharmcistId,
                        principalTable: "TbPharmcists",
                        principalColumn: "PharmcistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbProducts_TbProdcutsClassification_ProdcutsClassificationId",
                        column: x => x.ProdcutsClassificationId,
                        principalTable: "TbProdcutsClassification",
                        principalColumn: "ProdcutsClassificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbProducts_TbSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TbSupplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbOrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_TbOrderItem_TbOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TbOrder",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbOrderItem_TbProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "TbProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbOrder_CustomerId",
                table: "TbOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrder_PaymentId",
                table: "TbOrder",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItem_OrderId",
                table: "TbOrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItem_ProductsId",
                table: "TbOrderItem",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_PharmcistId",
                table: "TbProducts",
                column: "PharmcistId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_ProdcutsClassificationId",
                table: "TbProducts",
                column: "ProdcutsClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_SupplierId",
                table: "TbProducts",
                column: "SupplierId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbOrderItem");

            migrationBuilder.DropTable(
                name: "TbOrder");

            migrationBuilder.DropTable(
                name: "TbProducts");

            migrationBuilder.DropTable(
                name: "TbCustomers");

            migrationBuilder.DropTable(
                name: "TbPayment");

            migrationBuilder.DropTable(
                name: "TbPharmcists");

            migrationBuilder.DropTable(
                name: "TbProdcutsClassification");

            migrationBuilder.DropTable(
                name: "TbSupplier");
        }
    }
}
