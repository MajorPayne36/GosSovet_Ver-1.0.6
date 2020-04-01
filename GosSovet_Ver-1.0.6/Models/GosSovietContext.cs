using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GosSovet_Ver_1._0._6
{
    public partial class GosSovietContext : DbContext
    {
        public GosSovietContext()
        {
        }

        public GosSovietContext(DbContextOptions<GosSovietContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comission> Comission { get; set; }
        public virtual DbSet<DepAndCom> DepAndCom { get; set; }
        public virtual DbSet<Deputy> Deputy { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GM2O70F\\MSSQLDEV;Initial Catalog=GosSoviet;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comission>(entity =>
            {
                entity.HasKey(e => e.IdComission)
                    .HasName("PK_Comission_1");

                entity.Property(e => e.IdComission).HasColumnName("ID_Comission");

                entity.Property(e => e.ComissionName)
                    .IsRequired()
                    .HasColumnName("Comission_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.IdProfile).HasColumnName("ID_Profile");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.Comission)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comission_Profile");
            });

            modelBuilder.Entity<DepAndCom>(entity =>
            {
                entity.HasKey(e => e.IdDepCom)
                    .HasName("PK_Dep_and_Com_1");

                entity.ToTable("Dep_and_Com");

                entity.Property(e => e.IdDepCom).HasColumnName("ID_Dep_Com");

                entity.Property(e => e.DateIn)
                    .HasColumnName("Date_In")
                    .HasColumnType("date");

                entity.Property(e => e.DateOut)
                    .HasColumnName("Date_Out")
                    .HasColumnType("date");

                entity.Property(e => e.IdComission).HasColumnName("ID_Comission");

                entity.Property(e => e.IdDeputy).HasColumnName("ID_Deputy");

                entity.Property(e => e.IdPost).HasColumnName("ID_Post");

                entity.HasOne(d => d.IdComissionNavigation)
                    .WithMany(p => p.DepAndCom)
                    .HasForeignKey(d => d.IdComission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dep_and_Com_Comission");

                entity.HasOne(d => d.IdDeputyNavigation)
                    .WithMany(p => p.DepAndCom)
                    .HasForeignKey(d => d.IdDeputy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dep_and_Com_Deputy");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.DepAndCom)
                    .HasForeignKey(d => d.IdPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dep_and_Com_Post");
            });

            modelBuilder.Entity<Deputy>(entity =>
            {
                entity.HasKey(e => e.IdDeputy);

                entity.Property(e => e.IdDeputy).HasColumnName("ID_Deputy");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Fathername).HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.IdMeeting);

                entity.Property(e => e.IdMeeting).HasColumnName("ID_Meeting");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IdComission).HasColumnName("ID_Comission");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost);

                entity.Property(e => e.IdPost).HasColumnName("ID_Post");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("Post_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.Property(e => e.IdProfile).HasColumnName("ID_Profile");

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasColumnName("Profile_Name")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
