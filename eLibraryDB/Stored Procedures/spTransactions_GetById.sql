CREATE PROCEDURE [dbo].[spTransactions_GetById]
	@ID int
As
Begin
	Select * from dbo.Transactions Where TransactionID = @ID
End
