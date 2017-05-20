using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using net_core_ef.Data;
using net_core_ef.ViewModels;

namespace netcoreef.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20170520145400_0001")]
    partial class _0001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("net_core_ef.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });
        }
    }
}
