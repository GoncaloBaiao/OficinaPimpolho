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
                new Servico { IdServico = 1, Preco = "110€ - 600€", Nome = "Estofos", Image= "/images/estofoCarro.jpg" },
                new Servico { IdServico = 2, Preco = "85€ - 150€", Nome = "Vidros", Image = "/images/vidroReparo.jpg" },
                new Servico { IdServico = 3, Preco = "400€ - 650€", Nome = "Mecânica", Image = "/images/mecanica4.jpg" },
                new Servico { IdServico = 4, Preco = "100€ - 300€", Nome = "Pneus", Image = "/images/pneuReparo.jpg" },
                new Servico { IdServico = 5, Preco = "50€ - 880+€", Nome = "Bate-chapas", Image = "/images/bateChapas.jpg" },
                new Servico { IdServico = 6, Preco = "100€ - 995€", Nome = "Eletricidade/Eletrónica", Image = "/images/eletronica2.jpg" },
                new Servico { IdServico = 7, Preco = "300€ - 700€", Nome = "Pintura", Image = "/images/pintura.jpg" },
                new Servico { IdServico = 8, Preco = "30€ - 60€", Nome = "Assistência em Viagem", Image = "/images/assistencia2.jpg" }
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