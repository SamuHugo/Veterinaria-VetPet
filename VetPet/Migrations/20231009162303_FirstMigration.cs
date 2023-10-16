using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPet.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(nullable: true),
                    apePaterno = table.Column<string>(nullable: true),
                    apeMaterno = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    contraseña = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEnferm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    EspecialidadEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidad_Especialidad_EspecialidadEntityId",
                        column: x => x.EspecialidadEntityId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstadoVacunas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionVacunas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoVacunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialMedico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SedeClinica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeClinica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnimal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    SedeClinicaId = table.Column<int>(nullable: false),
                    SedeClinicaEntityId = table.Column<int>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    EspecialidadEntityId = table.Column<int>(nullable: true),
                    DescripProfesional = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    HistorialMedicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidad_EspecialidadEntityId",
                        column: x => x.EspecialidadEntityId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medico_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medico_SedeClinica_SedeClinicaEntityId",
                        column: x => x.SedeClinicaEntityId,
                        principalTable: "SedeClinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Nonbre = table.Column<string>(nullable: true),
                    DescripcionProd = table.Column<string>(nullable: true),
                    CaracteristicasProd = table.Column<string>(nullable: true),
                    MarcaId = table.Column<int>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: true),
                    TipoAnimalId = table.Column<int>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_TipoAnimal_TipoAnimalId",
                        column: x => x.TipoAnimalId,
                        principalTable: "TipoAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apodo = table.Column<string>(nullable: true),
                    RazaId = table.Column<int>(nullable: true),
                    FechaAdopcion = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    HistorialMedicoId = table.Column<int>(nullable: true),
                    MascotaEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Mascota_MascotaEntityId",
                        column: x => x.MascotaEntityId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoCivil_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    UsuarioEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDocumento_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoDocumento_Usuario_UsuarioEntityId",
                        column: x => x.UsuarioEntityId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtencionMedica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloAtentoMed = table.Column<string>(nullable: true),
                    FechaAtenMed = table.Column<DateTime>(nullable: false),
                    MedicoId = table.Column<int>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true),
                    DescripcionAtenMed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtencionMedica_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtencionMedica_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true),
                    UsuarioEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genero_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genero_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genero_Usuario_UsuarioEntityId",
                        column: x => x.UsuarioEntityId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MascotaEnfermedades",
                columns: table => new
                {
                    MascotaId = table.Column<int>(nullable: false),
                    EnfermedadesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaEnfermedades", x => new { x.MascotaId, x.EnfermedadesId });
                    table.ForeignKey(
                        name: "FK_MascotaEnfermedades_Enfermedades_EnfermedadesId",
                        column: x => x.EnfermedadesId,
                        principalTable: "Enfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MascotaEnfermedades_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MascotaVacunas",
                columns: table => new
                {
                    MascotaId = table.Column<int>(nullable: false),
                    EstadoVacunasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaVacunas", x => new { x.MascotaId, x.EstadoVacunasId });
                    table.ForeignKey(
                        name: "FK_MascotaVacunas_EstadoVacunas_EstadoVacunasId",
                        column: x => x.EstadoVacunasId,
                        principalTable: "EstadoVacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MascotaVacunas_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionMedicamento = table.Column<string>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicacion_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitaMedica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(nullable: true),
                    SedeClinicaId = table.Column<int>(nullable: true),
                    EspecialidadId = table.Column<int>(nullable: true),
                    MedicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true),
                    FechaCita = table.Column<DateTime>(nullable: false),
                    TelefContacto = table.Column<string>(nullable: true),
                    DetalleCita = table.Column<string>(nullable: true),
                    AtencionMedicaId = table.Column<int>(nullable: true),
                    HistorialMedicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaMedica_AtencionMedica_AtencionMedicaId",
                        column: x => x.AtencionMedicaId,
                        principalTable: "AtencionMedica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_HistorialMedico_HistorialMedicaId",
                        column: x => x.HistorialMedicaId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_SedeClinica_SedeClinicaId",
                        column: x => x.SedeClinicaId,
                        principalTable: "SedeClinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtencionMedica_MascotaId",
                table: "AtencionMedica",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtencionMedica_MedicoId",
                table: "AtencionMedica",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_AtencionMedicaId",
                table: "CitaMedica",
                column: "AtencionMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_EspecialidadId",
                table: "CitaMedica",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_HistorialMedicaId",
                table: "CitaMedica",
                column: "HistorialMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_MascotaId",
                table: "CitaMedica",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_MedicoId",
                table: "CitaMedica",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_SedeClinicaId",
                table: "CitaMedica",
                column: "SedeClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_UsuarioId",
                table: "CitaMedica",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidad_EspecialidadEntityId",
                table: "Especialidad",
                column: "EspecialidadEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCivil_MedicoId",
                table: "EstadoCivil",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_MascotaId",
                table: "Genero",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_MedicoId",
                table: "Genero",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_UsuarioEntityId",
                table: "Genero",
                column: "UsuarioEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_HistorialMedicoId",
                table: "Mascota",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_MascotaEntityId",
                table: "Mascota",
                column: "MascotaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_RazaId",
                table: "Mascota",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_UsuarioId",
                table: "Mascota",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaEnfermedades_EnfermedadesId",
                table: "MascotaEnfermedades",
                column: "EnfermedadesId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaVacunas_EstadoVacunasId",
                table: "MascotaVacunas",
                column: "EstadoVacunasId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacion_MascotaId",
                table: "Medicacion",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadEntityId",
                table: "Medico",
                column: "EspecialidadEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_HistorialMedicoId",
                table: "Medico",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_SedeClinicaEntityId",
                table: "Medico",
                column: "SedeClinicaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoAnimalId",
                table: "Producto",
                column: "TipoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_MedicoId",
                table: "TipoDocumento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_UsuarioEntityId",
                table: "TipoDocumento",
                column: "UsuarioEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CitaMedica");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "MascotaEnfermedades");

            migrationBuilder.DropTable(
                name: "MascotaVacunas");

            migrationBuilder.DropTable(
                name: "Medicacion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "AtencionMedica");

            migrationBuilder.DropTable(
                name: "Enfermedades");

            migrationBuilder.DropTable(
                name: "EstadoVacunas");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "TipoAnimal");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "HistorialMedico");

            migrationBuilder.DropTable(
                name: "SedeClinica");
        }
    }
}
