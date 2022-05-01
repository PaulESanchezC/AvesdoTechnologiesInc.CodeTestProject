using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Seeding_StoreTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
INSERT INTO [dbo].[StoreTax] ([StoresStoreId], [TaxId]) VALUES (N'2PBIPVKSAEynTkwDBlQz8w', 6)
INSERT INTO [dbo].[StoreTax] ([StoresStoreId], [TaxId]) VALUES (N'2PBIPVKSAEynTkwDBlQz8w', 16)
INSERT INTO [dbo].[StoreTax] ([StoresStoreId], [TaxId]) VALUES (N'ObYDIRWGPUWhAeRtx2extQ', 9)
INSERT INTO [dbo].[StoreTax] ([StoresStoreId], [TaxId]) VALUES (N'ZOVeglC_pUm23GPfH972qA', 2)
INSERT INTO [dbo].[StoreTax] ([StoresStoreId], [TaxId]) VALUES (N'ZOVeglC_pUm23GPfH972qA', 14)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
