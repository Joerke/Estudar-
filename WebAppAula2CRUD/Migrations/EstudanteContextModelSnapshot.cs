﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebAppAula2CRUD.Models;

namespace WebAppAula2CRUD.Migrations
{
    [DbContext(typeof(EstudanteContext))]
    partial class EstudanteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppAula2CRUD.Models.Estudante", b =>
                {
                    b.Property<int>("EstudanteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.HasKey("EstudanteId");

                    b.ToTable("Estudante");
                });
#pragma warning restore 612, 618
        }
    }
}
