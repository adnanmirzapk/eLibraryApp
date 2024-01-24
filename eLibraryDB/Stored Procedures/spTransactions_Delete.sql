CREATE PROCEDURE [dbo].[spTransactions_Delete]
	@ID int
As
Begin
	Delete from dbo.Transactions Where TransactionID = @ID 
End