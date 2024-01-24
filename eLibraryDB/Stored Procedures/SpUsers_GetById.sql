CREATE PROCEDURE [dbo].[SpUsers)GetById]
	@ID int
AS
Begin
	Select * from dbo.Users Where UserID = @ID
End
