using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class WithoutCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "BikeId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3c7ddfb9-cfb4-4b97-a95a-8510ecb707d1"),
                column: "BikeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                column: "BikeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"),
                column: "BikeId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "BikeId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3c7ddfb9-cfb4-4b97-a95a-8510ecb707d1"),
                column: "BikeId",
                value: new Guid("e6e46660-bb84-451d-aafe-a6c7346a48ae"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                column: "BikeId",
                value: new Guid("99289c1a-3342-40fc-905b-65c2dd59babe"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"),
                column: "BikeId",
                value: new Guid("99289c1a-3342-40fc-905b-65c2dd59babe"));

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bikes_BikeId",
                table: "Customers",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
