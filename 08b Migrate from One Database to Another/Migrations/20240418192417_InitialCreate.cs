using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Territory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "Productline",
                columns: table => new
                {
                    ProductLine1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TextDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productline", x => x.ProductLine1);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportsTo = table.Column<int>(type: "int", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeCodeNavigationOfficeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportsToNavigationEmployeeNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ReportsToNavigationEmployeeNumber",
                        column: x => x.ReportsToNavigationEmployeeNumber,
                        principalTable: "Employee",
                        principalColumn: "EmployeeNumber");
                    table.ForeignKey(
                        name: "FK_Employee_Office_OfficeCodeNavigationOfficeCode",
                        column: x => x.OfficeCodeNavigationOfficeCode,
                        principalTable: "Office",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductScale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductVendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<short>(type: "smallint", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Msrp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductLineNavigationProductLine1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Product_Productline_ProductLineNavigationProductLine1",
                        column: x => x.ProductLineNavigationProductLine1,
                        principalTable: "Productline",
                        principalColumn: "ProductLine1",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(type: "int", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalesRepEmployeeNumberNavigationEmployeeNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Customers_Employee_SalesRepEmployeeNumberNavigationEmployeeNumber",
                        column: x => x.SalesRepEmployeeNumberNavigationEmployeeNumber,
                        principalTable: "Employee",
                        principalColumn: "EmployeeNumber");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RequiredDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ShippedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerNumberNavigationCustomerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerNumberNavigationCustomerNumber",
                        column: x => x.CustomerNumberNavigationCustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerNumberNavigationCustomerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Payment_Customers_CustomerNumberNavigationCustomerNumber",
                        column: x => x.CustomerNumberNavigationCustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetail",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: false),
                    PriceEach = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderLineNumber = table.Column<short>(type: "smallint", nullable: false),
                    OrderNumberNavigationOrderNumber = table.Column<int>(type: "int", nullable: false),
                    ProductCodeNavigationProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetail", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orderdetail_Order_OrderNumberNavigationOrderNumber",
                        column: x => x.OrderNumberNavigationOrderNumber,
                        principalTable: "Order",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderdetail_Product_ProductCodeNavigationProductCode",
                        column: x => x.ProductCodeNavigationProductCode,
                        principalTable: "Product",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesRepEmployeeNumberNavigationEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumberNavigationEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OfficeCodeNavigationOfficeCode",
                table: "Employee",
                column: "OfficeCodeNavigationOfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ReportsToNavigationEmployeeNumber",
                table: "Employee",
                column: "ReportsToNavigationEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerNumberNavigationCustomerNumber",
                table: "Order",
                column: "CustomerNumberNavigationCustomerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetail_OrderNumberNavigationOrderNumber",
                table: "Orderdetail",
                column: "OrderNumberNavigationOrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetail_ProductCodeNavigationProductCode",
                table: "Orderdetail",
                column: "ProductCodeNavigationProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerNumberNavigationCustomerNumber",
                table: "Payment",
                column: "CustomerNumberNavigationCustomerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductLineNavigationProductLine1",
                table: "Product",
                column: "ProductLineNavigationProductLine1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderdetail");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Productline");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Office");
        }
    }
}
