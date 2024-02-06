using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OfficeReestr.OfficeReestrModel;

public partial class CompReestrDbContext : DbContext
{
    public CompReestrDbContext()
    {
    }

    public CompReestrDbContext(DbContextOptions<CompReestrDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CompReestrDB;Username=postgres;Password=2804");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.ComponentId).HasName("components_pkey");

            entity.ToTable("components");

            entity.Property(e => e.ComponentId).HasColumnName("component_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(150)
                .HasColumnName("serial_number");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Components)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("components_equipment_id_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.DateOfTermination).HasColumnName("date_of_termination");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Position)
                .HasMaxLength(150)
                .HasColumnName("position");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Ipadres)
                .HasMaxLength(150)
                .HasColumnName("ipadres");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(150)
                .HasColumnName("serial_number");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => e.MovementId).HasName("movements_pkey");

            entity.ToTable("movements");

            entity.Property(e => e.MovementId).HasColumnName("movement_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.MovementDate).HasColumnName("movement_date");
            entity.Property(e => e.SourceRoomId).HasColumnName("source_room_id");
            entity.Property(e => e.TargetRoomId).HasColumnName("target_room_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Movements)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("movements_employee_id_fkey");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Movements)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("movements_equipment_id_fkey");

            entity.HasOne(d => d.SourceRoom).WithMany(p => p.MovementSourceRooms)
                .HasForeignKey(d => d.SourceRoomId)
                .HasConstraintName("movements_source_room_id_fkey");

            entity.HasOne(d => d.TargetRoom).WithMany(p => p.MovementTargetRooms)
                .HasForeignKey(d => d.TargetRoomId)
                .HasConstraintName("movements_target_room_id_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomNumber)
                .HasColumnType("character varying")
                .HasColumnName("room_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
