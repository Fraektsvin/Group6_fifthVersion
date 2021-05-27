using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTier.Migrations
{
    public partial class UpdateNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTable_CustomersTable_CustomerCprNumber",
                table: "NotificationTable");

            migrationBuilder.DropIndex(
                name: "IX_NotificationTable_CustomerCprNumber",
                table: "NotificationTable");

            migrationBuilder.DropColumn(
                name: "CustomerCprNumber",
                table: "NotificationTable");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "NotificationTable",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTable_Username",
                table: "NotificationTable",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTable_UsersTable_Username",
                table: "NotificationTable",
                column: "Username",
                principalTable: "UsersTable",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTable_UsersTable_Username",
                table: "NotificationTable");

            migrationBuilder.DropIndex(
                name: "IX_NotificationTable_Username",
                table: "NotificationTable");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "NotificationTable");

            migrationBuilder.AddColumn<int>(
                name: "CustomerCprNumber",
                table: "NotificationTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTable_CustomerCprNumber",
                table: "NotificationTable",
                column: "CustomerCprNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTable_CustomersTable_CustomerCprNumber",
                table: "NotificationTable",
                column: "CustomerCprNumber",
                principalTable: "CustomersTable",
                principalColumn: "CprNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
