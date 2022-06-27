using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubBAISTGQL.Migrations
{
    public partial class FirstiterationforTeeTimebooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestrictedPlayingTimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    RestrictedPlayingTimeEnd = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipID);
                });

            migrationBuilder.CreateTable(
                name: "StandingTeeTimes",
                columns: table => new
                {
                    StandingTeeTimeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingTeeTimes", x => x.StandingTeeTimeID);
                });

            migrationBuilder.CreateTable(
                name: "TeeTimes",
                columns: table => new
                {
                    TeeTimeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTeeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartsRequested = table.Column<int>(type: "int", nullable: true),
                    StandingTeeTimeID = table.Column<long>(type: "bigint", nullable: true),
                    EventID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeeTimes", x => x.TeeTimeID);
                    table.ForeignKey(
                        name: "FK_TeeTimes_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberNumber);
                    table.ForeignKey(
                        name: "FK_Members_Memberships_MembershipID",
                        column: x => x.MembershipID,
                        principalTable: "Memberships",
                        principalColumn: "MembershipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberTeeTimes",
                columns: table => new
                {
                    TeeTimeID = table.Column<long>(type: "bigint", nullable: false),
                    MemberNumber = table.Column<long>(type: "bigint", nullable: false),
                    StandingTeeTimeID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTeeTimes", x => new { x.MemberNumber, x.TeeTimeID });
                    table.ForeignKey(
                        name: "FK_MemberTeeTimes_Members_MemberNumber",
                        column: x => x.MemberNumber,
                        principalTable: "Members",
                        principalColumn: "MemberNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberTeeTimes_StandingTeeTimes_StandingTeeTimeID",
                        column: x => x.StandingTeeTimeID,
                        principalTable: "StandingTeeTimes",
                        principalColumn: "StandingTeeTimeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberTeeTimes_TeeTimes_TeeTimeID",
                        column: x => x.TeeTimeID,
                        principalTable: "TeeTimes",
                        principalColumn: "TeeTimeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MembershipID",
                table: "Members",
                column: "MembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTeeTimes_StandingTeeTimeID",
                table: "MemberTeeTimes",
                column: "StandingTeeTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTeeTimes_TeeTimeID",
                table: "MemberTeeTimes",
                column: "TeeTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_TeeTimes_EventID",
                table: "TeeTimes",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTeeTimes");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "StandingTeeTimes");

            migrationBuilder.DropTable(
                name: "TeeTimes");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
