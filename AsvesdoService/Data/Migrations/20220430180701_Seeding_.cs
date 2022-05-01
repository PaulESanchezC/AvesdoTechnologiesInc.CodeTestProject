using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Seeding_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
INSERT INTO [dbo].[Customers] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerPhoneNumber], [CustomerEmail], [CustomerAddress], [CustomerCity], [CustomerStateOrProvince], [CustomerZipCode], [DateCreated], [IsActive], [CustomerPreferredPronoun]) VALUES (N'761f94a7-19a8-4567-992d-0f4846015f8a', N'Francis', N'Underwood', N'1 202-456-1111', N'No Email', N'1600 Pennsylvania Avenue NW', N'Washington', N'District of Columbia', N'20500', N'2022-04-30 06:22:10', 1, N'He, Him')
INSERT INTO [dbo].[Customers] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerPhoneNumber], [CustomerEmail], [CustomerAddress], [CustomerCity], [CustomerStateOrProvince], [CustomerZipCode], [DateCreated], [IsActive], [CustomerPreferredPronoun]) VALUES (N'843e5834-b805-4b25-817c-349bb37f0149', N'Marty', N'Byrde', N'314-000-0001', N'No Email', N'2708 N Fort Ave', N'Springfield', N'Missouri', N'65803', N'2022-04-30 06:22:10', 1, N'He, Him')
INSERT INTO [dbo].[Customers] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerPhoneNumber], [CustomerEmail], [CustomerAddress], [CustomerCity], [CustomerStateOrProvince], [CustomerZipCode], [DateCreated], [IsActive], [CustomerPreferredPronoun]) VALUES (N'a618dc4a-57b5-48f4-8699-4b30e1f9cfd7', N'Uhtred', N'of Bebbanburg', N'Pigeons', N'No Email', N'Bamburgh ne69 7df', N'Bamburgh ', N'Northumberland', N'NE69 7DF', N'2022-04-30 06:22:10', 1, N'')


SET IDENTITY_INSERT [dbo].[EmploymentRoles] ON
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (1, N'Store Manager', N'Store Manager', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (2, N'Administrator', N'Administrator', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (3, N'Executive Chef', N'Restaurant''s Master Chef', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (4, N'Kitchen Manager', N'Manager', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (5, N'Sous-chef', N'Sous-chef', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (6, N'Entry chef', N'Entry chef', N'2022-04-30 04:43:49', 1)
INSERT INTO [dbo].[EmploymentRoles] ([EmploymentRoleId], [EmploymentRoleName], [EmploymentRoleDescription], [DateCreated], [IsActive]) VALUES (7, N'Dishwasher', N'Dishwasher', N'2022-04-30 04:43:49', 1)
SET IDENTITY_INSERT [dbo].[EmploymentRoles] OFF


INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'_Wj0GL6Iy0K-GQWe8l2ZcA', N'+ serving of cheese', N'cheese', 2.5, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'2oP3UXmw1UurS7gGcMkeWA', N'+ serving of green peppers', N'green peppers', 1, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'5OsfKRV0HUG5EkPeGDXJFw', N'La Basic', N'Sauce and cheese', 19.49, 1, N'2022-04-30 04:02:55')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'7PHa2u6XPEi1uEo9bQSalA', N'+ serving of tomatoes', N'tomatoes', 1, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'AEVx8loTDEyLgEMal7ReuQ', N'+ serving of pineapple', N'pineapple', 3, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'D2PZItagmUOxIy5_a50cFw', N'Italian Sausage Pizza', N'Sauce, cheese, mushrooms, green peppers, tomatoes and italian sausages', 23.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'ELoOMJFuvUugFoAPzp5osw', N'Vegetarian Pizza', N'Sauce, cheese, mushrooms, green peppers, tomatoes and green olives', 23.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'EZibaE7wsUWy1GN3ZulwRg', N'+ serving of pepperoni', N'pepperoni', 2.5, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'ijh_R4Pm20KKAeVu2S8PYQ', N'355ml can', N'small sized drink of pop / soda', 1.75, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'ixx0jVTG_UWa4rCpHBO2xQ', N'+ serving of onion', N'onion', 3, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'MoeljLg-5EO8NWZktzh8Mg', N'All Dressed Pizza', N'Sauce, cheese , pepperoni, mushrooms, green peppers', 22.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'oz1S07xYLki72_yZy94scA', N'Pepperoni Bacon', N'Sauce, cheese, Pepperoni, Bacon', 22.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'Qi8MateWFU-FHxCXUO_cpA', N'Hawaiian Pizza', N'Sauce, cheese ,ham and pineapple', 22, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'qLuoyEfUpkeHizfA0so6wg', N'Mexican Pizza', N'Mexican sauce, cheese, onions, black olives, hot peppers, beef and cheese', 23.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'rFcogaigf0KYp-tRtBCrnQ', N'+ serving of green olives', N'green olives', 1, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'TFndHMzJaU6byySHZMgZAw', N'+ serving of black olives', N'black olives', 1, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'ulvON8OZ80OX0y7iTDdFrg', N'Pepperoni Pizza', N'Sauce, cheese and Pepperoni', 20, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'Vc0BbD5dWkaYdw4ynQ9X4A', N'+ serving of bacon', N'bacon', 2.5, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'vy501lq7PUSaR4DHuLO1Sg', N'710ml can', N'medium sized drink of pop / soda', 1.75, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'WDyAuO8tf06Z2pMqeoV50w', N'American Pizza', N'Sauce, cheese, pepperoni, bacon and onions', 22.49, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'wOsi6qdDeESLZZ7wcx2AIg', N'1lt bottle', N'large sized drink of pop / soda', 2, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'xizFxzXwe06uahtoZeQ11A', N'+ serving of mushrooms', N'mushrooms', 1, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'XP1Akb0QA0qvk53J1_3uaw', N'2lt bottle', N'Extra large sized drink of pop / soda', 2.75, 1, N'2022-04-30 04:02:56')
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [IsActive], [DateCreated]) VALUES (N'xV1HVYiLp0uP4oGehmL_KA', N'Quebec Pizza', N'Sauce, double cheese, mushrooms and bacon', 24, 1, N'2022-04-30 04:02:56')

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
