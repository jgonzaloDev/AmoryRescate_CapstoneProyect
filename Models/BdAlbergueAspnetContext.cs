using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Albergue_aspnet_DAS.Models;

public partial class BdAlbergueAspnetContext : DbContext
{
    public BdAlbergueAspnetContext()
    {
    }

    public BdAlbergueAspnetContext(DbContextOptions<BdAlbergueAspnetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdopcion> TbAdopcions { get; set; }

    public virtual DbSet<TbAlbergue> TbAlbergues { get; set; }

    public virtual DbSet<TbDistrito> TbDistritos { get; set; }

    public virtual DbSet<TbHistorialAtencionMascotum> TbHistorialAtencionMascota { get; set; }

    public virtual DbSet<TbMascotum> TbMascota { get; set; }

    public virtual DbSet<TbProvincia> TbProvincias { get; set; }

    public virtual DbSet<TbRazaMascotum> TbRazaMascota { get; set; }

    public virtual DbSet<TbRolesUsuario> TbRolesUsuarios { get; set; }

    public virtual DbSet<TbTipoMascotum> TbTipoMascota { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdopcion>(entity =>
        {
            entity.HasKey(e => e.IdAdop).HasName("PK__TB_ADOPC__B431877B7ECAC70A");

            entity.ToTable("TB_ADOPCION");

            entity.Property(e => e.IdAdop).HasColumnName("id_adop");
            entity.Property(e => e.DireccionUs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion_us");
            entity.Property(e => e.DniUs)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dni_us");
            entity.Property(e => e.FechaAdop).HasColumnName("fecha_adop");
            entity.Property(e => e.IdMas).HasColumnName("id_mas");
            entity.Property(e => e.IdUs).HasColumnName("id_us");
            entity.Property(e => e.Obs10Adop)
                .HasColumnType("text")
                .HasColumnName("obs10_adop");
            entity.Property(e => e.Obs1Adop)
                .HasColumnType("text")
                .HasColumnName("obs1_adop");
            entity.Property(e => e.Obs2Adop)
                .HasColumnType("text")
                .HasColumnName("obs2_adop");
            entity.Property(e => e.Obs3Adop)
                .HasColumnType("text")
                .HasColumnName("obs3_adop");
            entity.Property(e => e.Obs4Adop)
                .HasColumnType("text")
                .HasColumnName("obs4_adop");
            entity.Property(e => e.Obs5Adop)
                .HasColumnType("text")
                .HasColumnName("obs5_adop");
            entity.Property(e => e.Obs6Adop)
                .HasColumnType("text")
                .HasColumnName("obs6_adop");
            entity.Property(e => e.Obs7Adop)
                .HasColumnType("text")
                .HasColumnName("obs7_adop");
            entity.Property(e => e.Obs8Adop)
                .HasColumnType("text")
                .HasColumnName("obs8_adop");
            entity.Property(e => e.Obs9Adop)
                .HasColumnType("text")
                .HasColumnName("obs9_adop");
            entity.Property(e => e.TelefonoUs)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono_us");

            entity.HasOne(d => d.IdMasNavigation).WithMany(p => p.TbAdopcions)
                .HasForeignKey(d => d.IdMas)
                .HasConstraintName("Fk_ADOPID_MAS_CODIGO");

            entity.HasOne(d => d.IdUsNavigation).WithMany(p => p.TbAdopcions)
                .HasForeignKey(d => d.IdUs)
                .HasConstraintName("Fk_ADOPID_USU_CODIGO");
        });

        modelBuilder.Entity<TbAlbergue>(entity =>
        {
            entity.HasKey(e => e.IdAlb).HasName("PK__TB_ALBER__6BE93B0C3C2AB683");

            entity.ToTable("TB_ALBERGUE");

            entity.Property(e => e.IdAlb).HasColumnName("id_alb");
            entity.Property(e => e.CapacidadAlb).HasColumnName("capacidad_alb");
            entity.Property(e => e.CorreoAlb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_alb");
            entity.Property(e => e.DireccionAlb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion_alb");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDist).HasColumnName("id_dist");
            entity.Property(e => e.IdProv).HasColumnName("id_prov");
            entity.Property(e => e.NombreAlb)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_alb");

            entity.HasOne(d => d.oDistrito).WithMany(p => p.TbAlbergues)
                .HasForeignKey(d => d.IdDist)
                .HasConstraintName("Fk_ADIST_CODIGO");

            entity.HasOne(d => d.oProvincia).WithMany(p => p.TbAlbergues)
                .HasForeignKey(d => d.IdProv)
                .HasConstraintName("Fk_APROV_CODIGO");
        });

        modelBuilder.Entity<TbDistrito>(entity =>
        {
            entity.HasKey(e => e.IdDist).HasName("PK__TB_DISTR__972B439DCE608B8D");

            entity.ToTable("TB_DISTRITOS");

            entity.Property(e => e.IdDist).HasColumnName("id_dist");
            entity.Property(e => e.DescripcionDist)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_dist");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TbHistorialAtencionMascotum>(entity =>
        {
            entity.HasKey(e => e.IdHis).HasName("PK__TB_HISTO__D6EA82DD553CD8C8");

            entity.ToTable("TB_HISTORIAL_ATENCION_MASCOTA");

            entity.Property(e => e.IdHis).HasColumnName("id_his");
            entity.Property(e => e.ApellidosMed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos_med");
            entity.Property(e => e.CodColegiatura)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cod_colegiatura");
            entity.Property(e => e.ConsultaMedica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consulta_medica");
            entity.Property(e => e.IdMas).HasColumnName("id_mas");
            entity.Property(e => e.NombreMed)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_med");
            entity.Property(e => e.Observacion)
                .HasColumnType("text")
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdMasNavigation).WithMany(p => p.TbHistorialAtencionMascota)
                .HasForeignKey(d => d.IdMas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_HIS_CODIGO");
        });

        modelBuilder.Entity<TbMascotum>(entity =>
        {
            entity.HasKey(e => e.IdMas).HasName("PK__TB_MASCO__6C8AD5B02239F910");

            entity.ToTable("TB_MASCOTA");

            entity.Property(e => e.IdMas).HasColumnName("id_mas");
            entity.Property(e => e.ColorMas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("color_mas");
            entity.Property(e => e.EdadMas)
                .HasComputedColumnSql("(datediff(year,[fecha_nac_mas],getdate()))", false)
                .HasColumnName("edad_mas");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNacMas).HasColumnName("fecha_nac_mas");
            entity.Property(e => e.IdAlb).HasColumnName("id_alb");
            entity.Property(e => e.IdRazMas).HasColumnName("id_raz_mas");
            entity.Property(e => e.IdTipMas).HasColumnName("id_tip_mas");
            entity.Property(e => e.ImagenMas)
                .HasColumnType("image")
                .HasColumnName("imagen_mas");
            entity.Property(e => e.NombreMas)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_mas");
            entity.Property(e => e.SexoMas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo_mas");
            entity.Property(e => e.TamanioMas)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tamaño_mas");

            entity.HasOne(d => d.oAlbergue).WithMany(p => p.TbMascota)
                .HasForeignKey(d => d.IdAlb)
                .HasConstraintName("Fk_Mraz_ALB_CODIGO");

            entity.HasOne(d => d.oRazaMascota).WithMany(p => p.TbMascota)
                .HasForeignKey(d => d.IdRazMas)
                .HasConstraintName("Fk_Mraz_MAs_CODIGO");

            entity.HasOne(d => d.oTipoMascota).WithMany(p => p.TbMascota)
                .HasForeignKey(d => d.IdTipMas)
                .HasConstraintName("Fk_MTIP_MAS_CODIGO");
        });

        modelBuilder.Entity<TbProvincia>(entity =>
        {
            entity.HasKey(e => e.IdProv).HasName("PK__TB_PROVI__0DA3485D97828659");

            entity.ToTable("TB_PROVINCIAS");

            entity.Property(e => e.IdProv).HasColumnName("id_prov");
            entity.Property(e => e.DescripcionProv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_prov");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TbRazaMascotum>(entity =>
        {
            entity.HasKey(e => e.IdRazMas).HasName("PK__TB_RAZA___7290F9FDDD9B4FF3");

            entity.ToTable("TB_RAZA_MASCOTA");

            entity.Property(e => e.IdRazMas).HasColumnName("id_raz_mas");
            entity.Property(e => e.DescripcionRazMas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion_raz_mas");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TbRolesUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__TB_ROLES__6ABCB5E073930C9B");

            entity.ToTable("TB_ROLES_USUARIO");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<TbTipoMascotum>(entity =>
        {
            entity.HasKey(e => e.IdTipMas).HasName("PK__TB_TIPO___1904A0A36E0CBF11");

            entity.ToTable("TB_TIPO_MASCOTA");

            entity.Property(e => e.IdTipMas).HasColumnName("id_tip_mas");
            entity.Property(e => e.DescripcionTipMas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion_tip_mas");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUs).HasName("PK__TB_USUAR__014848A59A0E52CB");

            entity.ToTable("TB_USUARIOS");

            entity.Property(e => e.IdUs).HasColumnName("id_us");
            entity.Property(e => e.ClaveUs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clave_us");
            entity.Property(e => e.CorreoUs)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo_us");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.ImagenUs)
                .HasColumnType("image")
                .HasColumnName("imagen_us");
            entity.Property(e => e.NombreUs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_us");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Fk_USUID_ROL_CODIGO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
