CREATE PROCEDURE [dbo].[SelectAllCustomer]
AS
	SELECT Cu.Id, Cu.Name, Cu.LastName, Cu.Phone, Cu.Email, C.Id, C.Name as Country,Cy.Id,  Cy.Name as City from dbo.Customer AS Cu
	join dbo.Country as C on C.id = Cu.CountryId
	join dbo.City as Cy on Cy.id = Cu.CityId
