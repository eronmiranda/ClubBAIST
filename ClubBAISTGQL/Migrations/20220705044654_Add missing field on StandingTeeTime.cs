using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubBAISTGQL.Migrations
{
    public partial class AddmissingfieldonStandingTeeTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "RequestedTeeTime",
                table: "StandingTeeTimes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedTeeTime",
                table: "StandingTeeTimes");
        }
    }
}
