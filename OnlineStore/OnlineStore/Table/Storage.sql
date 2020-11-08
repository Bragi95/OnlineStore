CREATE TABLE [dbo].[Storage]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CountryId] int,
	[CityId] int,
	[Name] nvarchar(30),
	[Address] nvarchar(30),
	[Phone] nvarchar(30),
	[Email] nvarchar(30)	
)
