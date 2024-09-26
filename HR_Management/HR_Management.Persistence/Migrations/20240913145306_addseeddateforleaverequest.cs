using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Management.Persistence.Migrations
{
    public partial class addseeddateforleaverequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActioned",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "Approved", "Cancelled", "CreatedBy", "DateActioned", "DateCreated", "DateRequested", "EndDate", "LastModifiedBy", "LastModifiedDate", "LeaveTypeId", "RequestComments", "StartDate" },
                values: new object[] { 1, true, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3408), new DateTime(2024, 9, 18, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3403), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "trierd", new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3389) });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "Approved", "Cancelled", "CreatedBy", "DateActioned", "DateCreated", "DateRequested", "EndDate", "LastModifiedBy", "LastModifiedDate", "LeaveTypeId", "RequestComments", "StartDate" },
                values: new object[] { 2, false, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3411), new DateTime(2024, 9, 18, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3411), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "sick", new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3410) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActioned",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
