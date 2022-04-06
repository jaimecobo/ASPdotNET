using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore6IdentityCustom.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string ManagerRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();

        //private string User1Id = Guid.NewGuid().ToString();
        //private string User2Id = Guid.NewGuid().ToString();
        private string User5Id = Guid.NewGuid().ToString();
        private string User6Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //SeedRolesSQL(migrationBuilder);

            //SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        //private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
        //    VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
        //    migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
        //    VALUES ('{ManagerRoleId}', 'Manager', 'MANAGER', null);");
        //    migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
        //    VALUES ('{UserRoleId}', 'User', 'USER', null);");
        //}

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            //            migrationBuilder.Sql(
            //                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
            //[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
            //[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
            //VALUES 
            //(N'{User1Id}', N'Test 2', N'Lastname', N'test2@test.ca', N'TEST2@TEST.CA', 
            //N'test2@test.ca', N'TEST2@TEST.CA', 0, 
            //N'AQAAAAEAACcQAAAAEKNB3AEElp6AcyvCjQm35ql7rhnTUt+N1U02seMX+HzopEfIHvBUXuWA9a3LwIC1DA==',
            //N'5ZQZ2QRPEGUBDV2CB62XFUSYJVLO4AA4', N'56bbb1a8-61f7-4058-8387-bdee0799d1a3',
            ////N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
            ////N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749',  
            //NULL, 0, 0, NULL, 1, 0)");

            //            migrationBuilder.Sql(
            //                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
            //[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
            //[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
            //VALUES 
            //(N'{User2Id}', N'Test 3', N'Lastname', N'test3@test.ca', N'TEST3@TEST.CA', 
            //N'test3@test.ca', N'TEST3@TEST.CA', 0, 
            //N'AQAAAAEAACcQAAAAEKNB3AEElp6AcyvCjQm35ql7rhnTUt+N1U02seMX+HzopEfIHvBUXuWA9a3LwIC1DA==',
            //N'5ZQZ2QRPEGUBDV2CB62XFUSYJVLO4AA4', N'56bbb1a8-61f7-4058-8387-bdee0799d1a3',
            ////N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
            ////N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', 
            //NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
            [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
            [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
            VALUES 
            (N'{User5Id}', N'Test 5', N'Lastname', N'test5@test.ca', N'TEST5@TEST.CA', 
            N'test5@test.ca', N'TEST5@TEST.CA', 0, 
            N'AQAAAAEAACcQAAAAEKNB3AEElp6AcyvCjQm35ql7rhnTUt+N1U02seMX+HzopEfIHvBUXuWA9a3LwIC1DA==',
            N'5ZQZ2QRPEGUBDV2CB62XFUSYJVLO4AA4', N'56bbb1a8-61f7-4058-8387-bdee0799d1a3',
            NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
            [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
            [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
            VALUES 
            (N'{User6Id}', N'Test 6', N'Lastname', N'test6@test.ca', N'TEST6@TEST.CA', 
            N'test6@test.ca', N'TEST6@TEST.CA', 0, 
            N'AQAAAAEAACcQAAAAEKNB3AEElp6AcyvCjQm35ql7rhnTUt+N1U02seMX+HzopEfIHvBUXuWA9a3LwIC1DA==',
            N'5ZQZ2QRPEGUBDV2CB62XFUSYJVLO4AA4', N'56bbb1a8-61f7-4058-8387-bdee0799d1a3',
            NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.Sql(@$"
            //INSERT INTO [dbo].[AspNetUserRoles]
            //   ([UserId]
            //   ,[RoleId])
            //VALUES
            //   ('{User1Id}', '{ManagerRoleId}');
            //INSERT INTO [dbo].[AspNetUserRoles]
            //   ([UserId]
            //   ,[RoleId])
            //VALUES
            //   ('{User1Id}', '{UserRoleId}');");

            //    migrationBuilder.Sql(@$"
            //INSERT INTO [dbo].[AspNetUserRoles]
            //   ([UserId]
            //   ,[RoleId])
            //VALUES
            //   ('{User2Id}', '{AdminRoleId}');
            //INSERT INTO [dbo].[AspNetUserRoles]
            //   ([UserId]
            //   ,[RoleId])
            //VALUES
            //   ('{User2Id}', '{ManagerRoleId}');");


            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User5Id}', '{ManagerRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User5Id}', '{UserRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User6Id}', '{AdminRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User6Id}', '{ManagerRoleId}');");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
