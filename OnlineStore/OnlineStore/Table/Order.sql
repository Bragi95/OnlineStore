CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[UserId] int ,
	[StorageId] int ,
	[PaymentTypeId] int,
	[StatusOrderId] int ,
	[DateOrder] date ,
	[TotalCost] decimal(4)
)
