using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werkcollege04.Oef01.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dept",
                columns: table => new
                {
                    Deptno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(nullable: true),
                    Loc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept", x => x.Deptno);
                });

            migrationBuilder.CreateTable(
                name: "Emp",
                columns: table => new
                {
                    Empno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(nullable: false),
                    Job = table.Column<int>(nullable: false),
                    Mgr = table.Column<int>(nullable: true),
                    Hiredate = table.Column<DateTime>(nullable: false),
                    Sal = table.Column<double>(nullable: false),
                    Comm = table.Column<double>(nullable: false),
                    Deptno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp", x => x.Empno);
                    table.ForeignKey(
                        name: "FK_Emp_Dept_Deptno",
                        column: x => x.Deptno,
                        principalTable: "Dept",
                        principalColumn: "Deptno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_Emp_Mgr",
                        column: x => x.Mgr,
                        principalTable: "Emp",
                        principalColumn: "Empno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Deptno",
                table: "Emp",
                column: "Deptno");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Mgr",
                table: "Emp",
                column: "Mgr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp");

            migrationBuilder.DropTable(
                name: "Dept");
        }
    }
}
