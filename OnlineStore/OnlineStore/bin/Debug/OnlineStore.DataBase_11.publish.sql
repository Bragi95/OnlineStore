﻿/*
Deployment script for OnlineStore.DataBase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "OnlineStore.DataBase"
:setvar DefaultFilePrefix "OnlineStore.DataBase"
:setvar DefaultDataPath "K:\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "K:\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[SelectOrderById]...';


GO
ALTER PROCEDURE [dbo].[SelectOrderById]
@orderId int 
	
AS
select 
	o.id, 
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    C. Id, C.Name, C.LastName, C.Address, c.Phone  ,  
    G.Id, G.Brand, G.Model, g.Price, 
	OG.Id , Og.quantityGoods	
 from dbo.[Order] as O
    left join dbo.Order_Goods as OG on Og.orderId = O.Id
	join dbo.Goods as G on G.Id = OG.goodsId
	left join dbo.Customer as C on C.Id = O.CustomerId
	left join dbo.Storage as S on S.Id = O.StorageId
	left join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	left join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.Id = @orderId
GO
PRINT N'Refreshing [dbo].[MergeOrder]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[MergeOrder]';


GO
PRINT N'Update complete.';


GO
