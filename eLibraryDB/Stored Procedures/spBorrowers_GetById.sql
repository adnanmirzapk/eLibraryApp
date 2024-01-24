CREATE PROCEDURE [dbo].[spBorrowers_GetById]
	@ID int
AS
Begin
	Select * from dbo.Borrowers Where BorrowerID = @ID
End
