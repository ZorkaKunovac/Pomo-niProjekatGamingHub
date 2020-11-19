using Microsoft.EntityFrameworkCore;
using PomoćniProjekatGamingHub.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EF
{
    public class MojDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IgraZarn>()
                .HasKey(iz => new { iz.IgraID, iz.ZarnID });
            modelBuilder.Entity<IgraZarn>()
                .HasOne(iz => iz.Igra)
                .WithMany(i => i.IgraZarn)
                .HasForeignKey(iz => iz.IgraID);
            modelBuilder.Entity<IgraZarn>()
                .HasOne(iz => iz.Zarn)
                .WithMany(z => z.IgraZarn)
                .HasForeignKey(iz => iz.ZarnID);

            modelBuilder.Entity<IgraKonzola>()
                .HasKey(ik => new { ik.IgraID, ik.KonzolaID });
            modelBuilder.Entity<IgraKonzola>()
                .HasOne(ik => ik.Igra)
                .WithMany(i => i.IgraKonzola)
                .HasForeignKey(ik => ik.IgraID);
            modelBuilder.Entity<IgraKonzola>()
                .HasOne(ik => ik.Konzola)
                .WithMany(k => k.IgraKonzola)
                .HasForeignKey(ik => ik.KonzolaID);

            modelBuilder.Entity<IgraTag>()
                .HasKey(it => new { it.IgraID, it.TagID });
            modelBuilder.Entity<IgraTag>()
                .HasOne(it => it.Igra)
                .WithMany(i => i.IgraTag)
                .HasForeignKey(it => it.IgraID);
            modelBuilder.Entity<IgraTag>()
                .HasOne(it => it.Tag)
                .WithMany(t => t.IgraTag)
                .HasForeignKey(it => it.TagID);

            modelBuilder.Entity<Igra>()
                .HasOne(i => i.Proizvod)
                .WithOne(p => p.Igra)
                .HasForeignKey<Proizvod>(p => p.IgraID);
        }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Zarn> Zarn { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Igra> Igra { get; set; }
        public DbSet<IgraZarn> IgraZarn { get; set; }
        public DbSet<Konzola> Konzola { get; set; }
        public DbSet<IgraKonzola> IgraKonzola { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<IgraTag> IgraTag { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"	Server=localhost;
                                        	Database=PrvaVerzijaGAMINGHUB;
                                            Trusted_Connection=true;
                                            MultipleActiveResultSets=true;");
        }
       
    }
}
