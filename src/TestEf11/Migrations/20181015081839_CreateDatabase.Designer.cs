﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestEf11;

namespace TestEf11.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181015081839_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEf11.ChildEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanRead");

                    b.Property<int>("ParentKey");

                    b.HasKey("Key");

                    b.HasIndex("ParentKey");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("TestEf11.ParentEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Key");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("TestEf11.ChildEntity", b =>
                {
                    b.HasOne("TestEf11.ParentEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
