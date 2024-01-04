using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phase3EndProject.Migrations
{
    public partial class FirstDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptMaster",
                columns: table => new
                {
                    DeptCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptMaster", x => x.DeptCode);
                });

            migrationBuilder.CreateTable(
                name: "EmpProfile",
                columns: table => new
                {
                    EmpCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptCode = table.Column<int>(type: "int", nullable: false),
                    DeptMasterDeptCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfile", x => x.EmpCode);
                    table.ForeignKey(
                        name: "FK_EmpProfile_DeptMaster_DeptMasterDeptCode",
                        column: x => x.DeptMasterDeptCode,
                        principalTable: "DeptMaster",
                        principalColumn: "DeptCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfile_DeptMasterDeptCode",
                table: "EmpProfile",
                column: "DeptMasterDeptCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpProfile");

            migrationBuilder.DropTable(
                name: "DeptMaster");
        }
    }
}
