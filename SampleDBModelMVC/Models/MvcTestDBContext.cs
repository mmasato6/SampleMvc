using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleDBModelMVC.Models
{
    public partial class MvcTestDBContext : DbContext
    {
        public MvcTestDBContext()
        {
        }

        public MvcTestDBContext(DbContextOptions<MvcTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Prefecture> Prefecture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrefectureId).HasColumnName("prefecture_id");

                entity.HasOne(d => d.Prefecture)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PrefectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_prefecture");
            });

            modelBuilder.Entity<Prefecture>(entity =>
            {
                entity.ToTable("prefecture");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10);
            });
        }
    }
}
