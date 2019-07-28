using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestGAP.Infrastructure.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageType",
                columns: table => new
                {
                    CoverageTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageType", x => x.CoverageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RiskType",
                columns: table => new
                {
                    RiskTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskType", x => x.RiskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    InsurancePolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InitDate = table.Column<DateTime>(nullable: false),
                    CoverageMonth = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    RiskTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.InsurancePolicyId);
                    table.ForeignKey(
                        name: "FK_InsurancePolicy_RiskType_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "RiskType",
                        principalColumn: "RiskTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicyCovering",
                columns: table => new
                {
                    InsurancePolicyCoveringId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverageTypeId = table.Column<int>(nullable: false),
                    InsurancePolicyId = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicyCovering", x => x.InsurancePolicyCoveringId);
                    table.ForeignKey(
                        name: "Fk_InsurancePolicyCovering_CoverageType",
                        column: x => x.CoverageTypeId,
                        principalTable: "CoverageType",
                        principalColumn: "CoverageTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_InsurancePolicyCovering_InsurancePolicy",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "InsurancePolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoverageType",
                columns: new[] { "CoverageTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Terremoto" },
                    { 2, "Incendio" },
                    { 3, "Robo" },
                    { 4, "Pérdida" }
                });

            migrationBuilder.InsertData(
                table: "RiskType",
                columns: new[] { "RiskTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Bajo" },
                    { 2, "Medio" },
                    { 3, "Medio-Alto" },
                    { 4, "Alto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicy_RiskTypeId",
                table: "InsurancePolicy",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicyCovering_CoverageTypeId",
                table: "InsurancePolicyCovering",
                column: "CoverageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicyCovering_InsurancePolicyId",
                table: "InsurancePolicyCovering",
                column: "InsurancePolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurancePolicyCovering");

            migrationBuilder.DropTable(
                name: "CoverageType");

            migrationBuilder.DropTable(
                name: "InsurancePolicy");

            migrationBuilder.DropTable(
                name: "RiskType");
        }
    }
}
