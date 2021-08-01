namespace AnimalMaintenance.Accessors.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexUponIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutcomeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexUponOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            // Seed initial data set so some records will be populated
            migrationBuilder.Sql(
                "USE AnimalMaintenance;" +

                "INSERT INTO Animals(AnimalType, Breed, Color, DateOfBirth, Name, IncomeType, SexUponIncome, OutcomeType, SexUponOutcome) " +
                "VALUES " +
                "('Dog', 'Maltese and Chihuahua', 'White and Black', '2021-1-13', 'Peach', '', 'Adoption', 'Intact Female', 'Intact Female'), " +
                "('Cat', 'Domestic Medium hair', 'White and Black', '2018-4-01', 'Toad', '', 'Adoption', 'Intact Male', 'Neutered Male'), " +
                "('Cat', 'Domestic Long hair', 'White and Black', '2016-9-01', 'Yoshi', '', 'Adoption', 'Intact Male', 'Neutered Male')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
