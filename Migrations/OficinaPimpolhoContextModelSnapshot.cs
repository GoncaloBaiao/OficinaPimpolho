﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OficinaPimpolho.Data;

#nullable disable

namespace OficinaPimpolho.Migrations
{
    [DbContext(typeof(OficinaPimpolhoContext))]
    partial class OficinaPimpolhoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Cliente", b =>
                {
                    b.Property<int>("IdClientes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientes"), 1L, 1);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Apelido");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MarcacaoIdMarcacao")
                        .HasColumnType("int");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Ntelemovel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PrimeiroNome");

                    b.HasKey("IdClientes");

                    b.HasIndex("MarcacaoIdMarcacao");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Gestor", b =>
                {
                    b.Property<int>("IdGestor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGestor"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Ntelemovel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("OficinaId")
                        .HasColumnType("int");

                    b.HasKey("IdGestor");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Marcacao", b =>
                {
                    b.Property<int>("IdMarcacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarcacao"), 1L, 1);

                    b.Property<DateTime>("DataMarcacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("IdMarcacao");

                    b.ToTable("Marcacao");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.MarcacaoServico", b =>
                {
                    b.Property<int>("MarcacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("MarcacaoId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("MarcacaoServico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Oficina", b =>
                {
                    b.Property<int>("IdOficina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOficina"), 1L, 1);

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NumTelemovel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("IdOficina");

                    b.ToTable("Oficina");

                    b.HasData(
                        new
                        {
                            IdOficina = 1001,
                            CodigoPostal = "2835-276",
                            Image = "/images/id1_boxcarvulcolisboa.jpg",
                            Localidade = "Setúbal",
                            Nome = "Auto Moderna",
                            NumTelemovel = "911111111"
                        },
                        new
                        {
                            IdOficina = 1002,
                            CodigoPostal = "8500-476",
                            Image = "/images/id10.jpg",
                            Localidade = "Faro",
                            Nome = "Cuidado Carro",
                            NumTelemovel = "911111112"
                        },
                        new
                        {
                            IdOficina = 1003,
                            CodigoPostal = "7600-476",
                            Image = "/images/id11_corvauto.jpg",
                            Localidade = "Beja",
                            Nome = "Espaço Car",
                            NumTelemovel = "911111113"
                        },
                        new
                        {
                            IdOficina = 1004,
                            CodigoPostal = "2140-476",
                            Image = "/images/id12.jpg",
                            Localidade = "Santarém",
                            Nome = "Esquina da Revisão",
                            NumTelemovel = "911111114"
                        },
                        new
                        {
                            IdOficina = 1005,
                            CodigoPostal = "4560-476",
                            Image = "/images/id13_rinoauto.jpg",
                            Localidade = "Porto",
                            Nome = "Império Car",
                            NumTelemovel = "911111115"
                        },
                        new
                        {
                            IdOficina = 1006,
                            CodigoPostal = "9754-476",
                            Image = "/images/id2_braga.jpg",
                            Localidade = "Vila Nova de Gaia",
                            Nome = "Mecânica Vila",
                            NumTelemovel = "911111116"
                        },
                        new
                        {
                            IdOficina = 1007,
                            CodigoPostal = "2695-476",
                            Image = "/images/id3_autoarcadgua2.jpg",
                            Localidade = "Lisboa",
                            Nome = "Mundo dos Carros",
                            NumTelemovel = "911111117"
                        },
                        new
                        {
                            IdOficina = 1008,
                            CodigoPostal = "6290-476",
                            Image = "/images/id4.jpg",
                            Localidade = "Guarda",
                            Nome = "Prime Car",
                            NumTelemovel = "911111118"
                        },
                        new
                        {
                            IdOficina = 1009,
                            CodigoPostal = "3780-476",
                            Image = "/images/id6_meiricarro.jpg",
                            Localidade = "Aveiro",
                            Nome = "SOS Car",
                            NumTelemovel = "911111119"
                        },
                        new
                        {
                            IdOficina = 1010,
                            CodigoPostal = "4740-476",
                            Image = "/images/id7_automotor.jpg",
                            Localidade = "Braga",
                            Nome = "Rei da mecânica",
                            NumTelemovel = "911111120"
                        },
                        new
                        {
                            IdOficina = 1011,
                            CodigoPostal = "3450-476",
                            Image = "/images/id8.jpg",
                            Localidade = "Viseu",
                            Nome = "Pit Stop",
                            NumTelemovel = "911111121"
                        },
                        new
                        {
                            IdOficina = 1012,
                            CodigoPostal = "5300-815",
                            Image = "/images/id9_martinho.jpg",
                            Localidade = "Bragança",
                            Nome = "Revisa Car",
                            NumTelemovel = "911111122"
                        });
                });

            modelBuilder.Entity("OficinaPimpolho.Models.OficinaServico", b =>
                {
                    b.Property<int>("OficinaId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("OficinaId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("OficinaServico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Servico", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServico"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdServico");

                    b.ToTable("Servico");

                    b.HasData(
                        new
                        {
                            IdServico = 1,
                            Image = "/images/estofoCarro.jpg",
                            Nome = "Estofos",
                            Preco = "110€ - 600€"
                        },
                        new
                        {
                            IdServico = 2,
                            Image = "/images/vidroReparo.jpg",
                            Nome = "Vidros",
                            Preco = "85€ - 150€"
                        },
                        new
                        {
                            IdServico = 3,
                            Image = "/images/mecanica4.jpg",
                            Nome = "Mecânica",
                            Preco = "400€ - 650€"
                        },
                        new
                        {
                            IdServico = 4,
                            Image = "/images/pneuReparo.jpg",
                            Nome = "Pneus",
                            Preco = "100€ - 300€"
                        },
                        new
                        {
                            IdServico = 5,
                            Image = "/images/bateChapas.jpg",
                            Nome = "Bate-chapas",
                            Preco = "50€ - 880+€"
                        },
                        new
                        {
                            IdServico = 6,
                            Image = "/images/eletronica2.jpg",
                            Nome = "Eletricidade/Eletrónica",
                            Preco = "100€ - 995€"
                        },
                        new
                        {
                            IdServico = 7,
                            Image = "/images/pintura.jpg",
                            Nome = "Pintura",
                            Preco = "300€ - 700€"
                        },
                        new
                        {
                            IdServico = 8,
                            Image = "/images/assistencia2.jpg",
                            Nome = "Assistência em Viagem",
                            Preco = "30€ - 60€"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Cliente", b =>
                {
                    b.HasOne("OficinaPimpolho.Models.Marcacao", "Marcacao")
                        .WithMany()
                        .HasForeignKey("MarcacaoIdMarcacao");

                    b.Navigation("Marcacao");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.MarcacaoServico", b =>
                {
                    b.HasOne("OficinaPimpolho.Models.Marcacao", "Marcacao")
                        .WithMany("MarcacaoServico")
                        .HasForeignKey("MarcacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficinaPimpolho.Models.Servico", "Servico")
                        .WithMany("MarcacaoServico")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marcacao");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.OficinaServico", b =>
                {
                    b.HasOne("OficinaPimpolho.Models.Oficina", "Oficina")
                        .WithMany("OficinaServico")
                        .HasForeignKey("OficinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficinaPimpolho.Models.Servico", "Servico")
                        .WithMany("OficinaServico")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oficina");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Marcacao", b =>
                {
                    b.Navigation("MarcacaoServico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Oficina", b =>
                {
                    b.Navigation("OficinaServico");
                });

            modelBuilder.Entity("OficinaPimpolho.Models.Servico", b =>
                {
                    b.Navigation("MarcacaoServico");

                    b.Navigation("OficinaServico");
                });
#pragma warning restore 612, 618
        }
    }
}
