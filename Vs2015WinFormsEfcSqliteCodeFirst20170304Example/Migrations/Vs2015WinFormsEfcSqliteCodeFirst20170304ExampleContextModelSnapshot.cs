using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model;

namespace Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Migrations
{
    [DbContext(typeof(Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext))]
    partial class Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

					// The following line was added manually
                    b.HasIndex("Name").IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CityId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model.Person", b =>
                {
                    b.HasOne("Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId");
                });
        }
    }
}
