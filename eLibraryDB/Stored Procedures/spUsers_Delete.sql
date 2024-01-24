CREATE PROCEDURE [dbo].[spUsers_Delete]
	@ID int
As
Begin
	Delete from dbo.Users Where UserID = @ID
End