using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Seeding_Tax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
SET IDENTITY_INSERT [dbo].[Tax] ON
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (1, 5, N'5%', N'GST Alberta', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (2, 5, N'5%', N'GST British Columbia', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (3, 5, N'5%', N'GST Manitoba', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (4, 5, N'5%', N'GST Northwest Territories', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (5, 5, N'5%', N'GST Nunavut', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (6, 5, N'5%', N'GST Quebec', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (7, 5, N'5%', N'GST Saskatchewan', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (8, 5, N'5%', N'GST Yukon', N'GST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (9, 13, N'13%', N'HST Ontario', N'HST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (10, 15, N'15%', N'HST New Brunswick', N'HST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (11, 15, N'15%', N'HST Newfoundland and Labrador', N'HST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (12, 15, N'15%', N'HST Nova Scotia', N'HST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (13, 15, N'15%', N'HST Prince Edward Island', N'HST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (14, 7, N'7%', N'PST British Columbia', N'PST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (15, 7, N'7%', N'PST Manitoba', N'PST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (16, 9.975, N'9.975%', N'PST Quebec', N'PST', N'2022-04-30 04:26:07', 1)
INSERT INTO [dbo].[Tax] ([TaxId], [TaxPercentage], [TaxPercentageString], [TaxDescription], [TaxAcronym], [DateCreated], [IsActive]) 
VALUES (17, 6, N'6%', N'PST Saskatchewan', N'PST', N'2022-04-30 04:26:07', 1)
SET IDENTITY_INSERT [dbo].[Tax] OFF

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
