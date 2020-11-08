CREATE PROCEDURE [dbo].[UpdateStatusOrderByOrderId]
	@orderid int ,
	@statusId int
AS
	update dbo.[Order] 
	set 
		StatusOrderId = @statusId
	Where id = @orderid
	
exec SelectOrderById @orderid
