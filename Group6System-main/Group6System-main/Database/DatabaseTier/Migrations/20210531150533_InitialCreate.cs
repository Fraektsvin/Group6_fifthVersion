using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseTier.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityTable",
                columns: table => new
                {
                    ZipCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTable", x => x.ZipCode);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "AddressTable",
                columns: table => new
                {
                    StreetName = table.Column<string>(type: "text", nullable: false),
                    StreetNumber = table.Column<string>(type: "text", nullable: false),
                    CityZipCode = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTable", x => new { x.StreetName, x.StreetNumber });
                    table.ForeignKey(
                        name: "FK_AddressTable_CityTable_CityZipCode",
                        column: x => x.CityZipCode,
                        principalTable: "CityTable",
                        principalColumn: "ZipCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountTable",
                columns: table => new
                {
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTable", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountTable_UsersTable_Username",
                        column: x => x.Username,
                        principalTable: "UsersTable",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTable_UsersTable_Username",
                        column: x => x.Username,
                        principalTable: "UsersTable",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomersTable",
                columns: table => new
                {
                    CprNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AddressStreetName = table.Column<string>(type: "text", nullable: true),
                    AddressStreetNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    CountryOfResidence = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTable", x => x.CprNumber);
                    table.ForeignKey(
                        name: "FK_CustomersTable_AddressTable_AddressStreetName_AddressStreet~",
                        columns: x => new { x.AddressStreetName, x.AddressStreetNumber },
                        principalTable: "AddressTable",
                        principalColumns: new[] { "StreetName", "StreetNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersTable_UsersTable_Username",
                        column: x => x.Username,
                        principalTable: "UsersTable",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedAccountsTable",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaveAccountAccountNumber = table.Column<long>(type: "bigint", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedAccountsTable", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_SavedAccountsTable_AccountTable_SaveAccountAccountNumber",
                        column: x => x.SaveAccountAccountNumber,
                        principalTable: "AccountTable",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTable",
                columns: table => new
                {
                    TransactionNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderAccountNumber = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverAccountNumber = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Save = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTable", x => x.TransactionNumber);
                    table.ForeignKey(
                        name: "FK_TransactionTable_AccountTable_ReceiverAccountNumber",
                        column: x => x.ReceiverAccountNumber,
                        principalTable: "AccountTable",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionTable_AccountTable_SenderAccountNumber",
                        column: x => x.SenderAccountNumber,
                        principalTable: "AccountTable",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTable_Username",
                table: "AccountTable",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTable_CityZipCode",
                table: "AddressTable",
                column: "CityZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_AddressStreetName_AddressStreetNumber",
                table: "CustomersTable",
                columns: new[] { "AddressStreetName", "AddressStreetNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_Username",
                table: "CustomersTable",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTable_Username",
                table: "NotificationTable",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_SavedAccountsTable_SaveAccountAccountNumber",
                table: "SavedAccountsTable",
                column: "SaveAccountAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_ReceiverAccountNumber",
                table: "TransactionTable",
                column: "ReceiverAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_SenderAccountNumber",
                table: "TransactionTable",
                column: "SenderAccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersTable");

            migrationBuilder.DropTable(
                name: "NotificationTable");

            migrationBuilder.DropTable(
                name: "SavedAccountsTable");

            migrationBuilder.DropTable(
                name: "TransactionTable");

            migrationBuilder.DropTable(
                name: "AddressTable");

            migrationBuilder.DropTable(
                name: "AccountTable");

            migrationBuilder.DropTable(
                name: "CityTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
