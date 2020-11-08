CREATE PROCEDURE [dbo].[SelectAllUsers]	
AS
SELECT 
	U.Id, U.Name, U.LastName, U.Phone, U.Email, U.Address, 
	C.Id, C.Name,
	Cy.Id,  Cy.Name ,
	R.Id, R.Name
from dbo.[User] AS U
	join dbo.Country as C on C.id = U.CountryId
	join dbo.City as Cy on Cy.id = U.CityId
	join dbo.Role as R on R.id = U.RoleId


