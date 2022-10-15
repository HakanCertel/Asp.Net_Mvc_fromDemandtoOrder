﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senfoni.Data.Concrete.EfCore;

namespace Senfoni.Data.Migrations
{
    [DbContext(typeof(SenfoniContext))]
    partial class SenfoniContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senfoni.Entity.Cari", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(500);

                    b.Property<string>("Adres")
                        .HasMaxLength(155);

                    b.Property<string>("CariAdi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Durum");

                    b.Property<string>("EMail")
                        .HasMaxLength(50);

                    b.Property<string>("Fax")
                        .HasMaxLength(17);

                    b.Property<string>("Kod");

                    b.Property<string>("TcKimlikNo")
                        .HasMaxLength(14);

                    b.Property<string>("Telefon1")
                        .HasMaxLength(17);

                    b.Property<string>("Telefon2")
                        .HasMaxLength(17);

                    b.Property<string>("Telefon3")
                        .HasMaxLength(17);

                    b.Property<string>("Telefon4")
                        .HasMaxLength(17);

                    b.Property<string>("VergiDairesi")
                        .HasMaxLength(50);

                    b.Property<string>("VergiNo")
                        .HasMaxLength(20);

                    b.Property<string>("Web")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cari");
                });

            modelBuilder.Entity("Senfoni.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Senfoni.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartId");

                    b.Property<string>("KullaniciId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Senfoni.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Senfoni.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ConversationId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Note");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<int>("OrderState");

                    b.Property<string>("PaymentId");

                    b.Property<int>("PaymentType");

                    b.Property<string>("Phone");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Senfoni.Entity.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Senfoni.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsHome");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("Url");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Senfoni.Entity.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductId");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Senfoni.Entity.Siparis", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("CariId");

                    b.Property<bool>("Kapandi");

                    b.Property<string>("Kod");

                    b.Property<string>("KullaniciId");

                    b.Property<DateTime>("SiparisTarihi");

                    b.Property<DateTime>("TeslimTarihi");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.ToTable("Siparis");
                });

            modelBuilder.Entity("Senfoni.Entity.SiparisBilgileri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CariId");

                    b.Property<decimal>("Fiyat");

                    b.Property<bool>("Kapandi");

                    b.Property<string>("KullaniciId");

                    b.Property<long>("SiparisId");

                    b.Property<DateTime>("SiparisTarihi");

                    b.Property<long>("StokId");

                    b.Property<decimal>("TalepMiktari");

                    b.Property<DateTime>("TeslimTarihi");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.HasIndex("SiparisId");

                    b.HasIndex("StokId");

                    b.ToTable("SiparisBilgileri");
                });

            modelBuilder.Entity("Senfoni.Entity.Stok", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Birim");

                    b.Property<bool>("Durum");

                    b.Property<decimal>("Fiyat");

                    b.Property<string>("FiyatBirim");

                    b.Property<string>("Kod");

                    b.Property<string>("StokAdi");

                    b.Property<decimal>("StokMiktari");

                    b.HasKey("Id");

                    b.ToTable("Stok");
                });

            modelBuilder.Entity("Senfoni.Entity.Teklif", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("CariId");

                    b.Property<string>("Kod");

                    b.Property<string>("KullaniciId");

                    b.Property<DateTime>("SiparisTarihi");

                    b.Property<bool>("SipariseDonustu");

                    b.Property<DateTime>("TeslimTarihi");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.ToTable("Teklif");
                });

            modelBuilder.Entity("Senfoni.Entity.TeklifBilgileri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CariId");

                    b.Property<string>("KullaniciId");

                    b.Property<DateTime>("SiparisTarihi");

                    b.Property<bool>("SipariseDonustumu");

                    b.Property<long>("StokId");

                    b.Property<decimal>("TalepMiktari");

                    b.Property<long>("TeklifId");

                    b.Property<DateTime>("TeslimTarihi");

                    b.HasKey("Id");

                    b.HasIndex("StokId");

                    b.HasIndex("TeklifId");

                    b.ToTable("TeklifBilgileri");
                });

            modelBuilder.Entity("Senfoni.Entity.CartItem", b =>
                {
                    b.HasOne("Senfoni.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.OrderItem", b =>
                {
                    b.HasOne("Senfoni.Entity.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.ProductCategory", b =>
                {
                    b.HasOne("Senfoni.Entity.Category", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.Siparis", b =>
                {
                    b.HasOne("Senfoni.Entity.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.SiparisBilgileri", b =>
                {
                    b.HasOne("Senfoni.Entity.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Siparis", "Siparis")
                        .WithMany("SiparisBilgileri")
                        .HasForeignKey("SiparisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Stok", "Stok")
                        .WithMany("SiparisBilgileri")
                        .HasForeignKey("StokId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.Teklif", b =>
                {
                    b.HasOne("Senfoni.Entity.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senfoni.Entity.TeklifBilgileri", b =>
                {
                    b.HasOne("Senfoni.Entity.Stok", "Stok")
                        .WithMany("TeklifBilgileri")
                        .HasForeignKey("StokId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Senfoni.Entity.Teklif", "Teklif")
                        .WithMany("TeklifBilgileri")
                        .HasForeignKey("TeklifId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
