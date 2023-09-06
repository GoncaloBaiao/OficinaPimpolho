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
        new Oficina { IdOficina = 1, Nome = "Auto Moderna", Localidade = "Setúbal", CodigoPostal = "2835-276", NumTelemovel="911111111", Image="/images/id1_boxcarvulcolisboa.jpg"},
                        new Oficina { IdOficina = 2, Nome = "Cuidado Carro", Localidade = "Faro", CodigoPostal = "8500-476", NumTelemovel="911111112", Image="/images/id10.jpg"},
                        new Oficina { IdOficina = 3, Nome = "Espaço Car", Localidade = "Beja", CodigoPostal = "7600-476", NumTelemovel="911111113", Image="/images/id11_corvauto.jpg"},
                        new Oficina { IdOficina = 4, Nome = "Esquina da Revisão", Localidade = "Santarém", CodigoPostal = "2140-476", NumTelemovel="911111114", Image="/images/id12.jpg"},
                        new Oficina { IdOficina = 5, Nome = "Império Car", Localidade = "Porto", CodigoPostal = "4560-476", NumTelemovel="911111115", Image="/images/id13_rinoauto.jpg"},
                        new Oficina { IdOficina = 6, Nome = "Mecânica Vila", Localidade = "Vila Nova de Gaia", CodigoPostal = "9754-476", NumTelemovel="911111116", Image="/images/id2_braga.jpg"},
                        new Oficina { IdOficina = 7, Nome = "Mundo dos Carros", Localidade = "Lisboa", CodigoPostal = "2695-476", NumTelemovel="911111117", Image="/images/id3_autoarcadgua2.jpg"},
                        new Oficina { IdOficina = 8, Nome = "Prime Car", Localidade = "Guarda", CodigoPostal = "6290-476", NumTelemovel="911111118", Image="/images/id4.jpg"},
                        new Oficina { IdOficina = 9, Nome = "SOS Car", Localidade = "Aveiro", CodigoPostal = "3780-476", NumTelemovel="911111119", Image="/images/id6_meiricarro.jpg"},
                        new Oficina { IdOficina = 10, Nome = "Rei da mecânica", Localidade = "Braga", CodigoPostal = "4740-476", NumTelemovel="911111120", Image="/images/id7_automotor.jpg"},
                        new Oficina { IdOficina = 11, Nome = "Pit Stop", Localidade = "Viseu", CodigoPostal = "3450-476", NumTelemovel="911111121", Image="/images/id8.jpg"},
                        new Oficina { IdOficina = 12, Nome = "Revisa Car", Localidade = "Bragança", CodigoPostal = "5300-815", NumTelemovel="911111122", Image="/images/id9_martinho.jpg"}
        };

        builder.Entity<Oficina>().HasData(
                        listaOficinas
                        );

       
    }
    // Representar as Tabelas da BD
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Oficina> Oficina { get; set; }
    public DbSet<Marcacao> Marcacao { get; set; }
    public DbSet<Gestor> Gestor { get; set; }
    public DbSet<Servico> Servico { get; set; }

}