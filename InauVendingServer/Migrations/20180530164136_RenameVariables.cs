using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InauVendingServer.Migrations
{
    public partial class RenameVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendingCommand_ProductMachine_ProductMachineId",
                table: "PendingCommand");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "PendingCommand");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "PendingCommand");

            migrationBuilder.RenameColumn(
                name: "ProductIndex",
                table: "ProductMachine",
                newName: "ProductMachineIndex");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PendingCommand",
                newName: "PendingId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductMachineId",
                table: "PendingCommand",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "PendingCommand",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PendingCommand_ProductMachine_ProductMachineId",
                table: "PendingCommand",
                column: "ProductMachineId",
                principalTable: "ProductMachine",
                principalColumn: "ProductMachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendingCommand_ProductMachine_ProductMachineId",
                table: "PendingCommand");

            migrationBuilder.DropColumn(
                name: "status",
                table: "PendingCommand");

            migrationBuilder.RenameColumn(
                name: "ProductMachineIndex",
                table: "ProductMachine",
                newName: "ProductIndex");

            migrationBuilder.RenameColumn(
                name: "PendingId",
                table: "PendingCommand",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ProductMachineId",
                table: "PendingCommand",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "PendingCommand",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "PendingCommand",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PendingCommand_ProductMachine_ProductMachineId",
                table: "PendingCommand",
                column: "ProductMachineId",
                principalTable: "ProductMachine",
                principalColumn: "ProductMachineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
