using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EContext.Migrations
{
    /// <inheritdoc />
    public partial class initnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                });

            migrationBuilder.CreateTable(
                name: "SubAccountsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubAccountTypeNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubAccountTypeNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAccountsTypes", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccountNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_Cities_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JVTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JVTypeNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JVTypeNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JVTypes", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_JVTypes_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubAccounts_Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAccLevels", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_SubAccounts_Levels_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JVNo = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    JVDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    JVTypeID = table.Column<int>(type: "int", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "numeric(22,8)", nullable: true),
                    TotalCredit = table.Column<decimal>(type: "numeric(22,8)", nullable: true),
                    ReceiptNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_JV_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JV_JVTypes",
                        column: x => x.JVTypeID,
                        principalTable: "JVTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubAccountNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubAccountNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: true),
                    LevelID = table.Column<int>(type: "int", nullable: true),
                    SubAccountTypeID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAccounts", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_SubAccounts_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAccounts_SubAccounts",
                        column: x => x.ParentID,
                        principalTable: "SubAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAccounts_SubAccountsTypes",
                        column: x => x.SubAccountTypeID,
                        principalTable: "SubAccountsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAccounts_SubAccounts_Levels",
                        column: x => x.LevelID,
                        principalTable: "SubAccounts_Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JVDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JVID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    SubAccountID = table.Column<int>(type: "int", nullable: true),
                    Debit = table.Column<decimal>(type: "numeric(22,8)", nullable: true),
                    Credit = table.Column<decimal>(type: "numeric(22,8)", nullable: true),
                    LocalDebit = table.Column<decimal>(type: "numeric(22,8)", nullable: false),
                    LocalCredit = table.Column<decimal>(type: "numeric(22,8)", nullable: false),
                    IsDocumented = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JVDetails", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_JVDetails_A_JV1",
                        column: x => x.JVID,
                        principalTable: "JV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JVDetails_Accounts",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JVDetails_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JVDetails_SubAccounts",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubAccountsClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubAccountID = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "numeric(18,8)", nullable: true),
                    IsDiscountTax = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    CreationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id)
                        .Annotation("SqlServer:FillFactor", 80);
                    table.ForeignKey(
                        name: "FK_SubAccountsClient_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAccountsClient_Cities",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAccountsClient_SubAccounts",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchCode", "BranchNameAr", "BranchNameEn", "CreationName" },
                values: new object[] { 1, null, "الاسكندرية", "Alex", null });

            migrationBuilder.InsertData(
                table: "SubAccountsTypes",
                columns: new[] { "Id", "BranchID", "CreationName", "SubAccountTypeNameAr", "SubAccountTypeNameEn" },
                values: new object[,]
                {
                    { 1, 1, null, "عميل", "Clients" },
                    { 2, 1, null, "أخرى", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNameAr", "AccountNameEn", "AccountNumber", "BranchID", "CreationName" },
                values: new object[,]
                {
                    { 1001, "ذمم بضاعة", "Merchandise receivables", "1001", 1, null },
                    { 1002, "عهد", "protection", "1002", 1, null },
                    { 1003, "الاصول", "Assets", "1003", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "BranchID", "CityCode", "CityNameAr", "CityNameEn", "CreationName" },
                values: new object[,]
                {
                    { 10001, 1, null, "جيزة", "Giza", null },
                    { 10002, 1, null, "القاهرة", "Cairo", null },
                    { 10003, 1, null, "الاسكندرية", "Alex", null }
                });

            migrationBuilder.InsertData(
                table: "JVTypes",
                columns: new[] { "Id", "BranchID", "CreationName", "JVTypeNameAr", "JVTypeNameEn" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Outgoing" },
                    { 2, 1, null, null, "Sales" },
                    { 3, 1, null, null, "Payment" }
                });

            migrationBuilder.InsertData(
                table: "SubAccounts_Levels",
                columns: new[] { "Id", "BranchID", "CreationName", "Width" },
                values: new object[,]
                {
                    { 1, 1, null, 3 },
                    { 2, 1, null, 3 },
                    { 3, 1, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts",
                table: "Accounts",
                column: "AccountNumber",
                unique: true,
                filter: "[AccountNumber] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchID",
                table: "Accounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_BranchID",
                table: "Cities",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_JV_BranchID",
                table: "JV",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_JV_JVTypeID",
                table: "JV",
                column: "JVTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_JVDetails_AccountID",
                table: "JVDetails",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_JVDetails_BranchID",
                table: "JVDetails",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_JVDetails_JVID",
                table: "JVDetails",
                column: "JVID");

            migrationBuilder.CreateIndex(
                name: "IX_JVDetails_SubAccountID",
                table: "JVDetails",
                column: "SubAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_JVTypes_BranchID",
                table: "JVTypes",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts",
                table: "SubAccounts",
                column: "SubAccountNumber",
                unique: true,
                filter: "[SubAccountNumber] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_BranchID",
                table: "SubAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_LevelID",
                table: "SubAccounts",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_ParentID",
                table: "SubAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_SubAccountTypeID",
                table: "SubAccounts",
                column: "SubAccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_Levels_BranchID",
                table: "SubAccounts_Levels",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccountsClient_BranchID",
                table: "SubAccountsClient",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccountsClient_CityID",
                table: "SubAccountsClient",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccountsClient_SubAccountID",
                table: "SubAccountsClient",
                column: "SubAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JVDetails");

            migrationBuilder.DropTable(
                name: "SubAccountsClient");

            migrationBuilder.DropTable(
                name: "JV");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SubAccounts");

            migrationBuilder.DropTable(
                name: "JVTypes");

            migrationBuilder.DropTable(
                name: "SubAccountsTypes");

            migrationBuilder.DropTable(
                name: "SubAccounts_Levels");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
