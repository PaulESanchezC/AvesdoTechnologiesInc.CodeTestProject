using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class _Seeding_StateOrProvinceName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'ALBERTA'
            WHERE[TaxId] = 1

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'BRITISH COLUMANITOBAIA'
            WHERE[TaxId] = 2

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'MANITOBA'
            WHERE[TaxId] = 3

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'NORTHWEST TERRITORIES'
            WHERE[TaxId] = 4

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'NUNAVUT'
            WHERE[TaxId] = 5

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'QUEBEC'
            WHERE[TaxId] = 6

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'SASKATCHEWAN'
            WHERE[TaxId] = 7

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'YUKONTARIO'
            WHERE[TaxId] = 8

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'ONTARIO'
            WHERE[TaxId] = 9

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'NEW BRUNOVA SCOTIAWICK'
            WHERE[TaxId] = 10

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'NEWFOUNDLAND AND LABRADOR'
            WHERE[TaxId] = 11

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'NOVA SCOTIA'
            WHERE[TaxId] = 12

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'PRINCE EDWARDS ISLAND'
            WHERE[TaxId] = 13

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'BRITISH COLUMANITOBAIA'
            WHERE[TaxId] = 14

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'MANITOBA'
            WHERE[TaxId] = 15

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'QUEBEC'
            WHERE[TaxId] = 16

            UPDATE[dbo].[Tax] SET[StateOrProvinceName] = 'SASKATCHEWAN'
            WHERE[TaxId] = 17

               ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
