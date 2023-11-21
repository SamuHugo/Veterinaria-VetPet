﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetPet.Database.VetContext;

namespace VetPet.Migrations
{
    [DbContext(typeof(VetContext))]
    partial class VetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VetPet.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("adminId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apeMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apePaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("VetPet.Models.AtencionMedicaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionAtenMed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAtenMed")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("TituloAtentoMed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("MedicoId");

                    b.ToTable("AtencionMedica");
                });

            modelBuilder.Entity("VetPet.Models.CategoriaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("VetPet.Models.CitaMedicaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AtencionMedicaId")
                        .HasColumnType("int");

                    b.Property<string>("DetalleCita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistorialMedicaId")
                        .HasColumnType("int");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SedeClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("TelefContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtencionMedicaId");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("HistorialMedicaId");

                    b.HasIndex("MascotaId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("SedeClinicaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CitaMedica");
                });

            modelBuilder.Entity("VetPet.Models.EnfermedadesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionEnferm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enfermedades");
                });

            modelBuilder.Entity("VetPet.Models.EspecialidadEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EspecialidadEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadEntityId");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("VetPet.Models.EstadoCivilEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadoCivil");
                });

            modelBuilder.Entity("VetPet.Models.EstadoVacunasEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DescripcionVacunas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EstadoVacunas");
                });

            modelBuilder.Entity("VetPet.Models.GeneroEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("VetPet.Models.HistorialMedicoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("HistorialMedico");
                });

            modelBuilder.Entity("VetPet.Models.MarcaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("VetPet.Models.MascotaEnfermedades", b =>
                {
                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("EnfermedadesId")
                        .HasColumnType("int");

                    b.HasKey("MascotaId", "EnfermedadesId");

                    b.HasIndex("EnfermedadesId");

                    b.ToTable("MascotaEnfermedades");
                });

            modelBuilder.Entity("VetPet.Models.MascotaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAdopcion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int?>("HistorialMedicoId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MascotaEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RazaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("HistorialMedicoId");

                    b.HasIndex("MascotaEntityId");

                    b.HasIndex("RazaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("VetPet.Models.MascotaVacunas", b =>
                {
                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoVacunasId")
                        .HasColumnType("int");

                    b.HasKey("MascotaId", "EstadoVacunasId");

                    b.HasIndex("EstadoVacunasId");

                    b.ToTable("MascotaVacunas");
                });

            modelBuilder.Entity("VetPet.Models.MedicacionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionMedicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Medicacion");
                });

            modelBuilder.Entity("VetPet.Models.MedicoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoCivilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int?>("HistorialMedicoId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SedeClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("HistorialMedicoId");

                    b.HasIndex("SedeClinicaId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("VetPet.Models.ProductoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaracteristicasProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nonbre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("TipoAnimalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoAnimalId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("VetPet.Models.RazaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Raza");
                });

            modelBuilder.Entity("VetPet.Models.SedeClinicaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SedeClinica");
                });

            modelBuilder.Entity("VetPet.Models.TipoAnimalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoAnimal");
                });

            modelBuilder.Entity("VetPet.Models.TipoDocumentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioEntityId");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("VetPet.Models.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("VetPet.Models.AtencionMedicaEntity", b =>
                {
                    b.HasOne("VetPet.Models.MascotaEntity", "Mascota")
                        .WithMany("AtencionMedica")
                        .HasForeignKey("MascotaId");

                    b.HasOne("VetPet.Models.MedicoEntity", "Medico")
                        .WithMany("AtencionMedica")
                        .HasForeignKey("MedicoId");
                });

            modelBuilder.Entity("VetPet.Models.CitaMedicaEntity", b =>
                {
                    b.HasOne("VetPet.Models.AtencionMedicaEntity", "AtencionMedica")
                        .WithMany("CitaMedica")
                        .HasForeignKey("AtencionMedicaId");

                    b.HasOne("VetPet.Models.EspecialidadEntity", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId");

                    b.HasOne("VetPet.Models.HistorialMedicoEntity", "HistorialMedica")
                        .WithMany("CitaMedica")
                        .HasForeignKey("HistorialMedicaId");

                    b.HasOne("VetPet.Models.MascotaEntity", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId");

                    b.HasOne("VetPet.Models.MedicoEntity", "Medico")
                        .WithMany("CitaMedica")
                        .HasForeignKey("MedicoId");

                    b.HasOne("VetPet.Models.SedeClinicaEntity", "SedeClinica")
                        .WithMany("CitaMedica")
                        .HasForeignKey("SedeClinicaId");

                    b.HasOne("VetPet.Models.UsuarioEntity", "Usuario")
                        .WithMany("CitaMedica")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("VetPet.Models.EspecialidadEntity", b =>
                {
                    b.HasOne("VetPet.Models.EspecialidadEntity", null)
                        .WithMany("Especialidad")
                        .HasForeignKey("EspecialidadEntityId");
                });

            modelBuilder.Entity("VetPet.Models.MascotaEnfermedades", b =>
                {
                    b.HasOne("VetPet.Models.EnfermedadesEntity", "EnfermedadesEntity")
                        .WithMany("MascotaEnfermedades")
                        .HasForeignKey("EnfermedadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetPet.Models.MascotaEntity", "MascotaEntity")
                        .WithMany("MascotaEnfermedades")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetPet.Models.MascotaEntity", b =>
                {
                    b.HasOne("VetPet.Models.GeneroEntity", "Genero")
                        .WithMany("Mascota")
                        .HasForeignKey("GeneroId");

                    b.HasOne("VetPet.Models.HistorialMedicoEntity", "HistorialMedico")
                        .WithMany("Mascota")
                        .HasForeignKey("HistorialMedicoId");

                    b.HasOne("VetPet.Models.MascotaEntity", null)
                        .WithMany("Mascota")
                        .HasForeignKey("MascotaEntityId");

                    b.HasOne("VetPet.Models.RazaEntity", "Raza")
                        .WithMany("Mascota")
                        .HasForeignKey("RazaId");

                    b.HasOne("VetPet.Models.UsuarioEntity", "Usuario")
                        .WithMany("Mascota")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("VetPet.Models.MascotaVacunas", b =>
                {
                    b.HasOne("VetPet.Models.EstadoVacunasEntity", "EstadoVacunasEntity")
                        .WithMany("MascotaVacunas")
                        .HasForeignKey("EstadoVacunasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetPet.Models.MascotaEntity", "MascotaEntity")
                        .WithMany("MascotaVacunas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetPet.Models.MedicacionEntity", b =>
                {
                    b.HasOne("VetPet.Models.MascotaEntity", "Mascota")
                        .WithMany("Medicacion")
                        .HasForeignKey("MascotaId");
                });

            modelBuilder.Entity("VetPet.Models.MedicoEntity", b =>
                {
                    b.HasOne("VetPet.Models.EspecialidadEntity", "Especialidad")
                        .WithMany("Medico")
                        .HasForeignKey("EspecialidadId");

                    b.HasOne("VetPet.Models.EstadoCivilEntity", "EstadoCivil")
                        .WithMany("Medico")
                        .HasForeignKey("EstadoCivilId");

                    b.HasOne("VetPet.Models.GeneroEntity", "Genero")
                        .WithMany("Medico")
                        .HasForeignKey("GeneroId");

                    b.HasOne("VetPet.Models.HistorialMedicoEntity", "HistorialMedico")
                        .WithMany("Medico")
                        .HasForeignKey("HistorialMedicoId");

                    b.HasOne("VetPet.Models.SedeClinicaEntity", "SedeClinica")
                        .WithMany("Medico")
                        .HasForeignKey("SedeClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetPet.Models.TipoDocumentoEntity", "TipoDocumento")
                        .WithMany("Medico")
                        .HasForeignKey("TipoDocumentoId");
                });

            modelBuilder.Entity("VetPet.Models.ProductoEntity", b =>
                {
                    b.HasOne("VetPet.Models.CategoriaEntity", "Categoria")
                        .WithMany("Producto")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("VetPet.Models.MarcaEntity", "Marca")
                        .WithMany("Producto")
                        .HasForeignKey("MarcaId");

                    b.HasOne("VetPet.Models.TipoAnimalEntity", "TipoAnimal")
                        .WithMany("Producto")
                        .HasForeignKey("TipoAnimalId");
                });

            modelBuilder.Entity("VetPet.Models.TipoDocumentoEntity", b =>
                {
                    b.HasOne("VetPet.Models.UsuarioEntity", null)
                        .WithMany("TipoDocumento")
                        .HasForeignKey("UsuarioEntityId");
                });

            modelBuilder.Entity("VetPet.Models.UsuarioEntity", b =>
                {
                    b.HasOne("VetPet.Models.GeneroEntity", "Genero")
                        .WithMany("Usuario")
                        .HasForeignKey("GeneroId");
                });
#pragma warning restore 612, 618
        }
    }
}
