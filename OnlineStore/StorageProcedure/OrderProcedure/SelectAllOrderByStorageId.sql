CREATE PROCEDURE [dbo].[SelectAllOrderByStorageId]
@id int
AS
select 
    o.id, 
   S.Id, S.Name, S.CityId, S.Address, S.Phone,
   PT.Id,  PT.Type,
   SO.Id,  SO.Name, 
   C. Id, C.Name, C.LastName, C.Address, c.Phone    
   from dbo.[Order] as O
join dbo.Customer as C on C.Id = O.CustomerId
join dbo.Storage as S on S.Id = O.StorageId
join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.StorageId = @Id