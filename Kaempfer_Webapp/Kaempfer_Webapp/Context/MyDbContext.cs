using System;
using System.Collections.Generic;
using Kaempfer_Webapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kaempfer_Webapp.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gewichtklasse> Gewichtklasse { get; set; }

    public virtual DbSet<Guertel> Guertel { get; set; }

    public virtual DbSet<Kaempfer?> Kaempfer { get; set; }

    public virtual DbSet<KaempferProTurnier> KaempferProTurnier { get; set; }

    public virtual DbSet<Kampfkunst> Kampfkunst { get; set; }

    public virtual DbSet<Turnier> Turnier { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-flat-grass-a2oyp2n4.eu-central-1.aws.neon.tech;Username=KaempferDB_owner;Password=DLRgWG3YSZ6I;Database=KaempferDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Gewichtklasse>(entity =>
        {
            entity.HasKey(e => e.Gewichtklasseid).HasName("gewichtklasse_pkey");

            entity.ToTable("gewichtklasse");

            entity.Property(e => e.Gewichtklasseid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("gewichtklasseid");
            entity.Property(e => e.Gewicht).HasColumnName("gewicht");
            entity.Property(e => e.Gewichtklasse1)
                .HasMaxLength(32)
                .HasColumnName("gewichtklasse");
        });

        modelBuilder.Entity<Guertel>(entity =>
        {
            entity.HasKey(e => e.Guertelid).HasName("guertel_pkey");

            entity.ToTable("guertel");

            entity.Property(e => e.Guertelid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("guertelid");
            entity.Property(e => e.DatumDerPruefung).HasColumnName("datum_der_pruefung");
            entity.Property(e => e.Guertelgrad).HasColumnName("guertelgrad");
        });

        modelBuilder.Entity<Kaempfer>(entity =>
        {
            entity.HasKey(e => e.Kaempferid).HasName("kaempfer_pkey");

            entity.ToTable("kaempfer");

            entity.Property(e => e.Kaempferid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("kaempferid");
            entity.Property(e => e.Geburtsdatum).HasColumnName("geburtsdatum");
            entity.Property(e => e.Nachname)
                .HasMaxLength(32)
                .HasColumnName("nachname");
            entity.Property(e => e.Vorname)
                .HasMaxLength(32)
                .HasColumnName("vorname");
        });

        modelBuilder.Entity<KaempferProTurnier>(entity =>
        {
            entity.HasKey(e => e.KaempferProTurnierid).HasName("kaempfer_pro_turnier_pkey");

            entity.ToTable("kaempfer_pro_turnier");

            entity.Property(e => e.KaempferProTurnierid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("kaempfer_pro_turnierid");
            entity.Property(e => e.Kaempferid).HasColumnName("kaempferid");
            entity.Property(e => e.Turnierid).HasColumnName("turnierid");

            entity.HasOne(d => d.Kaempfer).WithMany(p => p.KaempferProTurnier)
                .HasForeignKey(d => d.Kaempferid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_kaempfer");

            entity.HasOne(d => d.Turnier).WithMany(p => p.KaempferProTurnier)
                .HasForeignKey(d => d.Turnierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_turnier");
        });

        modelBuilder.Entity<Kampfkunst>(entity =>
        {
            entity.HasKey(e => e.Kampfkunstid).HasName("kampfkunst_pkey");

            entity.ToTable("kampfkunst");

            entity.Property(e => e.Kampfkunstid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("kampfkunstid");
            entity.Property(e => e.Kampfkunst1)
                .HasMaxLength(32)
                .HasColumnName("kampfkunst");
        });

        modelBuilder.Entity<Turnier>(entity =>
        {
            entity.HasKey(e => e.Turnierid).HasName("turnier_pkey");

            entity.ToTable("turnier");

            entity.Property(e => e.Turnierid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("turnierid");
            entity.Property(e => e.Ort)
                .HasMaxLength(32)
                .HasColumnName("ort");
            entity.Property(e => e.Turnierdatum).HasColumnName("turnierdatum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
