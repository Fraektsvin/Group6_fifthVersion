using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseTier.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTable",
                columns: table => new
                {
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTable", x => x.AccountNumber);
                });

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressTable",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetName = table.Column<string>(type: "text", nullable: true),
                    StreetNumber = table.Column<string>(type: "text", nullable: true),
                    CityZipCode = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTable", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_AddressTable_CityTable_CityZipCode",
                        column: x => x.CityZipCode,
                        principalTable: "CityTable",
                        principalColumn: "ZipCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomersTable",
                columns: table => new
                {
                    CprNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    CountryOfResidence = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CustomerAccountAccountNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTable", x => x.CprNumber);
                    table.ForeignKey(
                        name: "FK_CustomersTable_AccountTable_CustomerAccountAccountNumber",
                        column: x => x.CustomerAccountAccountNumber,
                        principalTable: "AccountTable",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersTable_AddressTable_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressTable",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersTable_UsersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTable",
                        principalColumn: "Id",
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
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    CustomerCprNumber = table.Column<int>(type: "integer", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_SavedAccountsTable_CustomersTable_CustomerCprNumber",
                        column: x => x.CustomerCprNumber,
                        principalTable: "CustomersTable",
                        principalColumn: "CprNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTable",
                columns: table => new
                {
                    TransactionNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderCprNumber = table.Column<int>(type: "integer", nullable: true),
                    ReceiverAccountNumber = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                        name: "FK_TransactionTable_CustomersTable_SenderCprNumber",
                        column: x => x.SenderCprNumber,
                        principalTable: "CustomersTable",
                        principalColumn: "CprNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTable_CityZipCode",
                table: "AddressTable",
                column: "CityZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_AddressId",
                table: "CustomersTable",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_CustomerAccountAccountNumber",
                table: "CustomersTable",
                column: "CustomerAccountAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_UserId",
                table: "CustomersTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedAccountsTable_CustomerCprNumber",
                table: "SavedAccountsTable",
                column: "CustomerCprNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SavedAccountsTable_SaveAccountAccountNumber",
                table: "SavedAccountsTable",
                column: "SaveAccountAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_ReceiverAccountNumber",
                table: "TransactionTable",
                column: "ReceiverAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_SenderCprNumber",
                table: "TransactionTable",
                column: "SenderCprNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedAccountsTable");

            migrationBuilder.DropTable(
                name: "TransactionTable");

            migrationBuilder.DropTable(
                name: "CustomersTable");

            migrationBuilder.DropTable(
                name: "AccountTable");

            migrationBuilder.DropTable(
                name: "AddressTable");

            migrationBuilder.DropTable(
                name: "UsersTable");

            migrationBuilder.DropTable(
                name: "CityTable");
        }
    }
}
