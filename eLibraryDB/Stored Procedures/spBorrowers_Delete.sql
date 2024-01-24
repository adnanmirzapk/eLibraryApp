CREATE PROCEDURE [dbo].[spBorrowers_Delete]
	@ID int
As
Begin
	Delete from dbo.Borrowers Where BorrowerID = @ID
End