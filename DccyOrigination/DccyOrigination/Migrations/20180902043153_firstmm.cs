using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DccyOrigination.Migrations
{
    public partial class firstmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Pid = table.Column<int>(nullable: false),
                    Guid = table.Column<string>(nullable: true),
                    PGuid = table.Column<string>(nullable: true),
                    DepName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admDepRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    JurType = table.Column<int>(nullable: false),
                    DepId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admDepRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admJurisdiction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Pid = table.Column<int>(nullable: false),
                    Guid = table.Column<string>(nullable: true),
                    PGuid = table.Column<string>(nullable: true),
                    JurName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    MenuStyle = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    DepId = table.Column<int>(nullable: false),
                    IsAuthorization = table.Column<bool>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    IsChildren = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admJurisdiction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    OpTime = table.Column<DateTime>(nullable: false),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Pid = table.Column<int>(nullable: false),
                    Guid = table.Column<string>(nullable: true),
                    PGuid = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    MenuGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admRoleJur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    JurType = table.Column<int>(nullable: false),
                    AdmRoleId = table.Column<int>(nullable: false),
                    AdmJurGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admRoleJur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<string>(nullable: true),
                    UserAccounts = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    DepId = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DetailedAddress = table.Column<string>(nullable: true),
                    NumOfLogins = table.Column<int>(nullable: false),
                    ThumbnailImage = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admUserDep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    JurType = table.Column<int>(nullable: false),
                    AdmUserId = table.Column<int>(nullable: false),
                    AdmDepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admUserDep", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admDepartment");

            migrationBuilder.DropTable(
                name: "admDepRole");

            migrationBuilder.DropTable(
                name: "admJurisdiction");

            migrationBuilder.DropTable(
                name: "admLog");

            migrationBuilder.DropTable(
                name: "admRole");

            migrationBuilder.DropTable(
                name: "admRoleJur");

            migrationBuilder.DropTable(
                name: "admUser");

            migrationBuilder.DropTable(
                name: "admUserDep");
        }
    }
}
