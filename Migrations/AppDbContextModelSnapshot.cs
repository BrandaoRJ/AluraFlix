﻿// <auto-generated />
using AluraFlix.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AluraFlix.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("AluraFlix.API.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cor = "#81C784",
                            Titulo = "Livre"
                        });
                });

            modelBuilder.Entity("AluraFlix.API.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("AluraFlix.API.Models.Video", b =>
                {
                    b.HasOne("AluraFlix.API.Models.Categoria", "Categoria")
                        .WithMany("Videos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("AluraFlix.API.Models.Categoria", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
