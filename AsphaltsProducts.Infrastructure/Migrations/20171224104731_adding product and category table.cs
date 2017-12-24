using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AsphaltsProducts.Infrastructure.Migrations
{
    public partial class addingproductandcategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discounted_price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Products",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "retail_price",
                table: "Products",
                newName: "RetailPrice");

            migrationBuilder.RenameColumn(
                name: "product_url",
                table: "Products",
                newName: "ProductUrl");

            migrationBuilder.RenameColumn(
                name: "product_specifications",
                table: "Products",
                newName: "ProductSpecifications");

            migrationBuilder.RenameColumn(
                name: "product_rating",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "product_category_tree",
                table: "Products",
                newName: "OverallRating");

            migrationBuilder.RenameColumn(
                name: "overall_rating",
                table: "Products",
                newName: "DiscountedPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductRating",
                table: "Products",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRating",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "brand");

            migrationBuilder.RenameColumn(
                name: "RetailPrice",
                table: "Products",
                newName: "retail_price");

            migrationBuilder.RenameColumn(
                name: "ProductUrl",
                table: "Products",
                newName: "product_url");

            migrationBuilder.RenameColumn(
                name: "ProductSpecifications",
                table: "Products",
                newName: "product_specifications");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "product_rating");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "OverallRating",
                table: "Products",
                newName: "product_category_tree");

            migrationBuilder.RenameColumn(
                name: "DiscountedPrice",
                table: "Products",
                newName: "overall_rating");

            migrationBuilder.AlterColumn<string>(
                name: "brand",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discounted_price",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Products",
                nullable: true);
        }
    }
}
