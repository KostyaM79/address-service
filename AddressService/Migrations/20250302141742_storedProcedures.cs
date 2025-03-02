using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressService.Migrations
{
    public partial class storedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO RegionStatuses(RegionStatusName) VALUES(N'Нет'), (N'Респ.'), (N'Кр.'), (N'Обл.'), (N'г.'), (N'Авт. обл.'), (N'Авт. окр.')");

            migrationBuilder.Sql("INSERT INTO TownStatuses(TownStatusName) VALUES(N'Нет'), (N'г.'), (N'п.'), (N'с.'), (N'д.'), (N'ст.'), (N'х.')");

            migrationBuilder.Sql("INSERT INTO StreetTypes(StreetTypeName) VALUES(N'Нет'), (N'пр.'), (N'ул.'), (N'пер.'), (N'наб.'), (N'наб. р.'), (N'наб. кан.'), (N'линия'), (N'пл.')");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddCountryProc
                    @countryName NVARCHAR(25), @id INT = 0 OUT
                AS
                    IF(NOT EXISTS(SELECT 1 FROM Countries WHERE(CountryName = @countryName)))
                BEGIN
                    INSERT INTO Countries(CountryName) VALUES(@countryName)
                    SET @id=@@IDENTITY
                    EXEC AddRegionProc @countryId=@id, @regionName=N'Не указано', @regionStatusId=1
                END
                    ELSE SET @id = (SELECT TOP 1 Id FROM Countries WHERE(CountryName= @countryName))
                RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddRegionProc
                        @countryId INT, @regionName NVARCHAR(25), @regionStatusId INT, @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS(SELECT 1 FROM Regions WHERE(CountryId=@countryId AND RegionName=@regionName AND RegionStatusId=@regionStatusId)))
                    BEGIN
                        INSERT INTO Regions(CountryId, RegionName, RegionStatusId) VALUES(@countryId, @regionName, @regionStatusId)
                        SET @id=@@IDENTITY
                        EXEC AddDistrictProc @regionId=@id, @districtName=N'Не указано'
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM Regions WHERE(CountryId=@countryId AND RegionName=@regionName AND RegionStatusId=@regionStatusId))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddDistrictProc
                        @regionId INT, @districtName NVARCHAR(25), @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS(SELECT 1 FROM Districts WHERE(RegionId=@regionId AND DistrictName=@districtName)))
                    BEGIN
                        INSERT INTO Districts(RegionId, DistrictName) VALUES(@regionId, @districtName)
                        SET @id=@@IDENTITY
                        EXEC AddTownProc @districtId=@id, @townName=N'Не указано', @townStatusId=1
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM Districts WHERE(RegionId=@regionId AND DistrictName=@districtName))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddTownProc
                        @districtId INT, @townName NVARCHAR(25), @townStatusId INT, @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS(SELECT 1 FROM Towns WHERE(DistrictId=@districtId AND TownName=@townName AND TownStatusId=@townStatusId)))
                    BEGIN
                        INSERT INTO Towns(DistrictId, TownName, TownStatusId) VALUES(@districtId, @townName, @townStatusId)
                        SET @id=@@IDENTITY
                        EXEC AddStreetProc @townId=@id, @streetName=N'Не указано', @streetTypeId=1
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM Towns WHERE(DistrictId=@districtId AND TownName=@townName AND TownStatusId=@townStatusId))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddStreetProc
                        @townId INT, @streetName NVARCHAR(25), @streetTypeId INT, @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS (SELECT 1 FROM Streets WHERE(TownId=@townId AND StreetName=@streetName AND StreetTypeId=@streetTypeId)))
                    BEGIN
                        INSERT INTO Streets(TownId, StreetName, StreetTypeId) VALUES(@townId, @streetName, @streetTypeId)
                        SET @id=@@IDENTITY
                        EXEC AddHouseNumberProc @streetId=@id, @houseNumber=N'Нет'
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM Streets WHERE(TownId=@townId AND StreetName=@streetName AND StreetTypeId=@streetTypeId))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddHouseNumberProc
                        @streetId INT, @houseNumber NVARCHAR(5), @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS (SELECT 1 FROM HouseNumbers WHERE(StreetId=@streetId AND HouseNumber=@houseNumber)))
                    BEGIN
                        INSERT INTO HouseNumbers(StreetId, HouseNumber) VALUES(@streetId, @houseNumber)
                        SET @id=@@IDENTITY
                        EXEC AddBuildingNumberProc @houseNumberId=@id, @buildingNumber=N'Нет'
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM HouseNumbers WHERE(StreetId=@streetId AND HouseNumber=@houseNumber))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddBuildingNumberProc
                        @houseNumberId INT, @buildingNumber NVARCHAR(5), @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS (SELECT 1 FROM BuildingNumbers WHERE(HouseNumberId=@houseNumberId AND BuildingNumber=@buildingNumber)))
                    BEGIN
                        INSERT INTO BuildingNumbers(HouseNumberId, BuildingNumber) VALUES(@houseNumberId, @buildingNumber)
                        SET @id=@@IDENTITY
                        EXEC AddApartamentNumberProc @buildingNumberId=@id, @apartamentNumber=N'Нет'
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM BuildingNumbers WHERE(HouseNumberId=@houseNumberId AND BuildingNumber=@buildingNumber))
                    RETURN 0");

            migrationBuilder.Sql(sql: @"CREATE PROCEDURE AddApartamentNumberProc
                        @buildingNumberId INT, @apartamentNumber NVARCHAR(5), @id INT = 0 OUT
                    AS
                        IF(NOT EXISTS (SELECT 1 FROM ApartamentNumbers WHERE(BuildingNumberId=@buildingNumberId AND ApartamentNumber=@apartamentNumber)))
                    BEGIN
                        INSERT INTO ApartamentNumbers(BuildingNumberId, ApartamentNumber) VALUES(@buildingNumberId, @apartamentNumber)
                        SET @id=@@IDENTITY
                    END
                        ELSE SET @id=(SELECT TOP 1 Id FROM ApartamentNumbers WHERE(BuildingNumberId=@buildingNumberId AND ApartamentNumber=@apartamentNumber))
                    RETURN 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE AddCountryProc");
            migrationBuilder.Sql("DROP PROCEDURE AddRegionProc");
            migrationBuilder.Sql("DROP PROCEDURE AddDistrictProc");
            migrationBuilder.Sql("DROP PROCEDURE AddTownProc");
            migrationBuilder.Sql("DROP PROCEDURE AddStreetProc");
            migrationBuilder.Sql("DROP PROCEDURE AddHouseNumberProc");
            migrationBuilder.Sql("DROP PROCEDURE AddBuildingNumberProc");
            migrationBuilder.Sql("DROP PROCEDURE AddApartamentNumberProc");
        }
    }
}
