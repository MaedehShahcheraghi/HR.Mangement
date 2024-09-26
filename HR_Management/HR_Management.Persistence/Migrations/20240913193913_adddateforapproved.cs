using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Management.Persistence.Migrations
{
    public partial class adddateforapproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRequested", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 13, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9990), new DateTime(2024, 9, 18, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9985), new DateTime(2024, 9, 13, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRequested", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 13, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9994), new DateTime(2024, 9, 18, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9993), new DateTime(2024, 9, 13, 23, 9, 13, 587, DateTimeKind.Local).AddTicks(9993) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRequested", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3408), new DateTime(2024, 9, 18, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3403), new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRequested", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3411), new DateTime(2024, 9, 18, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3411), new DateTime(2024, 9, 13, 18, 23, 6, 545, DateTimeKind.Local).AddTicks(3410) });
        }
    }
}
