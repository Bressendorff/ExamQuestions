﻿// <auto-generated />
using System;
using DatabaseMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseMigration.Migrations
{
    [DbContext(typeof(MSSQLContext))]
    [Migration("20240418192417_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseMigration.Customer", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerNumber"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalesRepEmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SalesRepEmployeeNumberNavigationEmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerNumber");

                    b.HasIndex("SalesRepEmployeeNumberNavigationEmployeeNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DatabaseMigration.Employee", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeNumber"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeCodeNavigationOfficeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<int?>("ReportsToNavigationEmployeeNumber")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("OfficeCodeNavigationOfficeCode");

                    b.HasIndex("ReportsToNavigationEmployeeNumber");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DatabaseMigration.Office", b =>
                {
                    b.Property<string>("OfficeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Territory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeCode");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("DatabaseMigration.Order", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<int>("CustomerNumberNavigationCustomerNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("RequiredDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("ShippedDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderNumber");

                    b.HasIndex("CustomerNumberNavigationCustomerNumber");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DatabaseMigration.Orderdetail", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"));

                    b.Property<short>("OrderLineNumber")
                        .HasColumnType("smallint");

                    b.Property<int>("OrderNumberNavigationOrderNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceEach")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCodeNavigationProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("OrderNumber");

                    b.HasIndex("OrderNumberNavigationOrderNumber");

                    b.HasIndex("ProductCodeNavigationProductCode");

                    b.ToTable("Orderdetail");
                });

            modelBuilder.Entity("DatabaseMigration.Payment", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerNumber"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CheckNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerNumberNavigationCustomerNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("CustomerNumber");

                    b.HasIndex("CustomerNumberNavigationCustomerNumber");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("DatabaseMigration.Product", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Msrp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductLineNavigationProductLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductScale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductVendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("QuantityInStock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductCode");

                    b.HasIndex("ProductLineNavigationProductLine1");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DatabaseMigration.Productline", b =>
                {
                    b.Property<string>("ProductLine1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HtmlDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TextDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductLine1");

                    b.ToTable("Productline");
                });

            modelBuilder.Entity("DatabaseMigration.Customer", b =>
                {
                    b.HasOne("DatabaseMigration.Employee", "SalesRepEmployeeNumberNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("SalesRepEmployeeNumberNavigationEmployeeNumber");

                    b.Navigation("SalesRepEmployeeNumberNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Employee", b =>
                {
                    b.HasOne("DatabaseMigration.Office", "OfficeCodeNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeCodeNavigationOfficeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseMigration.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsToNavigationEmployeeNumber");

                    b.Navigation("OfficeCodeNavigation");

                    b.Navigation("ReportsToNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Order", b =>
                {
                    b.HasOne("DatabaseMigration.Customer", "CustomerNumberNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerNumberNavigationCustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerNumberNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Orderdetail", b =>
                {
                    b.HasOne("DatabaseMigration.Order", "OrderNumberNavigation")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderNumberNavigationOrderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseMigration.Product", "ProductCodeNavigation")
                        .WithMany("Orderdetails")
                        .HasForeignKey("ProductCodeNavigationProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderNumberNavigation");

                    b.Navigation("ProductCodeNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Payment", b =>
                {
                    b.HasOne("DatabaseMigration.Customer", "CustomerNumberNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerNumberNavigationCustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerNumberNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Product", b =>
                {
                    b.HasOne("DatabaseMigration.Productline", "ProductLineNavigation")
                        .WithMany("Products")
                        .HasForeignKey("ProductLineNavigationProductLine1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductLineNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("DatabaseMigration.Employee", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("InverseReportsToNavigation");
                });

            modelBuilder.Entity("DatabaseMigration.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DatabaseMigration.Order", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("DatabaseMigration.Product", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("DatabaseMigration.Productline", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
