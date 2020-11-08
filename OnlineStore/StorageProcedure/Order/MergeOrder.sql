CREATE PROCEDURE [dbo].[MergeOrder]
	@id int = null,
	@UserId int = null,
	@PaymentTypeId int = null,
	@StatusOrderId int = null,
	@StorageId int = null,
	@TotalCost decimal = null	
	
AS
declare @result int
set @result = @id
Merge dbo.[Order] AS O
using (select
	   @id,
	   @UserId,
	   @PaymentTypeId ,
	   @StorageId,
	   @StatusOrderId, 	   
	   @TotalCost)
as sourse (
	   id,
	   UserId,
	   PaymentTypeId,
	   StorageId,
	   StatusOrderId,
	   TotalCost)
on (O.Id = sourse.Id)
WHEN MATCHED THEN 
update   set
		PaymentTypeId = @PaymentTypeId,	
		StorageId = @StorageId,
		TotalCost = @TotalCost
WHEN NOT MATCHED THEN	
insert  (
	    UserId,
	    PaymentTypeId,
		StorageId,
	    StatusOrderId,
		DateOrder,
	    TotalCost)
values(
	    @UserId,
	    @PaymentTypeId ,
		@StorageId,
	    8, 
	    Sysdatetime(),
	    @TotalCost);  
if(@result is NUll) set  @result = SCOPE_IDENTITY()

select 
	o.id, O.DateOrder, O.TotalCost,
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    U. Id, U.Name, U.LastName, U.Address, U.Phone    
 from dbo.[Order] as O
	left join dbo.[User] as U on U.Id = O.UserId
	left join dbo.Storage as S on S.Id = O.StorageId
	left join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	left join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.Id = @result
