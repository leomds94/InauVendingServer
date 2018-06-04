using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InauVendingServer.Migrations
{
    public partial class pmQtyInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductMachineQty",
                table: "ProductMachine",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductMachineQty",
                table: "ProductMachine",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
