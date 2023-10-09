using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VetPet.Models;

namespace VetPet.Database.VetContext
{
    public class VetContext : DbContext
    { 
        public VetContext(DbContextOptions<VetContext> options): base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AtencionMedicaEntity> AtencionMedica { get; set; }
        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<CitaMedicaEntity> CitaMedica { get; set; }
        public DbSet<EnfermedadesEntity> Enfermedades { get; set; }
        public DbSet<EspecialidadEntity> Especialidad { get; set; }
        public DbSet<EstadoCivilEntity> EstadoCivil { get; set; }
        public DbSet<EstadoVacunasEntity> EstadoVacunas { get; set; }
        public DbSet<GeneroEntity> Genero { get; set; }
        public DbSet<HistorialMedicoEntity> HistorialMedico { get; set; }
        public DbSet<MarcaEntity> Marca { get; set; }
        public DbSet<MascotaEnfermedades> MascotaEnfermedades { get; set; }
        public DbSet<MascotaEntity> Mascota { get; set; }
        public DbSet<MascotaVacunas> MascotaVacunas { get; set; }
        public DbSet<MedicacionEntity> Medicacion { get; set; }
        public DbSet<MedicoEntity> Medico { get; set; }
        public DbSet<ProductoEntity> Producto { get; set; }
        public DbSet<RazaEntity> Raza { get; set; }
        public DbSet<SedeClinicaEntity> SedeClinica { get; set; }
        public DbSet<TipoAnimalEntity> TipoAnimal { get; set; }
        public DbSet<TipoDocumentoEntity> TipoDocumento { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MascotaEnfermedades>().HasKey(pc => new { pc.MascotaId, pc.EnfermedadesId });
            modelBuilder.Entity<MascotaEnfermedades>().HasOne(p => p.MascotaEntity).WithMany(pc => pc.MascotaEnfermedades).HasForeignKey(p => p.MascotaId);
            modelBuilder.Entity<MascotaEnfermedades>().HasOne(p => p.EnfermedadesEntity).WithMany(pc => pc.MascotaEnfermedades).HasForeignKey(c => c.EnfermedadesId);

            modelBuilder.Entity<MascotaVacunas>().HasKey(po => new { po.MascotaId, po.EstadoVacunasId });
            modelBuilder.Entity<MascotaVacunas>().HasOne(p => p.MascotaEntity).WithMany(pc => pc.MascotaVacunas).HasForeignKey(p => p.MascotaId);
            modelBuilder.Entity<MascotaVacunas>().HasOne(p => p.EstadoVacunasEntity).WithMany(pc => pc.MascotaVacunas).HasForeignKey(c => c.EstadoVacunasId);
        }


    }
}
