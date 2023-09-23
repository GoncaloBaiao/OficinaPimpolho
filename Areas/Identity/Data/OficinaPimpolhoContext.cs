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
    // Método de configuração de modelo
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
                new Servico { IdServico = 1, Preco = "110€ - 600€", Nome = "Estofos", Image= "estofoCarro.jpg" },
                new Servico { IdServico = 2, Preco = "85€ - 150€", Nome = "Vidros", Image = "vidroReparo.jpg" },
                new Servico { IdServico = 3, Preco = "400€ - 650€", Nome = "Mecânica", Image = "mecanica4.jpg" },
                new Servico { IdServico = 4, Preco = "100€ - 300€", Nome = "Pneus", Image = "pneuReparo.jpg" },
                new Servico { IdServico = 5, Preco = "50€ - 880+€", Nome = "Bate-chapas", Image = "bateChapas.jpg" },
                new Servico { IdServico = 6, Preco = "100€ - 995€", Nome = "Eletricidade/Eletrónica", Image = "eletronica2.jpg" },
                new Servico { IdServico = 7, Preco = "300€ - 700€", Nome = "Pintura", Image = "pintura.jpg" },
                new Servico { IdServico = 8, Preco = "30€ - 60€", Nome = "Assistência em Viagem", Image = "assistencia2.jpg" }
                     );

        builder.Entity<Oficina>().HasData(
                        new Oficina { IdOficina = 1001, Nome = "Auto Moderna", Localidade = "Setúbal", Morada = "Rua da Oficina, 123", CodigoPostal = "2835-276", NumTelemovel = "911111111", Image = "id1_boxcarvulcolisboa.jpg" },
                        new Oficina { IdOficina = 1002, Nome = "Cuidado Carro", Localidade = "Faro", Morada = "Avenida dos Reparos, 456", CodigoPostal = "8500-476", NumTelemovel = "911111112", Image = "id10.jpg" },
                        new Oficina { IdOficina = 1003, Nome = "Espaço Car", Localidade = "Beja", Morada = "Rua das Ferramentas, 789", CodigoPostal = "7600-476", NumTelemovel = "911111113", Image = "id11_corvauto.jpg" },
                        new Oficina { IdOficina = 1004, Nome = "Esquina da Revisão", Localidade = "Santarém", Morada = "Travessa dos Motores, 234", CodigoPostal = "2140-476", NumTelemovel = "911111114", Image = "id12.jpg" },
                        new Oficina { IdOficina = 1005, Nome = "Império Car", Localidade = "Porto", Morada = "Largo das Revisões, 567", CodigoPostal = "4560-476", NumTelemovel = "911111115", Image = "id13_rinoauto.jpg" },
                        new Oficina { IdOficina = 1006, Nome = "Mecânica Vila", Localidade = "Vila Nova de Gaia", Morada = "Praça das Soldaduras, 890", CodigoPostal = "9754-476", NumTelemovel = "911111116", Image = "id2_braga.jpg" },
                        new Oficina { IdOficina = 1007, Nome = "Mundo dos Carros", Localidade = "Lisboa", Morada = "Rua das Pinturas, 345", CodigoPostal = "2695-476", NumTelemovel = "911111117", Image = "id3_autoarcadgua2.jpg" },
                        new Oficina { IdOficina = 1008, Nome = "Prime Car", Localidade = "Guarda", Morada = "Avenida dos Veículos, 678", CodigoPostal = "6290-476", NumTelemovel = "911111118", Image = "id4.jpg" },
                        new Oficina { IdOficina = 1009, Nome = "SOS Car", Localidade = "Aveiro", Morada = "Rua dos Mecânicos, 901", CodigoPostal = "3780-476", NumTelemovel = "911111119", Image = "id6_meiricarro.jpg" },
                        new Oficina { IdOficina = 1010, Nome = "Rei da mecânica", Localidade = "Braga", Morada = "Travessa das Baterias, 234", CodigoPostal = "4740-476", NumTelemovel = "911111120", Image = "id7_automotor.jpg" },
                        new Oficina { IdOficina = 1011, Nome = "Pit Stop", Localidade = "Viseu", Morada = "Avenida das Transmissões, 567", CodigoPostal = "3450-476", NumTelemovel = "911111121", Image = "id8.jpg" },
                        new Oficina { IdOficina = 1012, Nome = "Revisa Car", Localidade = "Bragança", Morada = "Rua das Engrenagens, 890", CodigoPostal = "5300-815", NumTelemovel = "911111122", Image = "id9_martinho.jpg" }
                        );

       
    }
    // Métodos para representar as tabelas da BD
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Oficina> Oficina { get; set; }
    public DbSet<Marcacao> Marcacao { get; set; }
    public DbSet<Gestor> Gestor { get; set; }
    public DbSet<Servico> Servico { get; set; }
    public DbSet<MarcacaoServico> MarcacaoServicos { get; set; }

} 