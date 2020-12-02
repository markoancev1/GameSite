using Microsoft.EntityFrameworkCore.Migrations;

namespace GameSite.Migrations
{
    public partial class PC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsItOnPc",
                table: "Consoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "5cc4bda5-460d-4774-ac70-ce9d2bec03f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "c0ce0f51-1a43-4414-be36-748d089e16b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELUekcdGgpXmFvg/MqsbSCswNEC9yAT1AhCHLWKD36oK1kxS304GQ1hy3ezIMlTgHg==");

            migrationBuilder.UpdateData(
                table: "Consoles",
                keyColumn: "ConsoleId",
                keyValue: 4,
                column: "IsItOnPc",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItOnPc",
                table: "Consoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "265c4545-4f46-4411-be54-817fcf2a5770");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "81ef8722-0642-4405-8744-76b05f33f3b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECzczyLw/6bD6ePXU2tMH4p44yVn3WcLDIvt/AgJBGsPreOG/2n0wAnbrHxOiAM82w==");
        }
    }
}
