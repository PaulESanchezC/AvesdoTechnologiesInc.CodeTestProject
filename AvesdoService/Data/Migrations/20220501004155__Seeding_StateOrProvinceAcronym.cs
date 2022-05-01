using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class _Seeding_StateOrProvinceAcronym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'AB'
WHERE [TaxId] = 1

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym]  = 'BC'
WHERE [TaxId] = 2

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym]  = 'MB'
WHERE [TaxId] = 3

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym]  = 'NT'
WHERE [TaxId] = 4

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'NU'
WHERE [TaxId] = 5

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'QC'
WHERE [TaxId] = 6

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'SK'
WHERE [TaxId] = 7

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'YK'
WHERE [TaxId] = 8

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'ON'
WHERE [TaxId] = 9

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'NB'
WHERE [TaxId] = 10

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'NF'
WHERE [TaxId] = 11

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym]  = 'NS'
WHERE [TaxId] = 12

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'PI'
WHERE [TaxId] = 13

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'BC'
WHERE [TaxId] = 14

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'MB'
WHERE [TaxId] = 15

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'QC'
WHERE [TaxId] = 16

UPDATE [dbo].[Tax] SET [StateOrProvinceAcronym] = 'SK'
WHERE [TaxId] = 17
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
