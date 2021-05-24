﻿// <auto-generated />
using System;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseTier.Migrations
{
    [DbContext(typeof(CloudContext))]
    partial class CloudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DatabaseTier.Models.Account", b =>
                {
                    b.Property<long>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<int?>("CustomerCprNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.HasKey("AccountNumber");

                    b.HasIndex("CustomerCprNumber");

                    b.ToTable("AccountTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.Address", b =>
                {
                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("text");

                    b.Property<int?>("CityZipCode")
                        .HasColumnType("integer");

                    b.HasKey("StreetName", "StreetNumber");

                    b.HasIndex("CityZipCode");

                    b.ToTable("AddressTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.City", b =>
                {
                    b.Property<int>("ZipCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.HasKey("ZipCode");

                    b.ToTable("CityTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.Customer", b =>
                {
                    b.Property<int>("CprNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressStreetName")
                        .HasColumnType("text");

                    b.Property<string>("AddressStreetNumber")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfResidence")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("CprNumber");

                    b.HasIndex("Username");

                    b.HasIndex("AddressStreetName", "AddressStreetNumber");

                    b.ToTable("CustomersTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.SavedAccounts", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("CustomerCprNumber")
                        .HasColumnType("integer");

                    b.Property<long?>("SaveAccountAccountNumber")
                        .HasColumnType("bigint");

                    b.HasKey("AccountId");

                    b.HasIndex("CustomerCprNumber");

                    b.HasIndex("SaveAccountAccountNumber");

                    b.ToTable("SavedAccountsTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<long?>("ReceiverAccountNumber")
                        .HasColumnType("bigint");

                    b.Property<bool>("Save")
                        .HasColumnType("boolean");

                    b.Property<long?>("SenderAccountNumber")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionNumber");

                    b.HasIndex("ReceiverAccountNumber");

                    b.HasIndex("SenderAccountNumber");

                    b.ToTable("TransactionTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("UsersTable");
                });

            modelBuilder.Entity("DatabaseTier.Models.Account", b =>
                {
                    b.HasOne("DatabaseTier.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCprNumber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DatabaseTier.Models.Address", b =>
                {
                    b.HasOne("DatabaseTier.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityZipCode");

                    b.Navigation("City");
                });

            modelBuilder.Entity("DatabaseTier.Models.Customer", b =>
                {
                    b.HasOne("DatabaseTier.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.HasOne("DatabaseTier.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressStreetName", "AddressStreetNumber");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseTier.Models.SavedAccounts", b =>
                {
                    b.HasOne("DatabaseTier.Models.Customer", null)
                        .WithMany("SavedAccountsList")
                        .HasForeignKey("CustomerCprNumber");

                    b.HasOne("DatabaseTier.Models.Account", "SaveAccount")
                        .WithMany()
                        .HasForeignKey("SaveAccountAccountNumber");

                    b.Navigation("SaveAccount");
                });

            modelBuilder.Entity("DatabaseTier.Models.Transaction", b =>
                {
                    b.HasOne("DatabaseTier.Models.Account", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverAccountNumber");

                    b.HasOne("DatabaseTier.Models.Account", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderAccountNumber");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DatabaseTier.Models.Customer", b =>
                {
                    b.Navigation("SavedAccountsList");
                });
#pragma warning restore 612, 618
        }
    }
}
