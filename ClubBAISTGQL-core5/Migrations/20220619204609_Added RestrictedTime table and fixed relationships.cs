using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubBAISTGQL.Migrations
{
    public partial class AddedRestrictedTimetableandfixedrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandingTeeTimeID",
                table: "TeeTimes");

            migrationBuilder.DropColumn(
                name: "RestrictedPlayingTimeEnd",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "RestrictedPlayingTimeStart",
                table: "Memberships");

            migrationBuilder.CreateTable(
                name: "RestrictedTimes",
                columns: table => new
                {
                    RestrictedTimeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipID = table.Column<long>(type: "bigint", nullable: false),
                    RestrictedDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestrictedTimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    RestrictedTimeEnd = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestrictedTimes", x => x.RestrictedTimeID);
                    table.ForeignKey(
                        name: "FK_RestrictedTimes_Memberships_MembershipID",
                        column: x => x.MembershipID,
                        principalTable: "Memberships",
                        principalColumn: "MembershipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestrictedTimes_MembershipID",
                table: "RestrictedTimes",
                column: "MembershipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestrictedTimes");

            migrationBuilder.AddColumn<long>(
                name: "StandingTeeTimeID",
                table: "TeeTimes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RestrictedPlayingTimeEnd",
                table: "Memberships",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RestrictedPlayingTimeStart",
                table: "Memberships",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
