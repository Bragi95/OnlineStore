CREATE TABLE [dbo].[FeedBack]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] int null,
	[GoodsId] int null,
	[StorageId] int null,
	[Message] nvarchar(2000),
	[Date] date,
	[Rating] int 
)
