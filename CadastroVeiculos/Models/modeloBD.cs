using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CadastroVeiculos.Models
{
    public partial class modeloBD : DbContext
    {
        public modeloBD()
            : base("name=modeloBD")
        {
        }

        public virtual DbSet<TBLimagem> TBLimagem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLimagem>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<TBLimagem>()
                .Property(e => e.Renavan)
                .IsUnicode(false);

            modelBuilder.Entity<TBLimagem>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<TBLimagem>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<TBLimagem>()
                .Property(e => e.imagem)
                .IsUnicode(false);
        }
    }
}
