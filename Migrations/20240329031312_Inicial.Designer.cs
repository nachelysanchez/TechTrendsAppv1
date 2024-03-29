﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechTrendsAppv1.DAL;

#nullable disable

namespace TechTrendsAppv1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240329031312_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechTrendsAppv1.Modelos.CalificacionPublicaciones", b =>
                {
                    b.Property<int>("IdCalificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCalificacion"));

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("Valoracion")
                        .HasColumnType("int");

                    b.HasKey("IdCalificacion");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("CalificacionPublicaciones");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Comentarios", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComentario"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.HasKey("IdComentario");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Estados", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Etiquetas", b =>
                {
                    b.Property<int>("IdEtiqueta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEtiqueta"));

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEtiqueta");

                    b.HasIndex("IdEstado");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Permisos", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPermiso");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.PermisosRoles", b =>
                {
                    b.Property<int>("IdPermisoRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermisoRol"));

                    b.Property<int>("IdPermiso")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdPermisoRol");

                    b.HasIndex("IdPermiso");

                    b.HasIndex("IdRol");

                    b.ToTable("PermisosRoles");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Plantillas", b =>
                {
                    b.Property<int>("IdPlantilla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlantilla"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlantilla");

                    b.ToTable("Plantillas");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Publicaciones", b =>
                {
                    b.Property<int>("IdPublicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacion"));

                    b.Property<byte[]>("Audiovisual")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdEtiquera")
                        .HasColumnType("int");

                    b.Property<int>("IdEtiqueta")
                        .HasColumnType("int");

                    b.Property<int>("Visibilidad")
                        .HasColumnType("int");

                    b.HasKey("IdPublicacion");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdEtiquera");

                    b.ToTable("Publicaciones");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.RespuestaComentarios", b =>
                {
                    b.Property<int>("IdResComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResComentario"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdComentario")
                        .HasColumnType("int");

                    b.HasKey("IdResComentario");

                    b.HasIndex("IdComentario");

                    b.ToTable("RespuestaComentarios");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.CalificacionPublicaciones", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Publicaciones", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Comentarios", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Publicaciones", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Etiquetas", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Estados", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.PermisosRoles", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Permisos", "Permiso")
                        .WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechTrendsAppv1.Modelos.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Publicaciones", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Estados", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechTrendsAppv1.Modelos.Etiquetas", "Etiqueta")
                        .WithMany()
                        .HasForeignKey("IdEtiquera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Etiqueta");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.RespuestaComentarios", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Comentarios", "Comentario")
                        .WithMany()
                        .HasForeignKey("IdComentario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comentario");
                });

            modelBuilder.Entity("TechTrendsAppv1.Modelos.Usuarios", b =>
                {
                    b.HasOne("TechTrendsAppv1.Modelos.Roles", "rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });
#pragma warning restore 612, 618
        }
    }
}
