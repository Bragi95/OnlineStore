CREATE PROCEDURE [dbo].[MergeOrder]
	@id int = null,
	@CustomerId int = null,
	@PaymentTypeId int =null,
	@StatusOrderId int = null,
	@TotalCost decimal = null,	
	@quantity int = null
AS
declare @result int
set @result = @id
Merge dbo.[Order] AS O
using (select
	   @id,
	   @CustomerId,
	   @PaymentTypeId ,
	   @StatusOrderId, 	   
	   @TotalCost)
as sourse (
	   id,
	   CustomerId,
	   PaymentTypeId,
	   StatusOrderId,
	   TotalCost)
on (O.Id = sourse.Id)
WHEN MATCHED THEN 
update   set
		PaymentTypeId = @PaymentTypeId,	 
		StatusOrderId = @StatusOrderId,
		TotalCost = @TotalCost
WHEN NOT MATCHED THEN	
insert  (
	    CustomerId,
	    PaymentTypeId,
	    StatusOrderId,
		DateOrder,
	    TotalCost)
values(
	    @CustomerId,
	    @PaymentTypeId ,
	    @StatusOrderId, 
	    Sysdatetime(),
	    @TotalCost);  
if(@result is NUll) set  @result = SCOPE_IDENTITY()

exec SelectOrderById @result
