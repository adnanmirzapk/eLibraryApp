CREATE PROCEDURE [dbo].[spBooks_Delete]
	@ID int
As
Begin
	Delete from dbo.Books Where BookID = @ID
End
	