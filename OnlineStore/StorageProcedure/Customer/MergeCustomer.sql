CREATE PROCEDURE [dbo].[MergeCustomer]
	@Id INT ,
	@Name nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(30),
	@Phone nvarchar(30),
	@Address nvarchar(30),
	@CountryId int,
	@CityId int,
	@Password  nvarchar(100)
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