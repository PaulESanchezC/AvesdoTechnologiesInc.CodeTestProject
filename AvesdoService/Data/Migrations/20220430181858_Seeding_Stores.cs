using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Seeding_Stores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

INSERT INTO [dbo].[Stores] ([StoreId], [StoreName], [StorePhoneNumber], [StoreEmail], [StoreWebsite], [StoreAddress], [StoreCity], [StoreStateOrProvince], [StoreZipCode], [DateCreated], [IsActive]) VALUES (N'2PBIPVKSAEynTkwDBlQz8w', N'La loi 101 Pizza', N'514-794-3740', N'PaulESanchezC@outlook.com', N'https://github.com/PaulESanchezC', N'4982 rue Adam', N'Montreal', N'Quebec', N'H1V 1W5', N'2022-04-30 05:12:05', 1)
INSERT INTO [dbo].[Stores] ([StoreId], [StoreName], [StorePhoneNumber], [StoreEmail], [StoreWebsite], [StoreAddress], [StoreCity], [StoreStateOrProvince], [StoreZipCode], [DateCreated], [IsActive]) VALUES (N'ObYDIRWGPUWhAeRtx2extQ', N'Avesdo', N'1.888.730.9439', N'support@avesdo.com', N'https://www.avesdo.com/', N'Unknown', N'Toronto', N'Ontario', N'Unknown', N'2022-04-30 05:12:04', 1)
INSERT INTO [dbo].[Stores] ([StoreId], [StoreName], [StorePhoneNumber], [StoreEmail], [StoreWebsite], [StoreAddress], [StoreCity], [StoreStateOrProvince], [StoreZipCode], [DateCreated], [IsActive]) VALUES (N'ZOVeglC_pUm23GPfH972qA', N'Fake Pizzeria, the pizza is real dough', N'1-80fa-kep-pzza  1-8032-537-4992', N'FakePizzeria@fake.com', N'https://www.FakePizzeria.com/', N'Unknown', N'Vancouver', N'British Columbia', N'Unknown', N'2022-04-30 05:12:05', 1)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
