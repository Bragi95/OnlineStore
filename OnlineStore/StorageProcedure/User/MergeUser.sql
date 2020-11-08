CREATE PROCEDURE [dbo].[MergeUser]
	@Id INT ,
	@Name nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(30),
	@Phone nvarchar(30),
	@Address nvarchar(30),
	@CountryId int,
	@Password nvarchar(100),
	@CityId int
AS
declare @result int
set @result = @Id
Merge dbo.[User] AS C
using (select
	@id,
	@Name,
	@LastName,
	@Email,
	@Phone,
	@Address,
	@CountryId,
	@Password,
	@CityId)
AS sourse(
	id,
	Name,
	LastName,
	Email,
	Phone,
	Address,
	CountryId,
	Password,
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
	Password,
	CityId)
values (
	@Name,
	@LastName,
	@Email,
	@Phone,
	@Address,
	@CountryId,
	@Password,
	@CityId);

if (@result is null)set @result = SCOPE_IDENTITY()

exec SelectUserById @result