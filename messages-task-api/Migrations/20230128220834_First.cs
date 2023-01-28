using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace messagestaskapi.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TypeLog = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { new Guid("266e155d-bed4-47e3-a52f-c21eaad773f3"), "toto@gmail.com", "C3TZb8Ef5NcKnL/1CmjTrvYsixij9REwLDVkoK2UvFs=", "/DYD9vqoSbSJ9B9b8AoThQ==" },
                    { new Guid("61a82cff-06cd-4a34-b85f-12e2f68d68c0"), "synry63@gmail.com", "C3TZb8Ef5NcKnL/1CmjTrvYsixij9REwLDVkoK2UvFs=", "/DYD9vqoSbSJ9B9b8AoThQ==" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "DateReceived", "SenderEmail", "UserId" },
                values: new object[,]
                {
                    { new Guid("7bc69122-8413-42f9-b76e-5a9fd2e3dc10"), "Hello Patrick how are you", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "toto@gmail.com", new Guid("61a82cff-06cd-4a34-b85f-12e2f68d68c0") },
                    { new Guid("b820fe5e-85b0-4528-b751-a2225319740d"), "I hope you are fine", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "toto@gmail.com", new Guid("61a82cff-06cd-4a34-b85f-12e2f68d68c0") }
                });

            migrationBuilder.InsertData(
                table: "UserNotifications",
                columns: new[] { "Id", "Total" },
                values: new object[,]
                {
                    { new Guid("266e155d-bed4-47e3-a52f-c21eaad773f3"), 0 },
                    { new Guid("61a82cff-06cd-4a34-b85f-12e2f68d68c0"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLogs_UserId",
                table: "HistoryLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryLogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
