using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class AddedCustomerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "Bikes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("99289c1a-3342-40fc-905b-65c2dd59babe"),
                column: "CustomerID",
                value: new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"));

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("d719c835-ce3e-4dad-ad64-cfec54b19775"),
                column: "CustomerID",
                value: new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"));

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("e6e46660-bb84-451d-aafe-a6c7346a48ae"),
                column: "CustomerID",
                value: new Guid("65da4ed0-35b9-454e-b5ac-d0eee7aad646"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"),
                column: "BikeId",
                value: new Guid("99289c1a-3342-40fc-905b-65c2dd59babe"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Bikes");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"),
                column: "BikeId",
                value: new Guid("d719c835-ce3e-4dad-ad64-cfec54b19775"));
        }
    }
}
