CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] nvarchar(30),
	[LastName] nvarchar(30),
	[Email] nvarchar(30),
	[Phone] nvarchar(30),
	[Address] nvarchar(30),
	[CountryId] int,
	[CityId] int,
	[RoleId] int DEFAULT 1,
	[Password] nvarchar(100) default null
)
