using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Models;

namespace OficinaPimpolho.Data;

public class OficinaPimpolhoContext : IdentityDbContext<IdentityUser>
{
    public OficinaPimpolhoContext(DbContextOptions<OficinaPimpolhoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<OficinaServico>()
        .HasKey(bc => new { bc.OficinaId, bc.ServicoId });
        builder.Entity<OficinaServico>()
            .HasOne(bc => bc.Oficina)
            .WithMany(b => b.OficinaServico)
            .HasForeignKey(bc => bc.OficinaId);
        builder.Entity<OficinaServico>()
            .HasOne(bc => bc.Servico)
            .WithMany(c => c.OficinaServico)
            .HasForeignKey(bc => bc.ServicoId);

        builder.Entity<MarcacaoServico>()
        .HasKey(cd => new { cd.MarcacaoId, cd.ServicoId });
        builder.Entity<MarcacaoServico>()
            .HasOne(cd => cd.Marcacao)
            .WithMany(d => d.MarcacaoServico)
            .HasForeignKey(bc => bc.MarcacaoId);
        builder.Entity<MarcacaoServico>()
            .HasOne(cd => cd.Servico)
            .WithMany(e => e.MarcacaoServico)
            .HasForeignKey(cd => cd.ServicoId);

        builder.Entity<Servico>().HasData(
                new Servico { IdServico = 1, Preco = 100.00, Nome = "Ar Condicionado" },
                new Servico { IdServico = 2, Preco = 170.00, Nome = "Estofos" },
                new Servico { IdServico = 3, Preco = 70.00, Nome = "Vidros" },
                new Servico { IdServico = 4, Preco = 200.00, Nome = "Mecânica" },
                new Servico { IdServico = 5, Preco = 50.00, Nome = "Pneus" },
                new Servico { IdServico = 6, Preco = 50.00, Nome = "Inspeção Periódica" },
                new Servico { IdServico = 7, Preco = 70.00, Nome = "Bate-chapas" },
                new Servico { IdServico = 8, Preco = 100.00, Nome = "Cortesia/Mobilidade" },
                new Servico { IdServico = 9, Preco = 150.00, Nome = "Eletricidade/Eletrónica" },
                new Servico { IdServico = 10, Preco = 10.00, Nome = "Lavagem" },
                new Servico { IdServico = 11, Preco = 90.00, Nome = "Pintura" },
                new Servico { IdServico = 12, Preco = 700.00, Nome = "Tuning" },
                new Servico { IdServico = 13, Preco = 250.00, Nome = "Assistência em Viagem" },
                new Servico { IdServico = 14, Preco = 40.00, Nome = "GPL Auto" }
                     );
        var listaOficinas = new List<Oficina> {
        new Oficina { IdOficina = 1, Nome = "JaquimOficina", Localidade = "Pinhal Novo", CodigoPostal = "1955-276", NumTelemovel="911111111"},
                        new Oficina { IdOficina = 2, Nome = "PimpolhoOficina", Localidade = "Castelo de paiva", CodigoPostal = "9754-476", NumTelemovel="911111112"},
                        new Oficina { IdOficina = 3, Nome = "DJ8Oficina", Localidade = "Marco de Canaveses", CodigoPostal = "7985-815", NumTelemovel="911111113"}
        };

        builder.Entity<Oficina>().HasData(
                        listaOficinas
                        );

        builder.Entity<Gestor>().HasData(
                new Gestor { IdGestor = 1, Nome = "Guita Pimpolho", Email = "celeste@gmail.com", Ntelemovel = "911111111", OficinaId=1 },
                new Gestor { IdGestor = 2, Nome = "Carlos Ribeiro", Email = "sarabatista@gmail.com", Ntelemovel = "911111112", OficinaId=2 },
                new Gestor { IdGestor = 3, Nome = "Joaquim Alberto", Email = "tinoni@gmail.com", Ntelemovel = "911111113", OficinaId=3 }
                     );
    }
    // Representar as Tabelas da BD
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Oficina> Oficina { get; set; }
    public DbSet<Marcacao> Marcacao { get; set; }
    public DbSet<Gestor> Gestor { get; set; }
    public DbSet<Servico> Servico { get; set; }

}