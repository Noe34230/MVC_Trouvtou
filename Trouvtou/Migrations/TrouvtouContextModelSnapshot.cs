﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Trouvtou.Migrations
{
    [DbContext(typeof(TrouvtouContext))]
    partial class TrouvtouContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Trouvtou.Models.Objet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateDernierRangement")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("estConsultable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("rangementid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("typeObjet")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("rangementid");

                    b.ToTable("Objet");
                });

            modelBuilder.Entity("Trouvtou.Models.Rangement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("couleur")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("descriptionDetail")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Rangement");
                });

            modelBuilder.Entity("Trouvtou.Models.Objet", b =>
                {
                    b.HasOne("Trouvtou.Models.Rangement", "rangement")
                        .WithMany("listObjet")
                        .HasForeignKey("rangementid");

                    b.Navigation("rangement");
                });

            modelBuilder.Entity("Trouvtou.Models.Rangement", b =>
                {
                    b.Navigation("listObjet");
                });
#pragma warning restore 612, 618
        }
    }
}
