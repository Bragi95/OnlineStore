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
PRINT N'Altering [dbo].[MergeCustomer]...';


GO
ALTER PROCEDURE [dbo].[MergeCustomer]
	@Id INT ,
	@Name nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(30),
	@Phone nvarchar(30),
	@Address nvarchar(30),
	@CountryId int,
	@CityId int
AS
declare @result int
set @result = @Id
Merge dbo.[Customer] AS C
using (select
	@id,
	@Name,
	@LastName,
	@Email,
	@Phone,
	@Address,
	@CountryId,
	@CityId)
AS sourse(
	id,
	Name,
	LastName,
	Email,
	Phone,
	Address,
	CountryId,
	CityId)
on(C.id = sourse.id)
WHEN MATCHED THEN
Update set
	Name = sourse.Name,
	LastName = sourse.LastName,
	Email = sourse.Email,
	Phone = sourse.Phone,
	Address = sourse.Address,
	CountryId = sourse.CountryId,
	CityId = sourse.CityId
WHEN NOT MATCHED THEN
insert (
	Name,
	LastName,
	Email,
	Phone,
	Address,
	CountryId,
	CityId)
values (
	@Name,
	@LastName,
	@Email,
	@Phone,
	@Address,
	@CountryId,
	@CityId);

if (@result is null)set @result = SCOPE_IDENTITY()

exec SelectCustomerById @result
GO
PRINT N'Update complete.';


GO
