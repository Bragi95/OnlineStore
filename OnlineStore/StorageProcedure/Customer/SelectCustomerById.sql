CREATE PROCEDURE [dbo].[SelectCustomerById]
	@id int
AS
	SELECT Cu.Id, Cu.Name, Cu.LastName, Cu.Phone, Cu.Email, R.Id, R.Name, C.Id, C.Name as Country,Cy.Id,  Cy.Name as City from dbo.Customer AS Cu
	join dbo.Country as C on C.id = Cu.CountryId
	join dbo.City as Cy on Cy.id = Cu.CityId
	join dbo.Role as R on R.id = Cu.RoleId
	Where Cu.Id = @Id
