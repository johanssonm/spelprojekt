﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spelprojekt.Data;

namespace Spelprojekt.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20180821143811_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spelprojekt.Entities.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Identity");
                });

            modelBuilder.Entity("Spelprojekt.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Spelprojekt.Entities.PlayerScore", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("ScoreId");

                    b.Property<int>("Id");

                    b.HasKey("PlayerId", "ScoreId");

                    b.HasIndex("ScoreId");

                    b.ToTable("PlayerScores");
                });

            modelBuilder.Entity("Spelprojekt.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Points");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Spelprojekt.Entities.Identity", b =>
                {
                    b.HasOne("Spelprojekt.Entities.Player", "Player")
                        .WithOne("Identity")
                        .HasForeignKey("Spelprojekt.Entities.Identity", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Spelprojekt.Entities.PlayerScore", b =>
                {
                    b.HasOne("Spelprojekt.Entities.Player", "Player")
                        .WithMany("PlayerScores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Spelprojekt.Entities.Score", "Score")
                        .WithMany("PlayerScore")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}