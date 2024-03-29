﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persona5APP.Models;

namespace Persona5APP.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20191118110233_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Persona5APP.Models.Arcana", b =>
                {
                    b.Property<int>("arcanaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arcananame");

                    b.HasKey("arcanaID");

                    b.ToTable("Arcanas");
                });

            modelBuilder.Entity("Persona5APP.Models.Persona", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PersonaName");

                    b.Property<int?>("arcanaID");

                    b.HasKey("PersonaID");

                    b.HasIndex("arcanaID");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Persona5APP.Models.Persona", b =>
                {
                    b.HasOne("Persona5APP.Models.Arcana", "arcana")
                        .WithMany("Personas")
                        .HasForeignKey("arcanaID");
                });
#pragma warning restore 612, 618
        }
    }
}
