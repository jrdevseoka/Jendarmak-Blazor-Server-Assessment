﻿// <auto-generated />
using Assembly.Site.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assembly.Site.Migrations
{
    [DbContext(typeof(JAADBContext))]
    [Migration("20231115223513_IndexForUniqueNames")]
    partial class IndexForUniqueNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assembly.Site.Data.Models.Device", b =>
                {
                    b.Property<int>("DeviceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceID"));

                    b.Property<int>("DeviceType")
                        .HasColumnType("int")
                        .HasColumnName("TYPE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("NAME");

                    b.HasKey("DeviceID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DEVICES");
                });

            modelBuilder.Entity("Assembly.Site.Data.Models.Operation", b =>
                {
                    b.Property<int>("OperationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperationID"));

                    b.Property<int>("DEVICEID")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("IMAGE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("NAME");

                    b.Property<int>("OrderInWhichToPerform")
                        .HasColumnType("int")
                        .HasColumnName("PIORITY");

                    b.HasKey("OperationID");

                    b.HasIndex("DEVICEID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OPERATIONS");
                });

            modelBuilder.Entity("Assembly.Site.Data.Models.Operation", b =>
                {
                    b.HasOne("Assembly.Site.Data.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DEVICEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
