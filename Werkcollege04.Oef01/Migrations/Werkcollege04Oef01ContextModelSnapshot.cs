﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Werkcollege04.Oef01.Data;

namespace Werkcollege04.Oef01.Migrations
{
    [DbContext(typeof(Werkcollege04Oef01Context))]
    partial class Werkcollege04Oef01ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Werkcollege04.Oef01.Models.Department", b =>
                {
                    b.Property<int>("Deptno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnName("Loc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Deptno");

                    b.ToTable("Dept");
                });

            modelBuilder.Entity("Werkcollege04.Oef01.Models.Employee", b =>
                {
                    b.Property<int>("Empno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Commission")
                        .HasColumnName("Comm")
                        .HasColumnType("float");

                    b.Property<int>("Deptno")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hiredate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Job")
                        .HasColumnType("int");

                    b.Property<int?>("Mgr")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Ename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnName("Sal")
                        .HasColumnType("float");

                    b.HasKey("Empno");

                    b.HasIndex("Deptno");

                    b.HasIndex("Mgr");

                    b.ToTable("Emp");
                });

            modelBuilder.Entity("Werkcollege04.Oef01.Models.Employee", b =>
                {
                    b.HasOne("Werkcollege04.Oef01.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("Deptno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Werkcollege04.Oef01.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("Mgr");
                });
#pragma warning restore 612, 618
        }
    }
}